using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectCollision : MonoBehaviour
{
    public GameObject FireworksAll;
    public static Action<bool> TargetHit;
    public bool target = false;
  
    private void OnCollisionEnter(Collision other)
    {
        if((other.gameObject.tag == "Ground")&&(target == false))
        {
            Debug.Log("Collided in ground");
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            TargetHit?.Invoke(false);
        }
        
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("Target Hit");
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            target = true;
            TargetHit?.Invoke(true);           
        }

    }

}
