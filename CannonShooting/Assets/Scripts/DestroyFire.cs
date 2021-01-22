using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyFire : MonoBehaviour
{
    public float Delay = 3;
   
    void Start()
    {
        StartCoroutine(destroyAferDelay(Delay));
    }

   IEnumerator destroyAferDelay(float Delay )
    {
        yield return new WaitForSeconds(Delay);
        Destroy(this.gameObject);
    }
   
}
