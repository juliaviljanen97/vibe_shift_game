using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Pelaajan sijainti
    public float smoothSpeed = 0.125f; // Kameran pehmeys
    public Vector3 offset; // Kameran etäisyys pelaajasta

    void LateUpdate()
    {
        if (player == null) return; // Jos pelaajaa ei ole määritetty, ei tehdä mitään

        Vector3 desiredPosition = player.position + offset; // Haluttu sijainti
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Pehmeä liike
        transform.position = smoothedPosition;
    }
}