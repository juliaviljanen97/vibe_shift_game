using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Liike Inputista (WASD / Nuolet)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
    }

   /* void FixedUpdate()
    {
        // Liikuttaa pelaajaa
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }*/

    void FixedUpdate()
{
    // Use velocity instead of MovePosition
    rb.linearVelocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
}

}
