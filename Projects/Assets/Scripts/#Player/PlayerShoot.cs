using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject munition;
    public bool canShoot = true;
    [SerializeField]
    [Range(0f,10f)] float delayResetShoot = 0.1f;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(munition, transform.position, transform.rotation);
            Invoke("resetShoot", delayResetShoot);
        }
    }
    public void resetShoot()
    {
        canShoot = true;
    }
}