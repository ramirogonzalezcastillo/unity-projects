using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDesafio : MonoBehaviour

{
    public float speed = 4f;
    public float cameraAxisX = 0f;
    public float cameraAxisY = 0f;
    void Update()
    {
        //UpDownView();
        //RotatePlayer();
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.forward, 180f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.forward, 270f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.forward, 90f);
        }
    }
    /*public void UpDownView()
    {
        cameraAxisY += Input.GetAxis("Mouse Y"); // me guarda un valor float acumulado por cada deteccion de movimiento del mouse
        transform.rotation = Quaternion.Euler(cameraAxisY * mouseSensitivityY, 0, 0);
    }
    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X"); // me guarda un valor float acumulado por cada deteccion de movimiento del mouse
        transform.rotation = Quaternion.Euler(0, cameraAxisX * mouseSensitivityX, 0); // ese valor lo usa en Y para rotar mientras ejecuta el update
    }*/
    private void MovePlayer(Vector3 direction, float rotAngle)
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, rotAngle, 0f);
    }
}