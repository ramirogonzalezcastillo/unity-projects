using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;
    private void Start()
    {
        playerData = GetComponent<PlayerData>();    
    }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("ENTRANDO EN CONTACTO CON -> " + other.gameObject.name);
        if (other.gameObject.CompareTag("PowerUp"))
        {
            playerData.Healing(other.gameObject.GetComponent<itemProperties>().healthUp);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("SALIENDO DEL CONTACTO CON -> " + other.gameObject.name);
    }
    private void OnCollisionStay(Collision other)
    {
        Debug.Log("COLISIONANDO CON -> " + other.gameObject.name);
    }
}