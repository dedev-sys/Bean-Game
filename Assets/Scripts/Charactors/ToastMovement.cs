using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastMovement : MonoBehaviour
{

    float toastSpeed = 2f;
    float toastHeight = 0.3f;

    void Update()
    {
        Vector3 pos = transform.position;
        float newY = (Mathf.Sin(Time.time * toastSpeed) * toastHeight)+1;
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}