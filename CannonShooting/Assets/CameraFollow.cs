using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset;
    //public float cameraHeight = 20.0f;
    /*
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = Target.position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(Target);
    }*/
    void Update()
    {
        /* Vector3 pos = player.transform.position;
         pos.z += cameraHeight;
         transform.position = pos;*/
        //  transform.LookAt(player.transform);
        if (player != null)
            transform.position = player.position + Offset;
    }
}
