using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStateManager stateManager = other.GetComponent<PlayerStateManager>();
            if (stateManager != null)
            {
                stateManager.SwitchState(stateManager.deathState);
            }
        }
    }
}