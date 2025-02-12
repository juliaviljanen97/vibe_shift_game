using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Pelaajan sijainti
    public float smoothSpeed = 0.125f; // Kameran pehmeys
    public Vector3 offset; // Kameran etäisyys pelaajasta

    private Vector2 minBounds; // Kamera-alueen rajat
    private Vector2 maxBounds;
    private float cameraHalfWidth;
    private float cameraHalfHeight;

    void Start()
    {
        // Etsi taustakuva ja laske rajat
        SpriteRenderer backgroundRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        if (backgroundRenderer != null)
        {
            float backgroundWidth = backgroundRenderer.bounds.size.x;
            float backgroundHeight = backgroundRenderer.bounds.size.y;

            // Lasketaan kameran koon perusteella rajat
            Camera cam = Camera.main;
            cameraHalfHeight = cam.orthographicSize;
            cameraHalfWidth = cam.aspect * cameraHalfHeight;

            minBounds = new Vector2(-backgroundWidth / 2 + cameraHalfWidth, -backgroundHeight / 2 + cameraHalfHeight);
            maxBounds = new Vector2(backgroundWidth / 2 - cameraHalfWidth, backgroundHeight / 2 - cameraHalfHeight);
        }
    }

    void LateUpdate()
    {
        if (player == null) return; // Varmistetaan, että pelaaja on määritetty

        Vector3 desiredPosition = player.position + offset; // Haluttu sijainti
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Pehmeä liike

        // Rajoitetaan kameran liike pelialueen sisään
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);
        smoothedPosition.z = transform.position.z; // Z-arvo ei muutu 2D-pelissä

        transform.position = smoothedPosition;
    }
}
