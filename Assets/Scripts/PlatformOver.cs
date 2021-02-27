using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOver : MonoBehaviour
{
    public GameObject particles;
    public float explosionForce = 15.0f;

    public void explode()
    {
        GameObject GO = (GameObject)Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(GO, 3);
        Destroy(gameObject);
    }
}
