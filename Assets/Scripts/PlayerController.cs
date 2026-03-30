using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveX = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveX = 1f;

        Vector3 move = new Vector3(moveX, 0, 0);
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, -3f, 3f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}