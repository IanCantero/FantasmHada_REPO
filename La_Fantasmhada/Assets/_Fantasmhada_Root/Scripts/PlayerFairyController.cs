using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFairtyController : MonoBehaviour
{
    [Header("Movement and Jump Configuration")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight; //Define la orientacion del personaje
    [SerializeField] Transform groundCheck; //Posición del detector del suelo
    [SerializeField] float groundCheckRadius; //Define el radio del circulo de suelo
    [SerializeField] LayerMask groundLayer; //Define la capa que puede tocar el detector de suelo

 

    //Variables de referencia general
    Rigidbody2D playerRb; //Almacén del rigidbody del player
    Animator anim; //Almacén del controlador de animaciones del player
    PlayerInput input; //Almacén del controlador de inputs del player
    Vector2 moveInput; //Almacén del valor de los botones de movimiento

    private void Awake()
    {
         playerRb = GetComponent<Rigidbody2D>(); //Autorreferenciar un componente propio
         anim = GetComponent<Animator>();
         input = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Lógica de deteccion de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Lógica del flip del personaje
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
        //Lógica de las animaciones
        AnimationManagement();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.linearVelocity = new Vector2(moveInput.x * speed, playerRb.linearVelocity.y);
    }
    
    void Flip()
    {
        Vector3 currentScale = transform.localScale; //Almacén temporal de la escala del objeto
        currentScale.x *= -1; //Invertir el valor de X
        transform.localScale = currentScale; //Le devolvemos la escala al objeto con el valor x inverso
        isFacingRight = !isFacingRight; //Decirle al bool que cambie el valor al contrarioz
    }
    void Jump()
    {
      
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    void Interact()
    {
        anim.SetTrigger("Interact");
    }

    void AnimationManagement()
    {
        //Acción para gestionar los cambios de animación
          anim.SetBool("Jump", !isGrounded);
        if (moveInput.x != 0)
        {

            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);

    }

    #region Input Methods

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Interact();
    }


    #endregion  
}
