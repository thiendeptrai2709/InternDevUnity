using UnityEngine;

public class PlayerLandState : PlayerBaseState
{
    private float landTimer;
    public float landDuration = 0.6f;

    public override void EnterState(PlayerStateManager player)
    {
        landTimer = 0f;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        landTimer += Time.deltaTime;

        if (landTimer >= landDuration)
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