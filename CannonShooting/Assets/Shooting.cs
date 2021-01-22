using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shooting : MonoBehaviour
{
   
    public Rigidbody CanonBullet;
    public GameObject BulletSpawnPosition;
    public int speed = 70;
    public float delay = 1.0f;
    public AudioSource audioSource;
    public AudioClip gunSound;
    public Button FireButton;
    public Text distanceText;
    public Text resultText;
    public GameObject resultPanel;

   void Start()
    {
        FireButton.onClick.AddListener(FireStart);
        audioSource = GetComponent<AudioSource>();
        DetectCollision.TargetHit += TargetHit;
        resultPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        FireButton.onClick.RemoveListener(FireStart);
        DetectCollision.TargetHit -= TargetHit;
    }

    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            FireStart();
        }*/
    }

    public void FireStart()
    {
        audioSource.PlayOneShot(gunSound, 1.0f);
        Rigidbody Bullet;
        Bullet = Instantiate(CanonBullet, BulletSpawnPosition.transform.position, Quaternion.identity) as Rigidbody;
        Vector3 rotation = Bullet.transform.rotation.eulerAngles;
        Bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        Bullet.AddForce(BulletSpawnPosition.transform.forward * speed, ForceMode.Impulse);
        StartCoroutine(DestroyAfterDelay(Bullet.gameObject, delay));
    }

     IEnumerator DestroyAfterDelay(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        CameraDelay.ShootingStarted?.Invoke(false);
        float Distance = Vector3.Distance(BulletSpawnPosition.transform.position,bullet.transform.position);
        distanceText.text = "Distance Covered  " + Distance;
        Destroy(bullet);
    }
    public void TargetHit(bool success)
    {
        if(success)
        {
            resultText.text = "Success";
            Debug.Log("Success");
        }
        else
        {
            resultText.text = "Failed! Better luck next time....";
        }
        resultPanel.SetActive(true);
        StartCoroutine(disappearText());
    }
   
    IEnumerator disappearText()
    {
        yield return new WaitForSeconds(2f);
        resultPanel.SetActive(false);
    }
  
}
