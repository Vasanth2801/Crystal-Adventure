using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings for the Game")]
    [SerializeField] private float speed = 350f;
    [SerializeField] private float jumpForce = 150f;
    [SerializeField] private int facingDirection = 1;

    [Header("Shooting Settings for the Player")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private float swordForce = 15f;

    [Header("GroundCheck Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [Header("Inputs")]
    [SerializeField] private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal") * Time.deltaTime;

        Jump();

        if(moveInput > 0 && transform.localScale.x < 0 || moveInput < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        HandleAnimations();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * Time.deltaTime);
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y,transform.localScale.z);
    }

    void HandleAnimations()
    {
        animator.SetFloat("Speed",Mathf.Abs(moveInput));
        animator.SetBool("isJumping", rb.linearVelocity.y > 0.1);
    }
}