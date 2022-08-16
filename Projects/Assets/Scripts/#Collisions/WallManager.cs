using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    float count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            count = 0;
            Debug.Log("Teletransport Zone - Delay: 2 seconds");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            count += Time.deltaTime;
            if (count >= 2f)
            {
                Vector3 newPosition = new Vector3(Random.Range(-4.9f, 4.9f), 1f, Random.Range(-4.9f, 4.9f));
                transform.position = newPosition;
                transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0));
            }
        }
    }
}