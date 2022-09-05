using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 0.5f;
    public int bulletDamage = 20;
    void Start()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale *= 2;
        }
        Invoke("DestroyDelay", lifeTime);
    }
    void Update()
    {
        Movements();
    }
    
    void Movements()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyDelay()
    {
        Destroy(gameObject);
    }

}