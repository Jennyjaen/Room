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
    }
    void OnTriggerExit(Collider col)
    {
        isTriggered = false;
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
