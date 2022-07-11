﻿using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Clase con los atributos y conportamientos del personaje.
/// </summary>
public class Player : MonoBehaviour {

#region Variables
    private Rigidbody2D rb; //Rigidbody
    private Animator anim; // Animator
    private bool isGrounded; // Checks if is grounded is true or false
    private float CoyoteCounter; // To keep track of the coyotetime
    private float jumpBufferCount; // To keep track of the jumpBuffer
    private float MoveDirection; // Defines move input in update
    private ParticleSystem.EmissionModule footEmission; // ParticleSystem emission
    private bool wasOnGround; // Detection to validade VFX 
    private float vertical; // Vertical input in the ladder
    private bool isLadder; // Checks if its a ladder
    private bool isClimbing; // Checks if the player is already Climbing

    public int vidaplayer;
    public GameObject corazon;
    public RectTransform posisionprimercorazon;
    public int cantidadcorazon;
    public Canvas canvas;
    public int offset;

    [Header("PlayerMovement")]
    [SerializeField]  float moveSpeed; // Moves the player

    [Header("PlayerJump")]
    [SerializeField] float jumpForce; // Jumps the player
    [SerializeField]  float CoyoteTime = .2f; // Time after falling to press jump button
    [SerializeField]  float jumpBufferLength = .1f; // How long we want it to last
    [SerializeField]  LayerMask whatIsGround; // Defines what player collides in order to jump
    [SerializeField]  Transform groundCheckPoint; // Bridge between player and groundcheck

    [Header("LadderClimb")]
    [SerializeField] private float speed = 8f; //Speed that the player climbs the ladder
   
    [Header("VFX")]
    [SerializeField]  ParticleSystem footsteps; // Emites the footsteps vfx
    [SerializeField]  ParticleSystem impactEffect; // Emites the impactEffect vfx

    [Header("PlayerSprite")]
    [SerializeField]  SpriteRenderer playerSR; // Player SpriteRenderer
#endregion

#region voids
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        footEmission = footsteps.emission;

        Transform poscorazon = posisionprimercorazon;

        for (var i = 0; i < cantidadcorazon; i++)
        {
            GameObject newcorazon = Instantiate(corazon, poscorazon.position, Quaternion.identity);
            newcorazon.transform.parent = canvas.transform;
            poscorazon.position = new Vector2(poscorazon.position.x + offset, poscorazon.position.y);
        }

    }

    void Update() {
        MoveDirection = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxis("Vertical"); 

        ClimbLadder();
        CoyoteJump();
        JumpBuffer();
        Jumping();
        VFX();

        if (vidaplayer <=0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        ///Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .1f, whatIsGround);

        Move();
        LadderGravity();
    }
#endregion

#region Move
/// <summary>
/// Metodo de movimiento del personaje
/// </summary>
    void Move() {
        // Move horizontally
        rb.velocity = new Vector2(MoveDirection * moveSpeed, rb.velocity.y);

        // Flip the player
        if(MoveDirection > 0) {
            playerSR.flipX = false;
        } else if(MoveDirection < 0) {
            playerSR.flipX = true;
        }

        anim.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
    }
/// <summary>
/// Metodo de subida por las ecaleras
/// </summary>
    void ClimbLadder() {
        // Checks for the vertical input and if true player will climb
        if(isLadder && Mathf.Abs(vertical) > 0f) {
            isClimbing = true;
        }
    }
/// <summary>
/// Cuando el personaje este trepando la gravedad del personaje cambia a 0
/// </summary>
    void LadderGravity() {
        if (isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        } else {
            rb.gravityScale = 2.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ladder")) {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Ladder")) {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform") {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Platform") {
            transform.parent = null;
        }
    }
#endregion

#region Jump
/// <summary>
/// Metodo de salto del personaje
/// </summary>
    void CoyoteJump() {
        // Coyote jump
        if(isGrounded) { 
            CoyoteCounter = CoyoteTime;
            anim.SetBool("Jump", true);
        } else {
            CoyoteCounter -= Time.deltaTime;
        }
    }
/// <summary>
/// medodo que no permite el salto en el aire
/// </summary>
    void JumpBuffer() {
         // Jump buffer
        if(Input.GetButtonDown("Jump")) {
            jumpBufferCount = jumpBufferLength;
            anim.SetBool("Jump", true);
        } else {
            jumpBufferCount -= Time.deltaTime;
        }
 
        // Jump in the air
        if(jumpBufferCount >= 0 && CoyoteCounter > 0f) {
            anim.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCount = 0; // So we don't keep jumping in the air
            AudioManager.instance.PlaySFX(2);
        }
    }
/// <summary>
/// metodo de salto alto
/// </summary>
/// <remarks>permite un salto alto manteniendo 
/// presionado la tecla designada</remarks>
    void Jumping() {
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            CoyoteCounter = -1; // para prebenir el doble salto
        }
        anim.SetBool("Jump", !isGrounded);
        anim.SetFloat("ySpeed", rb.velocity.y);
    }
#endregion    

#region VFX
/// <summary>
/// Metodo que muestra la animacion de pasos y de impacto
/// </summary>
    void VFX() {
        if(MoveDirection != 0 && isGrounded) {
            footEmission.rateOverTime = 35f;
        } else {
            footEmission.rateOverTime = 0f;
        }

        if(!wasOnGround && isGrounded) {
            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();
            AudioManager.instance.PlaySFX(3);
        }

        wasOnGround = isGrounded;
    }
#endregion


}