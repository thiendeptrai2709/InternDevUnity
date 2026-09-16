using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerStateManager : MonoBehaviour
{
    public Animator animator;
    private PlayerBaseState currentState;

    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerRunState runState = new PlayerRunState();
    public PlayerJumpState jumpState = new PlayerJumpState();
    public PlayerInteractState interactState = new PlayerInteractState();
    public PlayerFallState fallState = new PlayerFallState();
    public PlayerLandState landState = new PlayerLandState();
    private void Start()
    {
        animator = GetComponent<Animator>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        animator.SetFloat("VelocityY", GetComponent<PlayerMovement>().velocityY);
        animator.SetBool("IsGrounded", GetComponent<CharacterController>().isGrounded);
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}