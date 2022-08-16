using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDesafio : MonoBehaviour

{
    public float speed = 4f;
    float cameraAxisX = 0f;
    [SerializeField]
    [Range(0.1f,10f)] float mouseSensitivity = 1f;
    void Start()
    {
    }
    void Update()
    {
        RotatePlayer();
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
    }

    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X"); // me guarda un valor float acumulado por cada deteccion de movimiento del mouse
        transform.rotation = Quaternion.Euler(0, cameraAxisX * mouseSensitivity, 0); // ese valor lo usa en Y para rotar mientras ejecuta el update
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}