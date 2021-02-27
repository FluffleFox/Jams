using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    public GameObject rocket;
    List<GameObject> pool = new List<GameObject>();
    public Transform bazooka;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.right * 12.0f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 hitpoint = ray.origin+ray.direction * 10.0f / ray.direction.z;
            Vector3 dir = hitpoint - transform.position;
            dir.z = 0;
            float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bazooka.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
            if (pool.Count > 0)
            {
                pool[0].transform.position = transform.position + dir.normalized * 0.85f;
                pool[0].transform.rotation = bazooka.rotation;
                pool[0].SetActive(true);
                pool.Remove(pool[0]);
            }
            else
            {
                Instantiate(rocket, transform.position + dir.normalized * 0.85f, bazooka.rotation);
            }
        }
    }

    public void GetToPool(GameObject item)
    {
        pool.Add(item);
        item.SetActive(false);
    }
}
