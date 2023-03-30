using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target; // Objek yang ingin diikuti
    public Vector3 offset; // Jarak antara objek dan kamera
    public float smoothSpeed = 0.125f; // Kekuatan smoothing

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Mengatur posisi kamera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Menghaluskan pergerakan kamera
        transform.position = smoothedPosition; // Menetapkan posisi kamera
        transform.LookAt(target); // Menatap objek yang diikuti
    }
}
