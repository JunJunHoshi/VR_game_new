using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]

public class redBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] private float timer = 3.0f;
    [SerializeField] private ParticleSystem explore;
    [SerializeField] private ParticleSystem ring;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
        var velocity = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>(); //rigidbodyコンポーネントを取得

        rigidbody.AddForce(velocity, ForceMode.VelocityChange); //velocityに相当した力を加える
        
        Invoke("Explore",timer);
    }

    void Explore()
    {
        Instantiate(explore, transform.position, transform.rotation);
        Instantiate(ring, transform.position, transform.rotation);
        SphereCollider size = GetComponent<SphereCollider>();
        size.radius += 9.0f;

    }

    void OnTriggerEnter(Collider other)
    {
        //衝突したらOnHitBulletという関数を起動
        other.SendMessage("OnHitBullet");

        //着弾点に演出も追加
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);
        
    }
}