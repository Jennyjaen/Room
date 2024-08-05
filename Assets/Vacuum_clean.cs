using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum_clean : MonoBehaviour
{

    private GameObject target;
    private bool isTriggered = false;
    public float move_x = 0.01f;
    public float move_y = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Trash"))
        {
            target = col.gameObject;
            isTriggered = true;
            Debug.Log("Trash");
        }
      
    }
    void OnTriggerExit(Collider col)
    {
        isTriggered = false;
        target = null;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered && Input.GetKey(KeyCode.Space))
        {
            Vector3 newPosition = target.transform.position;
            Debug.Log(newPosition);
            newPosition.x -= move_x;
            newPosition.y -= move_y;
            target.transform.position = newPosition;
        }
    }
}
