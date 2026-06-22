using UnityEngine;

public class playercircus : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb2D;
    private float move;

    public float jumpForce = 4f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    private Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        //saber saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }

        animator.SetFloat("Speed", Mathf.Abs(move));

        //para saber si esta en el suelo o no
        animator.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);

        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius,groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}

