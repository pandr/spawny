using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float dist = 20.0f;

    void Update()
    {
        // FIX FOR 472
        //dist = dist + 10.0f * Input.GetAxis("Mouse ScrollWheel");
        dist = dist - 10.0f * Input.GetAxis("Mouse ScrollWheel");

        float t = 0.1f*Time.realtimeSinceStartup;

        transform.position = new Vector3(Mathf.Sin(t) * dist, 0, Mathf.Cos(t) * dist);
        transform.LookAt(Vector3.zero);
    }
}
