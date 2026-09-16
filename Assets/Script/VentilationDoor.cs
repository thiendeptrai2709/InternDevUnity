using UnityEngine;

public class VentilationDoor : MonoBehaviour
{
    public Animator doorAnimator;

    public void OpenDoor()
    {
        doorAnimator.Play("Open");
    }
}