using UnityEngine;

public class PlayerWinState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        // Khóa Animator về trạng thái đứng im
        player.animator.SetFloat("Speed", 0f);
        player.animator.Play("Idle");

        // Khóa di chuyển vật lý
        player.GetComponent<PlayerMovement>().enabled = false;

        // Ngắt hệ thống phím (nếu bạn muốn chặn cả xoay camera, nếu không thì bỏ dòng này)
        // InputManager.Instance.playerControls.Disable(); 
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // Để trống, không nhận thêm Input chuyển State nào khác
    }
}