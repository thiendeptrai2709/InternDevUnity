using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("JumpUp");
        player.GetComponent<PlayerSound>().PlayJumpSound();
        player.GetComponent<PlayerMovement>().PerformJump();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.GetComponent<PlayerMovement>().velocityY < 0f)
        {
            player.SwitchState(player.fallState);
        }
    }
}