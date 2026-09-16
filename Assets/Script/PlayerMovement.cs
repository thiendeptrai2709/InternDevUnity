using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;
    public float velocityY;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f;
        }

        Vector2 input = InputManager.Instance.MoveInput;
        Vector3 move = new Vector3(input.x, 0, input.y).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * Time.deltaTime * speed);
        }

        velocityY += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
    }
    public void PerformJump()
    {
        if (controller.isGrounded)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}