using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomMapGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject speedPlatform;
    void Start()
    {
        Generate();
    }
    public void Generate() 
    { 
        float currentx = 0;
        float lastY = 0;
        for(int i=0; i<10000; i++)
        {
            Instantiate(((Random.Range(0,100)>10)?platform:speedPlatform), new Vector3(currentx, Random.Range(Mathf.Max(-5.0f, lastY - 2), Mathf.Min(5.0f, lastY + 2))+5.0f, Random.Range(-1.0f,1.0f)), Quaternion.identity);
            Instantiate(((Random.Range(0, 100) > 10) ? platform : speedPlatform), new Vector3(currentx, Random.Range(Mathf.Max(-5.0f, lastY - 2), Mathf.Min(5.0f, lastY + 2))-5.0f, Random.Range(-1.0f, 1.0f)), Quaternion.identity);
            currentx += Random.Range(0.25f, 0.75f);
            //if (currentx > 1000) break;
        }
    }
}
