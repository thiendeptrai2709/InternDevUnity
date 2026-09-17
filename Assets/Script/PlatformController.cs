using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platforms;
    public float spawnDelay = 0.2f;
    public float moveDistance = 2f;
    public float moveSpeed = 8f;

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
        StartCoroutine(SpawnPlatformsSequence());
    }

    private IEnumerator SpawnPlatformsSequence()
    {
        foreach (GameObject platform in platforms)
        {
            if (platform != null)
            {
                platform.SetActive(true);

                StartCoroutine(AnimatePlatform(platform));
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
    private IEnumerator AnimatePlatform(GameObject platform)
    {
        Vector3 endPos = platform.transform.position;
        platform.transform.position = endPos - new Vector3(0, moveDistance, 0);

        while (Vector3.Distance(platform.transform.position, endPos) > 0.01f)
        {
            platform.transform.position = Vector3.Lerp(platform.transform.position, endPos, Time.deltaTime * moveSpeed);
            yield return null;
        }

        platform.transform.position = endPos;
    }
}