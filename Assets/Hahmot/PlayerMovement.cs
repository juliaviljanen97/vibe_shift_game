using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Liike Inputista (WASD / Nuolet)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Testataan tuleva sijainti ennen siirtoa
        Vector2 newPosition = rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime;
        
        // Katsotaan, onko siinä este
        Collider2D obstacle = Physics2D.OverlapCircle(newPosition, 0.2f, LayerMask.GetMask("Obstacle"));

        // Jos ei osuta esteeseen, liikutaan normaalisti
        if (obstacle == null)
        {
            rb.MovePosition(newPosition);
        }
    }
}
