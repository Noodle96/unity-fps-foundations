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


    Vector3 velocity;
    private void Start()
    {
        //Debug.Log("PlayerMovement script has started.");
        Vector3 any = transform.position;
        Vector3 any2 = transform.right;

        //Debug.Log("Player position: " + any.ToString());
        //Debug.Log("Player right vector: " + any2.ToString());
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
        Vector3 move = transform.right * x + transform.forward * z;
        // Apply movement
        characterController.Move(move * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { 
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
