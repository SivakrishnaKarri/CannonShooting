using UnityEngine;
using System;

public class DetectCollision : MonoBehaviour
{
    public static Action<bool> TargetHit;
    [SerializeField] private GameObject FireworksAll;   
    private bool target = false;
  
    private void OnCollisionEnter(Collision other)
    {
        if((other.gameObject.tag == "Ground")&&(target == false))
        {
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            TargetHit?.Invoke(false);
        }
        
        if (other.gameObject.tag == "Target")
        {
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            target = true;
            TargetHit?.Invoke(true);           
        }
    }

}
