using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallManager : MonoBehaviour
{
    private float count = 0;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Wall"))
        {
            count = 0;
            Debug.Log("Colisionando con: " + other.gameObject.name + " - Será teletransportado en 2s");
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Wall"))
        {
            count += Time.deltaTime;
            if (count >= 2f)
            {
                this.gameObject.GetComponent<PlayerMovementDesafio>().cameraAxisX = Random.Range(0f,360f);
                transform.position = new Vector3(Random.Range(-4.9f,4.9f), 1f, Random.Range(-4.9f,4.9f));
                Debug.Log("Nueva ubicación");
            }
        }
    }
}