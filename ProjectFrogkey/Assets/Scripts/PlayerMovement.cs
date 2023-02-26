using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// TODO: 1.Manage move to sprint implementation
/// Needs to be a gradual change based on "stick pressure" or
/// "changing values to a number threshold"
/// 
/// 2. Refactor code to be organized. We have a lot of variables we're not even using
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCam instance;
    [SerializeField]
    private GameObject projectile;


    // Shot postion will be used as the attack point
    public Transform shotPosition;
  //  public Transform debugTransform;
    public LayerMask whatIsGrappleable;

    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float acceleration = 1;

    public Transform orientation;
    public Transform playerModelLook;

    public float rotationSpeed;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    Vector2 inputVector;

    private float time_for_invincbility = .03f;
    public float smoothTime;
    public float currentSpeed;
    public float currentMoveVelocity;
    float playerMass = 10f;
    public float groundDrag;

    Vector3 MouseWorldPosition = Vector3.zero;
    Vector2 screenCenterPoint = new(Screen.width / 2f, Screen.height / 2f);

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump;

    [Header("Dashing")]
    float dashForce;
    float dashUpward;
    float dashDuration;

    [Header("Cooldown")]
    float dashCD;
    float dashCDTimer;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode shootKey = KeyCode.L;


    [Header("Ground Check")]
    float playerHeight = 1f;
    public LayerMask whatIsGround;
    public float maxDistance = .5f;
    // public int layerMask = .2f;

    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Disarming Tongue")]
    public float tongueDistance;
    public float retractionSpeed;
    public float grabDuration;
    public float disarmCooldown;
    public float tongueSpeed;
    public bool Disarming;

    //bug fixing
    public bool allowInvoke = true;




    public MovementState state;

    public float Fallfaster = 1;

    public enum MovementState
    {
        idle,
        walking,
        sprinting,
        air,
        dashing
    }

    public bool freeze;
    public bool activeGrapple;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   //freeze = Idle 
        readyToJump = true;

    }

    private void FixUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * Fallfaster, ForceMode.Acceleration);
    }

    private void Update()
    {

        //// Creates a raycast to the center of the screen

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, whatIsGrappleable))
        {
           // debugTransform.transform.position = hit.point;
            MouseWorldPosition = hit.point;
            
        }


        //Ground Check

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * maxDistance + 0.2f, whatIsGround);
        //grounded = Physics.CheckSphere(orientation.position, maxDistance, whatIsGround);


        MovePlayer();
        SpeedControl();
        StateHandler();
        
        //This will Handle the Drag.
        if (grounded == true && !activeGrapple)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        
    }

    private void StateHandler()
    {
        //Mode - Sprinting
        if (grounded == true && horizontalInput >= .5 || verticalInput >= .5 || horizontalInput == -1 || verticalInput == -1)
        {
            //this.gameObject.GetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

        }
        // Mode - Walking
        else if (grounded == true)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        // Mode - Air
        else
        {
            state = MovementState.air;
        }
        //Mode - Idle(Freeze)
        if (freeze)
        {
            state = MovementState.idle;
            moveSpeed = 0;
            rb.velocity = Vector3.zero;
        }

    }

    #region Movement


    /// <summary>
    /// The whole OnMove method controls movement
    /// </summary>
    /// 
    public void OnMove(InputValue value)
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        inputVector = value.Get<Vector2>();

        inputVector.x = horizontalInput;
        inputVector.y = verticalInput;

        Debug.Log("H: " + horizontalInput + "V: " + verticalInput);
        
    }



    /// <summary>
    /// Rotates player model by input directions
    /// </summary>
    void RotateTowardsVector()
    {
        var xzDirection = new Vector2(inputVector.x, inputVector.y);
        if(xzDirection.magnitude == 0) return;

        var rotation = Quaternion.LookRotation(xzDirection);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    void MovePlayer()
    {
        //Sprint Calculation

        if (horizontalInput >= .5 || horizontalInput <= -.5)
        {
            state = MovementState.sprinting;
            acceleration *= Time.deltaTime;
            
        }

        if (horizontalInput <= .5 || horizontalInput != 0)
        {
            state = MovementState.walking;
            acceleration = 1;
        }

        if (verticalInput >= .5 || verticalInput <= -.5)
        {
            state = MovementState.sprinting;
            acceleration *= Time.deltaTime;

        }

        if (verticalInput < .5 || verticalInput != 0)
        {
            state = MovementState.walking;
            acceleration = 1;
        }



        else
        {
            Debug.Log("Found an opening");
        }
        
        ////For sprint speed
        //currentMoveVelocity = moveSpeed * Time.deltaTime;

        //// 0 speed to move speed's value
        // float moveCurve = Mathf.SmoothDamp(moveSpeed, sprintSpeed, ref currentMoveVelocity, smoothTime); // velocity is rate while smooth time is how long it takes

        ////Cap the move speed to not exceed the sprint speed
        ////float moveCap = Mathf.Clamp( Value = moveSpeed, float min = Walk Speed, float max = Sprint Speed);
        //float moveCap = Mathf.Clamp(moveSpeed, walkSpeed, sprintSpeed);
        //currentSpeed = moveSpeed;
        //if (moveCurve > moveCap)
        //{
        //    currentSpeed = sprintSpeed;
        //    state = MovementState.sprinting;
        //}
        
        if (activeGrapple) return;
        //Calculates movement direction of the Player.
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //On Slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(20f * moveSpeed * GetSlopeMoveDirection(), ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }

        }

        //On Ground
        if(grounded)
        {
            //Add force
            //rb.AddForce(10f *moveCurve * moveSpeed * moveDirection.normalized, ForceMode.Force);
            rb.AddForce(playerMass * moveSpeed * acceleration * moveDirection.normalized, ForceMode.Force); // Replace Move Cap to move curve
        }
        //In Air
        else if (!grounded)
        {
            rb.AddForce(playerMass * airMultiplier * moveSpeed * moveDirection.normalized, ForceMode.Force);
        }

        //Turn "Gravity" off while on "Slopes"
        rb.useGravity = !OnSlope();

    }

    #region Dash

    void OnDash()
    {
        float Force = rb.mass * acceleration;
        Debug.Log("I'm Dashing");
        if (grounded && state != MovementState.dashing)
        {
            this.gameObject.GetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
            rb.AddForce(Force * moveDirection, ForceMode.Impulse);
            state = MovementState.dashing;
            Invoke(nameof(ResetDash),dashDuration);
        }
     
        
    }
    private void ResetDash()
    {
        
    }

    #endregion

    void SpeedControl()
    {
        if (activeGrapple) return;

        //Limits speed on "Slopes"
        if (OnSlope() && !exitingSlope)
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //Limit the velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }
    #endregion

    #region JumpandJumpControl

    /// <summary>
    /// The whole OnJump method give the player its jump
    /// </summary>
    /// <param name="context"></param>
    public void OnJump()
    {
      
        if (readyToJump && grounded)
        {
            readyToJump = false;

              Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
            // Debug.Log("I jump");
            grounded = false;
        }
    }


    private void Jump()
    {
        exitingSlope = true;

        //resets the Y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }
    private bool enableMovementOnNextTouch;
    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;
        Invoke(nameof(SetVelocity), 0.1f);
        Invoke(nameof(ResetRestrictions),3f);
        velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
    }

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        rb.velocity = velocityToSet;
        enableMovementOnNextTouch = true;
    }
    public void ResetRestrictions()
    {
        activeGrapple = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enableMovementOnNextTouch)
        {
            enableMovementOnNextTouch = false;
            ResetRestrictions();

            GetComponent<Grappling>().StopGrapple();
        }
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)+ Mathf.Sqrt(2*(displacementY - trajectoryHeight)/gravity));

        return velocityXZ + velocityY;
    }

    #endregion

    /* not 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EditorOnly"))
        {
            grounded = true;
        }
        
    }
  
     
     

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();
        TextStuff();

        // handle drag
        if (state == MovementState.walking || state == MovementState.sprinting || state == MovementState.crouching)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

        lastDesiredMoveSpeed = desiredMoveSpeed;

        // deactivate keepMomentum
        if (Mathf.Abs(desiredMoveSpeed - moveSpeed) < 0.1f) keepMomentum = false;
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        // smoothly lerp movementSpeed to desired value
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        while (time < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);

            if (OnSlope())
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
            }
            else
                time += Time.deltaTime * speedIncreaseMultiplier;

            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
    }

    private void MovePlayer()
    {
        if (climbingScript.exitingWall) return;
        if (climbingScriptDone.exitingWall) return;
        if (restricted) return;

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection(moveDirection) * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        else if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        if(!wallrunning) rb.useGravity = !OnSlope();
    }

   

    private void Jump()
    {
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

*/

    #region Mechanics
    /// <summary>
    /// Shoot projectiles in one direction relative to the reticle(same rotation as the player's rotation
    
void OnFire()
    {
        Vector3 aimDir = (MouseWorldPosition - shotPosition.position).normalized;
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet!=null)
        {
            // bullet.transform.position = Turret.transform.position;
            // bullet.transform.rotation = Turret.transform.position;
            bullet.transform.SetPositionAndRotation(shotPosition.transform.position, playerModelLook.rotation);

            if (ThirdPersonCam.instance.currentStyle == ThirdPersonCam.CameraStyle.Combat)
            {
                bullet.transform.SetPositionAndRotation(shotPosition.transform.position,Quaternion.LookRotation(aimDir,Vector3.up));
            }
           
            bullet.SetActive(true);
        }
        
    }

    //  //if (Input.GetKeyDown(KeyCode.M) && hit.collider.CompareTag("Shield"))
    //  //{
    //  //    Destroy(CompareTag("Shield"));
    //  //}
    #endregion

    void OnCombatCam()
    {      
        ThirdPersonCam.instance.SwitchCameraStyle(ThirdPersonCam.CameraStyle.Combat);
        Debug.Log("COMBAT!");
    }
    void OnBasicCam()
    {
        ThirdPersonCam.instance.SwitchCameraStyle(ThirdPersonCam.CameraStyle.Basic);
        Debug.Log("BASIC");

    }
    void OnTopDownCam()
    {
        ThirdPersonCam.instance.SwitchCameraStyle(ThirdPersonCam.CameraStyle.Topdown);
        Debug.Log("TOPDOWN");
    }


}
