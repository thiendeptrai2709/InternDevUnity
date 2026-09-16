using System.Collections;
using UnityEngine;

public class VentilationDoor : MonoBehaviour
{
    public Animator doorAnimator;
    public Collider doorCollider;
    public InteractableUI interactUI;
    public float autoCloseTime = 3f;

    public void OpenDoor()
    {
        interactUI.ToggleInteract(false);
        doorCollider.isTrigger = true;
        doorAnimator.Play("Open");
        StartCoroutine(AutoCloseRoutine());
    }

    private IEnumerator AutoCloseRoutine()
    {
        yield return new WaitForSeconds(autoCloseTime);
        doorAnimator.Play("Close");
        yield return new WaitForSeconds(1f);
        doorCollider.isTrigger = false;
        interactUI.ToggleInteract(true);
    }
}