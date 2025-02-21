﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauMouseLook : MonoBehaviour
{
    public float mouseSensivity = 100f;
    public Transform playerBody;
    public VaisseauController controller;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation -= mouseX;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        //playerBody.Rotate(Vector3.right * mouseY);
    }
}
