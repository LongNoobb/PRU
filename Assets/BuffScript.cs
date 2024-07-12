using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour
{
    [SerializeField]
    public int healthBuff = 0;
    [SerializeField]
    public int damageBuff = 0;
    [SerializeField]
    public int armorBuff = 0;
    [SerializeField]
    public int attackSpeed = 0;
    [SerializeField]
    public int moveSpeed = 0;
    public static BuffScript instance;
    private void Awake()
    {
        instance = this;
        
    }
    public void Start()
    {
        
    }
}
