using System.Collections;
using UnityEngine;

public class VentilationDoor : MonoBehaviour
{
    public Animator doorAnimator;
    public Collider doorCollider;
    public InteractableUI interactUI;
    public float autoCloseTime = 3f;

    public AudioSource doorAudio;
    public AudioClip openSound;
    public AudioClip closeSound;

    public void OpenDoor()
    {
        interactUI.ToggleInteract(false);
        doorCollider.isTrigger = true;

        if (doorAudio != null && openSound != null)
        {
            doorAudio.PlayOneShot(openSound);
        }

        doorAnimator.Play("Open");
        StartCoroutine(AutoCloseRoutine());
    }

    private IEnumerator AutoCloseRoutine()
    {
        yield return new WaitForSeconds(autoCloseTime);

        if (doorAudio != null && closeSound != null)
        {
            doorAudio.PlayOneShot(closeSound);
        }

        doorAnimator.Play("Close");
        yield return new WaitForSeconds(1f);
        doorCollider.isTrigger = false;
        interactUI.ToggleInteract(true);
    }
}