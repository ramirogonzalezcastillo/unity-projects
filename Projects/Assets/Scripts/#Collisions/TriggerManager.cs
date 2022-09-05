using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerManager : MonoBehaviour
{
    public bool isBig = true;
    public GameObject trigger;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Aux"))
        {
            Debug.Log("Colisionando con: " + other.gameObject.name);
            trigger.GetComponent<Collider>().enabled = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            other.GetComponent<Collider>().enabled = false;
            if (isBig == true)
            {
                isBig = false;
                transform.localScale /= 2;
                Debug.Log("Encogido");
            }
            else if (isBig == false)
            {
                isBig = true;
                transform.localScale *= 2;
                Debug.Log("Agrandado");
            }
        }
    }
}