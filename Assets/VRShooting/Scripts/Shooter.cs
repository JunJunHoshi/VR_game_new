using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] ParticleSystem gunParticle;
    [SerializeField] AudioSource gunAudioSource;

    [SerializeField] private float bulletInterval = 0.5f;
    // 球の発射
    void OnEnable()
    {
        //2秒後に球を連続で発射させる。
        InvokeRepeating("Shoot",2.0f,bulletInterval);
    }

    private void OnDisable()
    {
        //shoot処理を停止する
        CancelInvoke("Shoot");
    }

    void Shoot(){
        //プレハブをもとにシーンに球を複製
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);
        //発射演出を再生
        gunParticle.Play();
        //発射音声を再生
        gunAudioSource.Play();
}
}
