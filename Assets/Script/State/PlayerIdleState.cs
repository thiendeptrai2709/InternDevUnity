using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Locomotion");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.animator.SetFloat("Speed", 0f);

        if (InputManager.Instance.JumpInput)
        {
            player.SwitchState(player.jumpState);
            return;
        }

        if (InputManager.Instance.MoveInput.magnitude > 0.1f)
        {
            player.SwitchState(player.runState);
        }
    }
}