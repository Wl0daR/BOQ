using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpp_trampoline : MonoBehaviour
{
    // Start is called before the first frame update
    private float bounce = 22f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
        }
    }

}
