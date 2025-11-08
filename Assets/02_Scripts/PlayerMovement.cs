using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public int extraJumps;
    private int extraJumpValue;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public  float groundDistance = 0.4f;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        extraJumpValue = extraJumps;
    }

    void Update()
    {
        // ground check
        grounded = grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (grounded)
        {
            ResetJump();
        }
        
        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        } else
        {
            rb.linearDamping = 0;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump)
        {
            if (grounded)
            {
                Jump();
                Invoke(nameof(ReadyJump), jumpCooldown);
            }
            else if (!grounded && extraJumpValue > 0)
            {
                Jump();
                extraJumpValue--;
                Invoke(nameof(ReadyJump), jumpCooldown);
            }

        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        readyToJump = false;
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        extraJumpValue = extraJumps;
        readyToJump = true;
    }

    private void ReadyJump()
    {
        readyToJump = true;
    }
}
