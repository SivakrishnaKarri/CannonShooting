using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shooting : MonoBehaviour
{
    public static Action<bool> ShootingStarted;
    public Rigidbody CanonBullet;
    public GameObject BulletSpawnPosition;
    public int speed = 70;
    public float delay = 1.0f;
    


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootingStarted?.Invoke(true);
            Rigidbody clone;
           // clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone = Instantiate(CanonBullet, BulletSpawnPosition.transform.position,Quaternion.identity) as Rigidbody;
            //clone.velocity = transform.TransformDirection(Vector3.forward * -0.01f);
            Vector3 rotation = clone.transform.rotation.eulerAngles;
            clone.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            clone.AddForce(BulletSpawnPosition.transform.forward * speed,ForceMode.Impulse);
            StartCoroutine(DestroyAfterDelay(clone.gameObject,delay));
        }
    }

     IEnumerator DestroyAfterDelay(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        ShootingStarted?.Invoke(false);
        Destroy(bullet);
    }

  
}
