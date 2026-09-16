using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        player.GetComponent<RagdollController>().EnableRagdoll();

        GameManager.Instance.ShowDeathPanel();
    }
    public override void UpdateState(PlayerStateManager player)
    {
    }
}