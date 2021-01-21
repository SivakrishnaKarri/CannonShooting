using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Rigidbody CanonBullet;
    public GameObject BulletSpawnPosition;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
           // clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone = Instantiate(CanonBullet, BulletSpawnPosition.transform.position,Quaternion.identity) as Rigidbody;
            //clone.velocity = transform.TransformDirection(Vector3.forward * -0.01f);
            Vector3 rotation = clone.transform.rotation.eulerAngles;
            clone.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            clone.AddForce(BulletSpawnPosition.transform.forward * 200,ForceMode.Impulse); ;
        }
    }
}
