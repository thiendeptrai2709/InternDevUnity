using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] footstepClips;
    public AudioClip jumpClip;
    [Range(0f, 1f)]
    public float footstepVolume = 0.5f;
    [Range(0f, 1f)]
    public float jumpVolume = 0.5f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Hàm này sẽ được gọi trực tiếp từ các Animation Event
    public void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            // Chọn ngẫu nhiên 1 âm thanh trong danh sách để phát
            int index = Random.Range(0, footstepClips.Length);
            audioSource.PlayOneShot(footstepClips[index], footstepVolume);
        }
    }
    public void PlayJumpSound()
    {
        if (jumpClip != null)
        {
            audioSource.PlayOneShot(jumpClip, jumpVolume);
        }
    }
}