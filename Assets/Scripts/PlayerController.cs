using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public CharacterController controller = null;
    [Header("Collisions")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] float groundDistance = 0f;
    [SerializeField] LayerMask groundMask;
    float startPosY;
    [Header("Movement")]
    [SerializeField] float speed = 0f;
    Vector3 move;
    bool isGrounded;

    void Start()
    {
        startPosY = transform.position.y;
    }

    void Update()
    {
        if (Cursor.visible)
            return;

        Movement();
        CheckGroundCollision();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void CheckGroundCollision()
    {
        if (isGrounded == false)
            transform.position = new Vector3(transform.position.x, startPosY, transform.position.z);
    }
}