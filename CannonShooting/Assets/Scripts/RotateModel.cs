

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    float rotationSpeed = 2;

    private void OnMouseDrag()
    {
        float rotY = Input.GetAxis("Mouse X") * rotationSpeed ;

        transform.RotateAround(Vector3.up, rotY * Mathf.Deg2Rad);
    }

}


