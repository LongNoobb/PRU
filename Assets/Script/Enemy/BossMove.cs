using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float moveSpeed;
    public float nextWPDistance;
    public bool roaming = true;
    public Seeker seeker;
    bool reachDestination = false;
    public bool updateContinuesPath;

    public bool isShootable = false;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;
    public int numberOfBullets = 8;
    Path path;
    Coroutine moveCoroutine;
    private bool playerInRoom = false;

    private BossHealth bossHealth;
    public GunContainer gunContainer;
    void Start()
    {
        bossHealth = gameObject.GetComponent<BossHealth>();
        reachDestination = true;
        InvokeRepeating("CalculatePath", 0f, 0.5f);
    }

    private void Update()
    {
        if (!playerInRoom) return;

        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0)
        {
            BossFireBullets();
            fireCooldown = timeBtwFire;
        }
    }

    void BossFireBullets()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = Random.Range(0f, 360f);
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f);

            // Instantiate bullet at boss position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            bossHealth.TakeDamage(gunContainer.currentWeapon.GetComponent<Weapon>().BulletDame);
        }
    }

    void CalculatePath()
    {
        if (!playerInRoom) return;

        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        if (gameObject.activeInHierarchy)
            moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            yield return null;
        }

        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<MoveController>().transform.position;
        if (roaming == true)
        {
            return (Vector2)playerPos + (Random.Range(10f, 50f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
        }
        else
        {
            return playerPos;
        }
    }

    public void PlayerEnteredRoom()
    {
        Debug.Log("Boss detected player entering the room");
        playerInRoom = true;
        CalculatePath();
    }
}
