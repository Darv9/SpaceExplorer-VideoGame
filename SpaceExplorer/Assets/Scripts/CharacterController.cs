using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb;

    /*[SerializeField]
    Animator animator;*/

    [Header("Move System")]
    [SerializeField]
    float speed = 4.0F;

    [SerializeField]
    bool isFacingRight = true;

    [SerializeField]
    float jumpTime = 0.05F;

    [SerializeField]
    float jumpMultiplier = 1.5F;

    [SerializeField]
    float fallMultiplier = 0.5F;

    bool wasFacingRight;
    Vector2 move;

    bool isJumpPressed;
    float jumpCounter;

    Vector2 reverseGravity;

    bool grounded;

    [Header("Jump System")]
    [SerializeField]
    float jumpPower = 4.0F;

    [SerializeField]
    LayerMask whatIsGround;

    [SerializeField]
    Transform groundCheck;

    void Start()
    {
        wasFacingRight = isFacingRight;
        reverseGravity = new Vector2(0.0F, -Physics2D.gravity.y);


        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        grounded = isGrounded();
    }



    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0F);

        if (Input.GetButtonDown("Jump"))
        {
            //Permite el salto solamente cuando el persona esta tocando el piso
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpCounter = 0.0F;
                isJumpPressed = true;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumpPressed = false;
            jumpCounter = 0.0F;

            if (rb.velocity.y > 0.0F)
            {
                //Reduce el salto en un 60%
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.06F);
            }
        }

        if (rb.velocity.y > 0.0F)
        {
            if (isJumpPressed)
            {

                //Incrementa el salto por un factor multiplicativo de manera uniforme entre frames
                rb.velocity += reverseGravity * jumpMultiplier * Time.deltaTime;

                jumpCounter += Time.deltaTime;
                if (jumpCounter > jumpTime)
                {
                    isJumpPressed = false;
                    jumpCounter = 0;

                    //Reduce el salto en un 60%
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.06F);
                }
            }
        }

        if (rb.velocity.y < 0.0F)
        {
            //Para que caiga siempre con menos velocidad que el ascenso, generando el efecto de gravedad
            rb.velocity -= reverseGravity * fallMultiplier * Time.deltaTime;
        }

        if (!grounded)
        {

            //Verifica si esta tocando el piso para poder volver a saltar
            bool IsGrounded = isGrounded();
            if (grounded != IsGrounded)
            {
                grounded = IsGrounded;
                //animator.SetFloat("power", 0.0F);
                //animator.SetTrigger("grounded");
            }
        }
    }



    void FixedUpdate()
    {
        if (rb.velocity.y > 0.0F)
        {
            /*if (animator.GetFloat("power") != 1.0F)
            {
                animator.SetFloat("power", 1.0F);
            }*/
            grounded = false;

        }
        else if (rb.velocity.y < 0.0F)
        {
            /* if (animator.GetFloat("power") != -1.0F)
             {
                 animator.SetFloat("power", -1.0F);
             }*/
            grounded = false;
        }
        else
        {
            /*if (animator.GetFloat("speed") != Mathf.Abs(move.x))
            {
                animator.SetFloat("speed", Mathf.Abs(move.x));
            }*/
            //animator.ResetTrigger("grounded");
        }

        move.y = rb.velocity.y;
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        Flip();
    }



    void Flip()
    {
        if (move.x != 0.0F)
        {
            // Calcula si el personaje esta mirando hacia la derecha o la izquierda
            bool facingRight =
                move.x > 0.0F;



            // Si ha cambiado la vista de derecha a izquierda o viceversa
            if (wasFacingRight != facingRight)
            {
                wasFacingRight = facingRight;



                // Gira el personaje en su eje X
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
        }
    }
    bool isGrounded()
    {
        return
            Physics2D.OverlapCapsule
            (
                groundCheck.position,
                new Vector2(0.41F, 0.21F), CapsuleDirection2D.Horizontal,
                0.0F, whatIsGround);
    }
}
