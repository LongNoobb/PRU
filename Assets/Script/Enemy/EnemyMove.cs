using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float nextWPDistance;
    public bool roaming = true;
    public Seeker seeker;
    bool reachDestination = false;
    public bool updateContinuesPath;

    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;
    Path path;
    Coroutine moveCoroutine;
    private bool playerInRoom = false; // New variable to track player presence

    private EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
        reachDestination = true;
        InvokeRepeating("CalculatePath", 0f, 0.5f);
    }
    private void Update()
    {
        if (!playerInRoom) return; // Do nothing if the player is not in the room

        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            EnemyFireBullet();
        }
    }
    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<MoveController>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyHealth.TakeDamage(1);
        }
    }
    void CalculatePath()
    {
        if (!playerInRoom) return; // Do nothing if the player is not in the room

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

    // New method to handle player entering the room
    public void PlayerEnteredRoom()
    {
        Debug.Log("Enemy detected player entering the room");
        playerInRoom = true;
        CalculatePath(); // Start path calculation immediately
    }

    // New method to handle player leaving the room (if needed)
    public void PlayerLeftRoom()
    {
        Debug.Log("Enemy detected player leaving the room");
        playerInRoom = false;
    }
}
