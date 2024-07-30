using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePerspective : MonoBehaviour
{
    public Transform player;
    private Vector3 position1 = new Vector3(-4.5f, 2.2f, 0);
    private Quaternion rotation1 = Quaternion.Euler(5, 90, 0);
    private Vector3 position2 = new Vector3(0, 2.2f, 0);
    private Quaternion rotation2 = Quaternion.Euler(-15, 0, 0);
    private Vector3 position3 = new Vector3(0, 2.2f, 0);
    private Quaternion rotation3 = Quaternion.Euler(-15, -90, 0);
    private Vector3 position4 = new Vector3(0, 2.2f, 0);
    private Quaternion rotation4 = Quaternion.Euler(-15, 180, 0);

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 100 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 100 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //transform.Rotate(Vector3.up * mouseX);


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.position = position1;
            player.rotation = rotation1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.position = position2;
            player.rotation = rotation2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.position = position3;
            player.rotation = rotation3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.position = position4;
            player.rotation = rotation4;
        }
    }

}
