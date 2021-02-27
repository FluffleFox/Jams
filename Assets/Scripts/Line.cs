using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer line;
    Transform player;
    Transform platform;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (platform != null)
        {
            
            line.positionCount = 2;
            Vector3[] points = new Vector3[2];
            points[0] = player.position;
            points[1] = player.position + (player.position-platform.position).normalized;
            line.SetPositions(points);
        }
    }

    public void StartDisplay(Transform newPlatform)
    {
        platform = newPlatform;
    }

    public void StopDisplay()
    {
        platform = null;
    }
}
