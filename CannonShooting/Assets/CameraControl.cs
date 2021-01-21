using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera MainCamera;
    private void Awake()
    {
        Shooting.ShootingStarted += ShootingStarted;
    }

    private void OnDestroy()
    {
        Shooting.ShootingStarted -= ShootingStarted;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void ShootingStarted(bool status)
    {
        if(status)
        {
            MainCamera.enabled = false;
        }
        else
        {
            MainCamera.enabled = true;
        }
    }
}
