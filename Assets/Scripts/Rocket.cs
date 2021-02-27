using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float explosionForce = 20;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * 20.0f, Space.World);
        if (Vector3.Distance(transform.position, player.transform.position) > 200.0f)
        {
            player.GetComponent<PlayerV2>().GetToPool(gameObject);
            transform.position = Vector3.up * 5000.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = player.transform.position - transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(direction.normalized * explosionForce / (1 + (Vector2.SqrMagnitude(direction)* Vector2.SqrMagnitude(direction))));
        player.GetComponent<PlayerV2>().GetToPool(gameObject);

        //Pierdut tu Particle
        if (collision.gameObject.GetComponent<PlatformOver>() != null)
        { collision.gameObject.GetComponent<PlatformOver>().explode(); }

        transform.position = Vector3.up * 5000.0f;
    }
}
