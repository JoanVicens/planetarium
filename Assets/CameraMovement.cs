using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Movement
    public float flySpeed= 0.5f;

    // Camara field of view propierties
    private float minFov = 15f;
    private float maxFov = 90f;
    public float ScrollWheelsensitivity = 10f;

    // Camera transform for cam rotation
    private Transform camera;
    public float mouseSensitivity = 1f;

    private Vector3 initalPosition;

    void Start()
    {
        this.initalPosition = this.transform.position;
        camera = Camera.main.transform;
    }

    void Update()
    {
        // KEYBOARD MOVEMENT
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(flySpeed, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
            transform.position -= new Vector3(flySpeed, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
            transform.position += new Vector3(0, 0, flySpeed);
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
            transform.position -= new Vector3(0, 0, flySpeed);
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
            transform.position += new Vector3(0, flySpeed, 0);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))
            {
            transform.position -= new Vector3(0, flySpeed, 0);
        }

        // MOUSE MOVEMENT
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            camera.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
            camera.Rotate(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0);
        }

        // FOV
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * ScrollWheelsensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        // RESET VIEW
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = initalPosition;
            camera.rotation = Quaternion.Euler(20f, -45f, 0f);
        }


    }
}
