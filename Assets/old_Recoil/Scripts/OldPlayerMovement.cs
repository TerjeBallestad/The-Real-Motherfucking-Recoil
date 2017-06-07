using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed, jumpForce, maxSpeed;
    public static bool facingRight, canJump;
    public bool grounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float horizontalSpeed = 0f;
    public float horizontalSpeedLerp = 0.6f;
    public float boxCastDistance = 0.4f;

    [HideInInspector]
    public bool shooting = false;
    [HideInInspector]
    public bool jumping = false;

    [HideInInspector]
    public Vector2 recoilVector;

    Rigidbody2D rigidBody;
    Animator anim;
    SpriteRenderer playerSprite, gunSprite;
    CircleCollider2D playerCol;
    float playerColDiameter;
    float groundRadius = 0.1f, timeSinceJump, defaultGravity;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;
        canJump = true;
        defaultGravity = rigidBody.gravityScale;
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        gunSprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        playerCol = GetComponent<CircleCollider2D>();
        playerColDiameter = playerCol.radius;
    }

    void Update()
    {
        // Check to see if player is on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded && !canJump) canJump = true;
        if (grounded) rigidBody.gravityScale = defaultGravity;
        if (timeSinceJump < 3) timeSinceJump += Time.deltaTime;
        if (shooting) canJump = false;

        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigidBody.gravityScale = 1f;
                timeSinceJump = 0;
                jumping = true;
            }
            else if (Input.GetButton("Jump"))
            {
                if (timeSinceJump < defaultGravity) rigidBody.gravityScale = timeSinceJump + 1;
            }

            if (Input.GetButtonUp("Jump"))
            {
                canJump = false;
                rigidBody.gravityScale = defaultGravity;
            }
        }

        // ANIMATION
        float xMagnitude = rigidBody.velocity.x * rigidBody.velocity.x;
        anim.SetFloat("Speed", xMagnitude);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("YSpeed", rigidBody.velocity.y);
        /****************/
    }

    void FixedUpdate()
    {
        // Get the Input from controller or keyboard for horizontal movement
        float horizontal = Input.GetAxis("Horizontal");

        // Takes the horizontal input and makes the player move
        HandleMovement(horizontal);

        if(jumping)
        {
            Jump(jumpForce);
        }

        // Flips the Player in the direction of movement
        Flip(horizontal);
    }

    void HandleMovement(float horizontal)
    {
        Debug.Log(rigidBody.velocity);

        //
        var movementVector = new Vector2();
        movementVector.x = Mathf.Lerp(horizontalSpeed, horizontal * maxSpeed, horizontalSpeedLerp);

        if(grounded)
        {
            //movementVector.x = Mathf.Lerp(movementVector.x, 0f, 0.3f);
        }

        recoilVector = Vector2.Lerp(recoilVector, Vector2.zero, Time.deltaTime * 15);

        var leftRayInfo = Physics2D.BoxCast(rigidBody.position, new Vector2(playerColDiameter, playerColDiameter), 0f, -transform.right, boxCastDistance, whatIsGround);
        var rightRayInfo = Physics2D.BoxCast(rigidBody.position, new Vector2(playerColDiameter, playerColDiameter), 0f, transform.right, boxCastDistance, whatIsGround);

        if (leftRayInfo.collider != null)
        {
            Debug.Log("Hit wall to the left: " + leftRayInfo.collider.name);

            if (horizontalSpeed < 0f)
                horizontalSpeed = 0f;
        }
        if (rightRayInfo.collider != null)
        {
            Debug.Log("Hit wall to the right: " + rightRayInfo.collider.name);

            if (horizontalSpeed > 0f)
                horizontalSpeed = 0f;
        }

        Debug.DrawRay(transform.position, recoilVector * 1f, Color.red);
        Debug.DrawRay(transform.position, movementVector * 1f, Color.yellow);

		rigidBody.velocity += movementVector + recoilVector;

        
        Debug.DrawRay(transform.position, rigidBody.velocity * 1f, Color.green);

    }

    void Flip(float horizontal)
    {
        if (horizontal > 0.1f && !facingRight || horizontal < 0.1f && facingRight)
        {
            facingRight = !facingRight;
            playerSprite.flipX = !playerSprite.flipX;
            gunSprite.flipY = !gunSprite.flipY;
            Transform bulletSpawn = transform.GetChild(0).GetChild(0).GetChild(0);

            if (bulletSpawn.localPosition.y != -0.06f) bulletSpawn.localPosition = new Vector3(0.218f, -0.06f, 0);
            else bulletSpawn.localPosition = new Vector3(0.218f, 0.06f, 0);
        }
    }

    void Jump(float jumpForce)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        jumping = false;
    }
}
