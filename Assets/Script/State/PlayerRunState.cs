using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Locomotion");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (!player.GetComponent<CharacterController>().isGrounded)
        {
            player.SwitchState(player.fallState);
            return;
        }

        player.animator.SetFloat("Speed", InputManager.Instance.MoveInput.magnitude);

        if (InputManager.Instance.JumpInput)
        {
            player.SwitchState(player.jumpState);
            return;
        }

        if (InputManager.Instance.MoveInput.magnitude <= 0.1f)
        {
            player.SwitchState(player.idleState);
        }
    }
}