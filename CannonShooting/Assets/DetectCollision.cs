using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject FireworksAll;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Collided");
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("Target Hit");
            GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
    }

}
