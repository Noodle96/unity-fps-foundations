using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f;
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
