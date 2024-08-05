using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Bed"))
        {
            Vector3 currentPos = transform.position;
            currentPos.y =1f;
            transform.position = currentPos;
        }
        if (col.CompareTag("Hamper"))
        {
            Vector3 currentPos = transform.position;
            currentPos.y = 1.6f;
            transform.position = currentPos;

        }
    }
    void OnTriggerExit(Collider col) { 
        
        if (col.CompareTag("Bed") || col.CompareTag("Hamper"))
        {
            Vector3 currentPos = transform.position;
            currentPos.y = 0f;
            transform.position = currentPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
