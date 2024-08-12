using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public Vector3 pos= new Vector3(30, 20, 10);
    private Vector3 initPos = new Vector3(0, -5, 0);
    public Transform player;
    public float moveSpeed = 0.01f;
    public SerialController serial;

    private Vector3 localPos;
    private GameObject[] tools;
    private Vector3[] toolPos;
    private Quaternion[] toolRot;
    private int currentTool = 0;
    private int lastTool = 5;
    private Vector3 before_rot;
    private bool CanMove = true;
    private Vector3 ValidMove;

    void Start(){
        moveSpeed = 0.01f;
        before_rot = player.transform.eulerAngles;
        ValidMove = new Vector3(0, 0, 0);
        serial = FindObjectOfType<SerialController>();


        tools = new GameObject[7];
        tools[0] = GameObject.Find("Vacuum");
        tools[1] = GameObject.Find("Roller");
        tools[2] = GameObject.Find("Broom");
        tools[3] = GameObject.Find("DustPan");
        tools[4] = GameObject.Find("Clip");
        tools[5] = GameObject.Find("Washer");
        tools[6] = GameObject.Find("Hand");

        toolPos = new Vector3[7];
        toolRot = new Quaternion[7];

        toolPos[0] = new Vector3( -1.3f, -6.4f,1f);
        toolRot[0] = Quaternion.Euler(0, 0, 0);

        toolPos[1] = new Vector3(-1.7f, -6f,  4.2f);
        toolRot[1] = Quaternion.Euler(0, 0, 0);

        toolPos[2] = new Vector3(-1.5f, -8.5f, 1.5f );
        toolRot[2] = Quaternion.Euler(-150, 0, 0);

        toolPos[3] = new Vector3(-2f, -6f, 2f);
        toolRot[3] = Quaternion.Euler(0, 0, 0);

        toolPos[4] = new Vector3(-1.8f, -5.8f, 3f);
        toolRot[4] = Quaternion.Euler(0, 0, 0);

        toolPos[5] = new Vector3(-1.8f, -5f, 2.6f);
        toolRot[5] = Quaternion.Euler(-10, 0, 0);

        toolPos[6] = new Vector3(0.5f, -7f, 0);
        toolRot[6] = Quaternion.Euler(-80, 0, 0);


        localPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(serial.x + " " + serial.y);
        if(serial.x != 0 || serial.y != 0)
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                localPos.x += (serial.x / 1000);
                localPos.y -= (serial.y / 1000);
            }
            if (transform.rotation.eulerAngles.y == 90)
            {
                localPos.z -= (serial.x / 1000);
                localPos.x -= (serial.y / 1000);
            }
            if (transform.rotation.eulerAngles.y == 180)
            {
                localPos.x -= (serial.x / 1000);
                localPos.y -= (serial.y / 1000);
            }
            if (transform.rotation.eulerAngles.y == 270)
            {
                localPos.z += (serial.x / 1000);
                localPos.y -= (serial.y / 1000);
            }

        }
        //move tool with keyboard ASDF
        if (Input.GetKey(KeyCode.A))
        {   if (transform.rotation.eulerAngles.y == 0) { localPos.x -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 90) {localPos.z += moveSpeed;}
            if (transform.rotation.eulerAngles.y == 180) { localPos.x += moveSpeed; }
            if (transform.rotation.eulerAngles.y == 270) { localPos.z -= moveSpeed; }
        }
        if (Input.GetKey(KeyCode.D))
        {   
            if (transform.rotation.eulerAngles.y == 0) { localPos.x += moveSpeed; }
            if (transform.rotation.eulerAngles.y == 90) { localPos.z -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 180) { localPos.x -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 270) { localPos.z += moveSpeed; }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.rotation.eulerAngles.y == 0) { localPos.y += moveSpeed; }
            if (transform.rotation.eulerAngles.y == 90) { localPos.x += moveSpeed; }
            if (transform.rotation.eulerAngles.y == 180) { localPos.y += moveSpeed; }
            if (transform.rotation.eulerAngles.y == 270) { localPos.y += moveSpeed; }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.rotation.eulerAngles.y == 0) { localPos.y -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 90) { localPos.x -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 180) { localPos.y -= moveSpeed; }
            if (transform.rotation.eulerAngles.y == 270) { localPos.y -= moveSpeed; }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastTool = currentTool;
            currentTool = currentTool + 1;
            if(currentTool >= tools.Length)
            {
                currentTool =0;
            }
            Toolvisible();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastTool = currentTool;
            currentTool = currentTool - 1;
            if (currentTool< 0)
            {
                currentTool = tools.Length - 1;
            }
            Toolvisible();
        }
;

        Vector3 rot_vector = player.rotation.eulerAngles;
        rot_vector.x = 0;
        Quaternion player_rotation = Quaternion.Euler(rot_vector);

        Vector3 direction = player_rotation * localPos;
        if(transform.rotation.eulerAngles.y == 90) {direction.y = 0; }//Consier only XZ plane 
        if(transform.rotation.eulerAngles.y == 0) { direction.z = 0; }
        if (transform.rotation.eulerAngles.y == 180) { direction.z = 0; }
        if (transform.rotation.eulerAngles.y == 270) { direction.x = 0; }

        Vector3 normalized = direction.normalized;
        Vector3 new_move = normalized *moveSpeed;

        //tools[currentTool].transform.RotateAround(player.transform.position, new Vector3(0,1,0) , player.transform.eulerAngles.y - before_rot.y );
        //tools[currentTool].transform.RotateAround(player.transform.position, player.right , player.transform.eulerAngles.x - before_rot.x);
        before_rot = player.transform.eulerAngles;
        //Debug.Log(localPos);
        tools[currentTool].transform.position += localPos;
        if(localPos.x !=0 || localPos.y !=0 || localPos.z != 0)
        {
            ValidMove = localPos;
            Debug.Log("Valid update " + ValidMove);
        }
        if(!CanMove && ValidMove != new Vector3(0, 0, 0))
        {
            tools[currentTool].transform.position -= ValidMove;
            Debug.Log("can not move" + ValidMove);
            //nMove = true;
        }
        localPos = new Vector3(0, 0, 0);

        
    }

    public void StopMovement()
    {
        CanMove = false;
    }

    public void EnableMovement() { CanMove = true; }

    void Toolvisible() {

        if (tools[currentTool] != null)
        {
            serial.messageListener = tools[currentTool];
            tools[currentTool].transform.localPosition = toolPos[currentTool];
            Vector3 clean_pos = tools[currentTool].transform.position;

            if (transform.rotation.eulerAngles.y == 90)
            {
                Vector3 basic_vec = new Vector3(0, 90, 0);
                Quaternion basic_rot = Quaternion.Euler(basic_vec);
                tools[currentTool].transform.rotation = basic_rot * toolRot[currentTool];
            }
                //tools[currentTool].transform.position  = new Vector3(clean_pos.x, 0, clean_pos.z); }//Consier only XZ plane 
            if (transform.rotation.eulerAngles.y == 0) {
                Vector3 basic_vec = new Vector3(0, 0, 0);
                Quaternion basic_rot = Quaternion.Euler(basic_vec);
                tools[currentTool].transform.rotation = basic_rot * toolRot[currentTool];
            }
            if (transform.rotation.eulerAngles.y == 180) {
                Vector3 basic_vec = new Vector3(0, 180, 0);
                Quaternion basic_rot = Quaternion.Euler(basic_vec);
                tools[currentTool].transform.rotation = basic_rot * toolRot[currentTool];
            }
            if (transform.rotation.eulerAngles.y == 270) {
                Vector3 basic_vec = new Vector3(0, 270, 0);
                Quaternion basic_rot = Quaternion.Euler(basic_vec);
                tools[currentTool].transform.rotation = basic_rot * toolRot[currentTool];
            }

            //tools[currentTool].transform.rotation = player.rotation * toolRot[currentTool];
        }
        if (tools[lastTool] != null)
        {
            tools[lastTool].transform.position = initPos;
        }
    }
}
