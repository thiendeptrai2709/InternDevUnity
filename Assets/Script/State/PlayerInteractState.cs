using UnityEngine;

public class PlayerInteractState : PlayerBaseState
{
    private float interactTimer;
    public float interactDuration = 0.1f;

    public override void EnterState(PlayerStateManager player)
    {
        interactTimer = 0f;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        interactTimer += Time.deltaTime;
        if (interactTimer >= interactDuration)
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