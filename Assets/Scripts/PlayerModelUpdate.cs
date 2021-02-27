using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelUpdate : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.x >= 0.0f)
        {
            float rotation = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
        else
        {
            float rotation = Mathf.Atan2(velocity.y, -velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, rotation));
        }
    }
}
