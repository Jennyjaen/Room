using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public Vector3 pos= new Vector3(30, 20, 10);
    private Vector3 initPos = new Vector3(0, -5, 0);
    public Transform player;
    public float moveSpeed = 0.001f;

    private Vector3 localPos;
    private GameObject[] tools;
    private Vector3[] toolPos;
    private Quaternion[] toolRot;
    private int currentTool = 0;
    private int lastTool = 5;

    void Start(){

        tools = new GameObject[8];
        tools[0] = GameObject.Find("Vacuum");
        tools[1] = GameObject.Find("Squeegee");
        tools[2] = GameObject.Find("Broom");
        tools[3] = GameObject.Find("DustPan");
        tools[4] = GameObject.Find("Clip");
        tools[5] = GameObject.Find("Mop");
        tools[6] = GameObject.Find("Washer");
        tools[7] = GameObject.Find("Hand");

        toolPos = new Vector3[8];
        toolRot = new Quaternion[8];

        toolPos[0] = new Vector3( 0.3f, -7f,3f);
        toolRot[0] = Quaternion.Euler(0, 0, 0);

        toolPos[1] = new Vector3(1, -1.7f,  0);
        toolRot[1] = Quaternion.Euler(-60, 0, 0);

        toolPos[2] = new Vector3(1, -3.5f, 0);
        toolRot[2] = Quaternion.Euler(-150, 0, 0);

        toolPos[3] = new Vector3(1, 0, 0);
        toolRot[3] = Quaternion.Euler(20, 0, 0);

        toolPos[4] = new Vector3(0.2f, -0.2f, 0);
        toolRot[4] = Quaternion.Euler(-200, 0, 0);

        toolPos[5] = new Vector3(0.5f, -0.3f, 0);
        toolRot[5] = Quaternion.Euler(-80, 0, 0);

        toolPos[6] = new Vector3(0.5f, -1f, 0.5f);
        toolRot[6] = Quaternion.Euler(0, 0, 0);

        toolPos[7] = new Vector3(0.5f, 3f, 0);
        toolRot[7] = Quaternion.Euler(120, 0, 0);

        localPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move tool with keyboard ASDF
        if (Input.GetKey(KeyCode.A))
        {
            localPos.x -= moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            localPos.x += moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            localPos.z += moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            localPos.z -= moveSpeed;
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
        Vector3 direction = player.rotation * localPos;
        direction.y = 0; //Consier only XZ plane
        Vector3 normalized = direction.normalized;
        Vector3 new_move = normalized *moveSpeed;

        tools[currentTool].transform.rotation = player.rotation * toolRot[currentTool];
        tools[currentTool].transform.localPosition += new_move;
        localPos = new Vector3(0, 0, 0);

        
    }

    void Toolvisible() {

        if (tools[currentTool] != null)
        {
            tools[currentTool].transform.localPosition = player.position + toolPos[currentTool];
            tools[currentTool].transform.rotation = player.rotation * toolRot[currentTool];
        }
        if (tools[lastTool] != null)
        {
            tools[lastTool].transform.position = initPos;
        }
    }
}
