using UnityEngine;

public class BazookaModelUpdate : MonoBehaviour
{
    PlayerMovement movement;
    Rigidbody2D rb;
    void Start()
    {
        movement = transform.parent.gameObject.GetComponent<PlayerMovement>();
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.currentPlatform != null)
        {
            Vector2 velocity = movement.currentPlatform.position - transform.parent.position;
            float rotation = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
        else
        {
            Vector2 velocity = rb.velocity;
            float rotation = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
    }
}
