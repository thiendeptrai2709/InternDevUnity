using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public PlayerControls playerControls;
    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool IsLeftClickHeld { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerControls = new PlayerControls();

        playerControls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => MoveInput = Vector2.zero;

        playerControls.Player.Jump.performed += ctx => JumpInput = true;
        playerControls.Player.Jump.canceled += ctx => JumpInput = false;

        playerControls.Player.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Look.canceled += ctx => LookInput = Vector2.zero;

        playerControls.Player.LeftClick.performed += ctx => IsLeftClickHeld = true;
        playerControls.Player.LeftClick.canceled += ctx => IsLeftClickHeld = false;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}