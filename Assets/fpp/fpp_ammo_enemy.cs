using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_ammo_enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int j;
    public int LifeExpectancy;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity=transform.up*speed;
        j++;
        if(j>LifeExpectancy)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag=="Player")
        {
            Debug.Log("Player was hit");
        }
        if(hit.isTrigger==false)
        {
            Destroy(gameObject);
        }
    }
}
