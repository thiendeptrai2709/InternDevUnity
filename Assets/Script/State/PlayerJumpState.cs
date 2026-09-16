using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float jumpDelay = 0.1f;
    private float currentTimer;

    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Jump");
        player.GetComponent<PlayerMovement>().PerformJump();
        currentTimer = 0f;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > jumpDelay && player.GetComponent<CharacterController>().isGrounded)
        {
            if (InputManager.Instance.MoveInput.magnitude > 0.1f)
            {
                player.SwitchState(player.runState);
            }
            else
            {
                player.SwitchState(player.idleState);
            }
        }
    }
}