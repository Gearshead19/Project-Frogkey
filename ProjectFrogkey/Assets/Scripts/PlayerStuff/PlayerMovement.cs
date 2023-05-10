using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Effectively manages different types of player movement and inputs for it.
/// 2. Refactor code to be organized. We have a lot of variables we're not even using
/// </summary>
public class PlayerMovement : MonoBehaviour
{
   
    private Dashing dash;

    private Animator animator;

    private MeshTrail dashTrail;
  
    [SerializeField]
    private GameObject projectile;


    // Shot postion will be used as the attack point
    public Transform shotPosition;
  //  public Transform debugTransform;

    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float MaxYspeed;
    private float sprintThreshold = .5f; 
    public float dashSpeed;
    public float dashSpeedChangeFactor;

    public float acceleration = 1;

    public Transform orientation;
    public Transform playerModelLook;

    public float rotationSpeed;
    float horizontalInput;
    float verticalInput;

    private bool canMove = true;

    public Vector3 moveDirection;

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
    [Tooltip("Variables to manipulate the jump")]
    public float jumpForce; // force of the jump
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump; // determines if the character is ready to jump or not

    [Header("Dashing")]
    [Tooltip("Variable to manipulate for the dash")]
    float dashForce; // force of the dash movement
    float dashUpward; // upward force of dash movement
    float dashDuration; // How long the dash happens

    [Header("Cooldown")]
    [Tooltip("These are the cooldown elements for the dash, Dash Cooldown and the Dash Cooldown Timer")]
    float dashCD; // dash cooldown
    float dashCDTimer; // dash cooldown timer

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

    [Header("Audio")]
    public AK.Wwise.Event HoppsJump;

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
    public bool dashing;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   //freeze = Idle 
        readyToJump = true;

        dash = GetComponent<Dashing>();
        dashTrail = GetComponentInChildren<MeshTrail>();

    }

    private void FixUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * Fallfaster, ForceMode.Acceleration);
    }

    private void Update()
    {
        AnimationHandler();
        //Ground Check

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * maxDistance + 0.2f, whatIsGround);
        //grounded = Physics.CheckSphere(orientation.position, maxDistance, whatIsGround);


        MovePlayer();
        SpeedControl();
        StateHandler();
        
        //This will Handle the Drag.
        if (grounded == true && !activeGrapple && state != MovementState.dashing)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        
    }

    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;
    private MovementState lastState;
    private bool keepMomentum;

    public void AnimationHandler()
    {
        // get parameter values from animator
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if (state == MovementState.walking)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (state == MovementState.sprinting)
        {
            animator.SetBool("isRunning", true);
        }    
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    private void StateHandler()
    {
        //Mode - Dashing
        if (dashing)
        {
            state = MovementState.dashing;
            desiredMoveSpeed = sprintSpeed;
            speedChangeFactor = dashSpeedChangeFactor;
            

        }

        //Mode - Sprinting
        else if (grounded == true && horizontalInput >= sprintThreshold || verticalInput >= sprintThreshold || horizontalInput <= -sprintThreshold || verticalInput <= -sprintThreshold )
        {
          

            //this.gameObject.GetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
            state = MovementState.sprinting;
            desiredMoveSpeed = sprintSpeed;
          

        }

        // Mode - Walking
        else if (grounded == true && horizontalInput !=0 || verticalInput !=0)
        {
           
            state = MovementState.walking;
            desiredMoveSpeed = walkSpeed;


        }

        //Mode - Idle(Freeze)
        else if (grounded == true && horizontalInput == 0 && verticalInput == 0)
        {

            state = MovementState.idle;
           
        }

        // Mode - Air
        else
        {
            state = MovementState.air;

            if (desiredMoveSpeed < sprintSpeed)
            {
                desiredMoveSpeed = walkSpeed;
            }
            else
            {
                desiredMoveSpeed = sprintSpeed;
            }
        }

        bool desiredMoveSpeedChanged = desiredMoveSpeed != lastDesiredMoveSpeed;
        if (lastState == MovementState.dashing) keepMomentum = true;

        if (desiredMoveSpeedChanged)
        {
            if (keepMomentum)
            {
                StopAllCoroutines();
                StartCoroutine(SmoothlyLerpMoveSpeed());
            }
            else
            {
                StopAllCoroutines();
                moveSpeed = desiredMoveSpeed;
            }
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
        lastState = state;

    }

    private float speedChangeFactor;
    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        //smoothly lerp movement Speed to desired Value
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        float boostFactor = speedChangeFactor;

        while (time<difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);

            time += Time.deltaTime * boostFactor;

            yield return null;
        }
        moveSpeed = desiredMoveSpeed;
        speedChangeFactor = 1f;
        keepMomentum = false;
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

        //  Debug.Log("H: " + horizontalInput + "V: " + verticalInput);
        Debug.Log(desiredMoveSpeed);
        
    }
    /// <summary>
    /// While having an animation run such as lifting a chest, the player cannot move until the animation is over.
    /// </summary>
    private void StopMoving()
    {
    }
    public void OnLift()
    {
     
        animator.SetTrigger("OpenChest");
        canMove = false;
        Debug.Log("CHEST!!");
        StopMoving();
        
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
        if (state == MovementState.dashing)
        {
            return;
        }
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
        Debug.Log("Dashing");
        dash.Dash();
        dashTrail.CheckTrail();
        if (grounded && state != MovementState.dashing)
        {
            this.gameObject.GetComponent<PlayerHealth>().Player_Invincible(time_for_invincbility);
        }
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

        // limit yvel
        if (MaxYspeed !=0 && rb.velocity.y> MaxYspeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, MaxYspeed, rb.velocity.z);
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
            animator.SetTrigger("Jump");
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

        //plays jump audio
        HoppsJump.Post(gameObject);
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
        if (collision.gameObject.CompareTag("Chest"))
        {
            Debug.Log("Chest!");
            animator.SetTrigger("OpenChest");
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

    #region Camera Shifts if we need them
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
    //public void DoFOV(float endValue)
    //{
    //    GetComponent<Camera>().fieldOfView = endValue;
    //}
    #endregion

}
