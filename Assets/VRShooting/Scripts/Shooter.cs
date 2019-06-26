using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject redBullet;
    [SerializeField] private GameObject bigBullet;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] ParticleSystem gunParticle1;
    [SerializeField] ParticleSystem gunParticle2;
    [SerializeField] ParticleSystem gunParticle3;
    [SerializeField] AudioSource gunAudioSource;

    [SerializeField] private float bulletInterval = 8.5f;

    
    // 球の発射
    void OnEnable()
    {
        //2秒後に球を3－3－7拍子で発射させる。
        InvokeRepeating("Shoot2", 2.0f, bulletInterval);
        InvokeRepeating("Shoot2", 2.5f, bulletInterval);
        InvokeRepeating("Shoot2", 3.0f, bulletInterval);
        
        InvokeRepeating("Shoot1", 4.0f, bulletInterval);
        InvokeRepeating("Shoot1", 4.5f, bulletInterval);
        InvokeRepeating("Shoot1", 5.0f, bulletInterval);
        
        InvokeRepeating("Shoot3", 6.0f, bulletInterval);
        InvokeRepeating("Shoot3", 6.5f, bulletInterval);
        InvokeRepeating("Shoot3", 7.0f, bulletInterval);
        InvokeRepeating("Shoot3", 7.5f, bulletInterval);
        InvokeRepeating("Shoot3", 8.0f, bulletInterval);
        InvokeRepeating("Shoot3", 8.5f, bulletInterval);
        InvokeRepeating("Shoot3", 9.0f, bulletInterval);
    }

    private void OnDisable()
    {
        //shoot処理を停止する
        CancelInvoke("Shoot1");
        CancelInvoke("Shoot2");
        CancelInvoke("Shoot3");
    }

    void Shoot1(){
        //プレハブをもとにシーンに球を複製
        Instantiate(redBullet, gunBarrelEnd.position, gunBarrelEnd.rotation);
        //発射演出を再生
        gunParticle1.Play();
        //発射音声を再生
        gunAudioSource.Play();
    }
    
    void Shoot2(){
        //プレハブをもとにシーンに球を複製
        Instantiate(bigBullet, gunBarrelEnd.position, gunBarrelEnd.rotation);
        //発射演出を再生
        gunParticle2.Play();
        //発射音声を再生
        gunAudioSource.Play();
    }
    
    void Shoot3(){
        //プレハブをもとにシーンに球を複製
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);
        //発射演出を再生
        gunParticle3.Play();
        //発射音声を再生
        gunAudioSource.Play();
    }
   
}
