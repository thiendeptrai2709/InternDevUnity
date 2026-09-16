using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platforms;

    private void Start()
    {
        foreach (GameObject platform in platforms)
        {
            if (platform != null)
            {
                platform.SetActive(false);
            }
        }
    }

    public void ShowPlatforms()
    {
        foreach (GameObject platform in platforms)
        {
            if (platform != null)
            {
                platform.SetActive(true);
            }
        }
    }
}