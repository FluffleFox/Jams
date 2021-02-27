using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform currentPlatform;
    Rigidbody2D rb;
    public float maxSpeed = 5.0f;
    float explosionForce;
    public Line line;
    //CustomPhycics jumpClass;
    public RandomMapGenerator map;
    public AudioClip[] clips;
    public AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // jumpClass = GetComponent<CustomPhycics>();
    }
    void Update()
    {
        //if (rb.velocity.x < maxSpeed) { rb.AddForce(Vector2.right * 50.0f); }
        if(Mathf.Abs(Input.GetAxis("Horizontal"))>0.1f && currentPlatform!=null)
        { transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, Space.World); }
        if (Input.GetMouseButtonDown(0) && currentPlatform != null)
        {
            rb.velocity+=(Vector2)(transform.position - currentPlatform.position).normalized * explosionForce/Limited();
            //rb.AddForce((transform.position - currentPlatform.position) * explosionForce, ForceMode2D.Impulse);
            //jumpClass.Jump(transform.position - currentPlatform.position);
            currentPlatform.gameObject.GetComponent<PlatformOver>().explode();
            source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            currentPlatform = null;
            line.StopDisplay();
        }
        rb.AddTorque(-2);

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(-3.75f, 2.75f, 0);
            map.Generate();
        }
    }

    float Limited()
    {
        return Vector2.SqrMagnitude(rb.velocity)*0.01f + 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentPlatform = collision.transform;
        line.StartDisplay(currentPlatform);
        explosionForce = currentPlatform.gameObject.GetComponent<PlatformOver>().explosionForce;
       // jumpClass.StopJump();
    }


}
