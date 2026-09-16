using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.GetComponent<CharacterController>().isGrounded)
        {
            player.SwitchState(player.landState);
        }
    }
}