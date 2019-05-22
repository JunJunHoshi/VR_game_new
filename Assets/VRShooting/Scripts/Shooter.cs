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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
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
