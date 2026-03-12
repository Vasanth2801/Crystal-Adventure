using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings for the Game")]
    [SerializeField] private float speed = 350f;
    [SerializeField] private float jumpForce = 150f;
    [SerializeField] private int facingDirection = 1;

    [Header("GroundCheck Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;

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

        Attack();

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

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D hit in hitEnemies)
            {
                Debug.Log("Attacking the Player");
            }
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