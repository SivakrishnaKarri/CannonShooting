using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraDelay : MonoBehaviour
{
    public static Action<bool> ShootingStarted;
    public float delay = 0.3f;
    public Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam.enabled = false;
        StartCoroutine(ActiveCameraDelay(delay));
    }
    IEnumerator ActiveCameraDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShootingStarted?.Invoke(true);
        cam.enabled = true;
    }
   
}
