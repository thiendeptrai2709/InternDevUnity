using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractableUI : MonoBehaviour
{
    public GameObject uiCanvas;
    public Button interactButton;
    public UnityEvent onInteractEvent;

    public AudioSource audioSource;
    public AudioClip interactSound;

    private void Start()
    {
        uiCanvas.SetActive(false);
        interactButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.SetActive(false);
        }
    }

    private void OnButtonClicked()
    {
        if (audioSource != null && interactSound != null)
        {
            audioSource.PlayOneShot(interactSound);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerStateManager stateManager = player.GetComponent<PlayerStateManager>();
            if (stateManager != null)
            {
                stateManager.SwitchState(stateManager.interactState);
            }
        }

        onInteractEvent.Invoke();
    }

    public void ToggleInteract(bool state)
    {
        GetComponent<Collider>().enabled = state;
        if (!state)
        {
            uiCanvas.SetActive(false);
        }
    }
}