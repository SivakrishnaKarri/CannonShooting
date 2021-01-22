using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shooting : MonoBehaviour
{
   
    [SerializeField] private Rigidbody canonBullet;
    [SerializeField] private GameObject bulletSpawnPosition;
    [SerializeField] private int speed = 70;
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gunSound;
    [SerializeField] private Button FireButton;
    [SerializeField] private Text distanceText;
    [SerializeField] private Text resultText;
    [SerializeField] private GameObject resultPanel;
    

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
      /*  if (Input.GetButtonDown("Fire1"))
        {
            FireStart();
        }
        */
    }

    public void FireStart()
    {
        audioSource.PlayOneShot(gunSound, 1.0f);
        Rigidbody Bullet;
        Bullet = Instantiate(canonBullet, bulletSpawnPosition.transform.position, Quaternion.identity) as Rigidbody;
        Vector3 rotation = Bullet.transform.rotation.eulerAngles;
        Bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        Bullet.AddForce(bulletSpawnPosition.transform.forward * speed, ForceMode.Impulse);
        StartCoroutine(DestroyAfterDelay(Bullet.gameObject, delay));
    }

     IEnumerator DestroyAfterDelay(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        CameraDelay.ShootingStarted?.Invoke(false);
        float Distance = Vector3.Distance(bulletSpawnPosition.transform.position,bullet.transform.position);
        distanceText.text = "Distance Covered  :" + Distance;
        Destroy(bullet);
    }
    public void TargetHit(bool success)
    {
        if(success)
        {
            resultText.text = "Success";
        }
        else
        {
            resultText.text = "Failed! Better luck next time....";
        }
        resultPanel.SetActive(true);
        StartCoroutine(DisappearText());
    }
   
    IEnumerator DisappearText()
    {
        yield return new WaitForSeconds(2f);
        resultPanel.SetActive(false);
    }
  
}
