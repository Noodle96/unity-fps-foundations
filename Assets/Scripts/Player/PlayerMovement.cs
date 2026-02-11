using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f;
    private float gravity = -9.81f;
    public Transform footGroundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    [Header("Player Run")]
    public bool isRunning = false;
    public float runningSpeedMultiplier = 2f;
    private float runningSpeed = 1f;

    [Header("Running UI")]
    public float staminaUseAmount = 5f;
    private RunningSliderUI runningSlider;

    [Header("Animator")]
    public Animator animator;

    Vector3 velocity;
    private Transform currentPlatform;


    private void Start()
    {
        //Debug.Log("PlayerMovement script has started.");
        Vector3 any = transform.position;
        Vector3 any2 = transform.right;

        //Debug.Log("Player position: " + any.ToString());
        //Debug.Log("Player right vector: " + any2.ToString());

        runningSlider = Object.FindFirstObjectByType<RunningSliderUI>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(footGroundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the player grounded
            //Debug.Log("Player is grounded.");
        }
        else { 
            //Debug.Log("Player is not grounded.");
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Setear las animaciones
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelZ", z);

        //Vector3 inputDirection = new Vector3(x, 0, z);
        //Vector3 localDirection = transform.InverseTransformDirection(inputDirection);

        //animator.SetFloat("VelX", localDirection.x);
        //animator.SetFloat("VelZ", localDirection.z);
        animator.SetBool("isRunning", isRunning);

        Vector3 move = transform.right * x + transform.forward * z;
        RunCheck();
        // Apply movement
        // [Antes]
        //characterController.Move(move * speed * Time.deltaTime * runningSpeed);
        Vector3 horizontalMove = move * speed * runningSpeed;

        // JUMPING
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            transform.parent = null;
            currentPlatform = null;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping", true);
            Debug.Log("Player jumped.");
        }
        if (!isGrounded && velocity.y <= 0f) {
            animator.SetBool("isJumping", false);
        }

        if (!isGrounded)
        {
            transform.parent = null;
            currentPlatform = null;
        }


        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // [ANTES]
        //characterController.Move(velocity * Time.deltaTime);
        Vector3 finalMove = horizontalMove + velocity;
        characterController.Move(finalMove * Time.deltaTime);
    }

    public void RunCheck() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isRunning = !isRunning;
            //if (isRunning) {
            //    runningSlider.UseStamina(staminaUseAmount);
            //}
            //else { 
            //    runningSlider.UseStamina(0f);
            //}
            //if (runningSlider.CanRun())
            //{
            //    isRunning = !isRunning;
            //    runningSlider.SetRunning(isRunning);
            //}
        }
        //if (isRunning)
        //{
        //    runningSpeed = runningSpeedMultiplier;
        //}
        //else {
        //    runningSpeed = 1f;
        //}
        if (isRunning && !runningSlider.CanRun())
        {
            isRunning = false;
        }

        runningSlider.SetRunning(isRunning);
        runningSpeed = isRunning ? runningSpeedMultiplier : 1f;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.GetComponent<FloatingObject>() != null && hit.moveDirection.y < 0)
        {
            currentPlatform = hit.collider.transform;
            transform.parent = currentPlatform;
        }
    }
}
