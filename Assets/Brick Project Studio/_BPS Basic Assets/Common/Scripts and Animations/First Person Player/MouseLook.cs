using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MouseLook : MonoBehaviour
    {

        public float mouseXSensitivity = 100f;

        public Transform playerBody;

        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("1");
         }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4");
        }

    }
    }
