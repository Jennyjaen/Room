using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private GameObject target;
    private bool isTriggered = false;
    private bool isScalingDown = false;
    private float scaleDown = 10f;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Trash")) 
        {
            target = col.gameObject;
            isTriggered = true;
        }
        if (col.CompareTag("Bed"))
        {
            Debug.Log("Bed");
            Vector3 currentPos = transform.position;
            currentPos.y = 1.2f;
            transform.position = currentPos;
        }
        if (col.CompareTag("Hamper"))
        {
            Debug.Log("Hamper");
            Vector3 currentPos = transform.position;
            currentPos.y = 1.8f;
            transform.position = currentPos;

        }
    }
    void OnTriggerExit(Collider col)
    {
        isTriggered = false;
        if (col.CompareTag("Bed") || col.CompareTag("Hamper"))
        {
            Vector3 currentPos = transform.position;
            currentPos.y = 0.2f;
            transform.position = currentPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            isScalingDown = true;
        }

        if (isScalingDown && target != null)
        {
            target.transform.localScale = Vector3.Lerp(target.transform.localScale, Vector3.zero, scaleDown * Time.deltaTime);

            if (target.transform.localScale.magnitude < 0.01f)
            {
                target.transform.localScale = Vector3.zero;
                isScalingDown = false;
            }
        }
    }
}
