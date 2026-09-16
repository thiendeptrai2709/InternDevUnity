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

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}