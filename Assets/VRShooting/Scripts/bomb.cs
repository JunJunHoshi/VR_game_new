using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]


public class bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem explode;
   
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "forbomb")
        {
            Instantiate(explode, transform.position, transform.rotation);
            SphereCollider size = GetComponent<SphereCollider>();
            size.radius += 100.0f;
            Invoke("destroy", 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("OnHitBomb");
        
    }

    void destroy()
    {
        Destroy(gameObject);
    }


}
