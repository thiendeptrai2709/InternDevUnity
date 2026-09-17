using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject deathPanel;
    public GameObject winPanel;

    public AudioSource winAudio;
    public AudioClip winSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        deathPanel.SetActive(false);
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (winAudio != null && winSound != null)
        {
            winAudio.PlayOneShot(winSound);
        }

        // Chuyển nhân vật sang trạng thái Win
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerStateManager stateManager = player.GetComponent<PlayerStateManager>();
            if (stateManager != null)
            {
                stateManager.SwitchState(stateManager.winState);
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}