using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broom_clean : MonoBehaviour
{
    private bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("h");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Stain"))
        {
            isTriggered = true;
            Debug.Log("hi");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Stain") && isTriggered)
        {
            Debug.Log("ho");
            isTriggered = false;
            Renderer spriteRenderer =col.GetComponent<Renderer>();

            if (spriteRenderer != null)
            {
                if (spriteRenderer.material.HasProperty("_Color"))
                {
                    Color color = spriteRenderer.material.color;
                    float alpha = color.a - 0.2f;
                    if(alpha < 0) { alpha = 0; }
                    color.a = alpha;
                    spriteRenderer.material.SetColor("_Color", color);
                    Debug.Log("found oolor: "+ color);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
