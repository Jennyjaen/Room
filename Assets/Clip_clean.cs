using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip_clean : MonoBehaviour
{

    private bool isTriggered;
    private bool isScalingDown;
    private GameObject target;
    private GameObject Clip_L;
    private GameObject Clip_R;
    // Start is called before the first frame update
    void Start()
    {
        Clip_L = transform.Find("Clip_L").gameObject;
        Clip_R = transform.Find("Clip_R").gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Trash"))
        {
            isTriggered = true;
            target = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Trash"))
        {
            isTriggered = false;
            target = null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            isScalingDown = true;
        }
        if (isScalingDown && target != null) {
            Debug.Log("open");
            Clip_L.transform.rotation = Quaternion.RotateTowards(Clip_L.transform.rotation, Quaternion.Euler(0, -15, 0), 0.3f * Time.deltaTime);
            Clip_R.transform.rotation = Quaternion.RotateTowards(Clip_R.transform.rotation, Quaternion.Euler(0, 15 , 0), 0.3f * Time.deltaTime);
        }
    }
}
