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

    //librerias para lanzar objetos
    public GameObject objetoPrefab;
    public float fuerzaLanzamiento = 8f;
    public float fuerzaArriba = 2f;

    public bool puedeLanzarCupcakes = false;

    public GameObject cupcakeRosadoPrefab;
    public GameObject cupcakeVerdePrefab;
    public GameObject cupcakeAzulPrefab;

    private GameObject cupcakeActualPrefab;
    public Transform puntoLanzamiento;
    public float velocidadCupcake = 8f;

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

        //lanzar objetos
        if (Input.GetKeyDown(KeyCode.E) && puedeLanzarCupcakes)
        {
            LanzarCupcake();
        }

    }

    public void ActivarCupcakeRosado()
    {
        puedeLanzarCupcakes = true;
        cupcakeActualPrefab = cupcakeRosadoPrefab;
    }

    public void ActivarCupcakeVerde()
    {
        puedeLanzarCupcakes = true;
        cupcakeActualPrefab = cupcakeVerdePrefab;
    }

    public void ActivarCupcakeAzul()
    {
        puedeLanzarCupcakes = true;
        cupcakeActualPrefab = cupcakeAzulPrefab;
    }

    void LanzarCupcake()
    {
        if (cupcakeActualPrefab == null) return;

        GameObject cupcake = Instantiate(
            cupcakeActualPrefab,
            puntoLanzamiento.position,
            Quaternion.identity
        );

        Rigidbody2D rbCupcake = cupcake.GetComponent<Rigidbody2D>();

        float direccion = transform.localScale.x;

        rbCupcake.gravityScale = 0;
        rbCupcake.linearVelocity = new Vector2(direccion * velocidadCupcake, 0f);

        Destroy(cupcake, 3f);
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

