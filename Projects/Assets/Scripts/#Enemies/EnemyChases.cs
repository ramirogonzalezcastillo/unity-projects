using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChases : MonoBehaviour
{
    [SerializeField] // sirve para poder acceder desde inspector a las variables privadas.
    [Range(1f,15f)] float speed = 2f; //[Range(0f,0f)] sirve para tener una barra selectora de valores limites.
    enum ZombieType {LookAt, /*Crawler,*/ Stalker/*Rioter*/}; // enumera un conjunto de Strings.
    [SerializeField] ZombieType zombieType; // y aca los asigna a una variable para luego poder acceder a ellos desde un Switch por ej.
    [SerializeField] Transform playerTransform; /* aca podemos asignar a la variable "player.Transform" solo el componente
    transform del GameObject que le pongamos en el inspector. En este caso del Player*/
    [SerializeField]
    [Range(0.1f,10f)] float speedToLookLerp = 1f;
    [SerializeField] private Animator enemyAnimator;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        switch (zombieType)
        {
            case ZombieType.LookAt:
                LookAtPlayerLerp();
                break;
            /*case ZombieType.Crawler:
                //MoveForward();
                break;*/
            case ZombieType.Stalker:
                Invoke("StalkerMove",1f);
                break;
                /*case ZombieType.Rioter:
                    TurnAroundPlayer();
                    break;*/
        }
    }
    /*private void TurnAroundPlayer()
{
   LookAtPlayer();
   transform.RotateAround(playerTransform.position, Vector3.up, 5f * Time.deltaTime);
}*/
    private void StalkerMove()
    {
        ChasePlayer();
        enemyAnimator.SetBool("isRunning", true);
    }
    private void ChasePlayer()
    {
        LookAtPlayer();
        Vector3 direction = (playerTransform.position - transform.position); /* Resta de vectores donde la resultante es un vector
            con direccion del objetivo 1 al objetivo 2 --- ese vector resultante es asignado a la variable "direction" */
        if (direction.magnitude > 2f) // magnitud > 2 estamos diciendole que no se acerque a menos de 1 unidad del objetivo
        {
            transform.position += direction.normalized * speed * Time.deltaTime; /* normalized iguala la magnitud del vector a 1
            es una operacion vectorial que minimiza la magnitud */
        }
    }
    /*private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }*/
    private void LookAtPlayer()
    {
        transform.LookAt(playerTransform);
    }
    private void LookAtPlayerLerp()
    {
        Quaternion newRotation = Quaternion.LookRotation((playerTransform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLookLerp * Time.deltaTime);
    }
}
