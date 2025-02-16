using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;


    public PaintSpawner paintSpawner;
    public Vector2 slashSpawnOffset;
    public Color slashColor;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isAttacking = false;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
        UpdateFallingState();
    }

    void HandleMovement()
    {
        if (isAttacking) return; // Prevents animation flicker, but doesn't stop movement

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");

            // No movement restriction, attack plays independently
            paintSpawner.SpawnObject(slashSpawnOffset,slashColor);
            // Unlock movement after attack animation ends
            Invoke("EndAttack", 0.5f); // Adjust based on attack animation length
        }
    }

    void UpdateFallingState()
    {
        if (!isGrounded && rb.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
            animator.SetBool("Falling", false);
        }
    }

    void EndAttack()
    {
        isAttacking = false;
        animator.ResetTrigger("Attack");
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
