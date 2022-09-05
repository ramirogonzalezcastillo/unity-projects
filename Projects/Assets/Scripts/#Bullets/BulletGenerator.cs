using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bullet;
    public float delaySpawn = 0f;
    public float intervalSpawn = 0.5f;
    void Start()
    {
        InvokeRepeating("bulletSpawn", delaySpawn, intervalSpawn);
    }
    void Update()
    {
    }
    private void bulletSpawn()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}