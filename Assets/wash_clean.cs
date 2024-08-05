using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wash_clean : MonoBehaviour
{
    public GameObject planePrefab;
    public float spawnInterval = 0.1f;
    private bool isTriggered = false;
    private bool isSpawn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Stain"))
        {
            isTriggered = true;
            Debug.Log("stain");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            isSpawn = true;
            StartCoroutine(SpawnPlane());
        }
        if (!isTriggered || Input.GetKeyUp(KeyCode.Space))
        {
            isSpawn = false;
            StopCoroutine(SpawnPlane());
        }
    }

    IEnumerator SpawnPlane()
    {
        while (isSpawn)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1.4f;
            Quaternion rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            Instantiate(planePrefab, spawnPos, rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
