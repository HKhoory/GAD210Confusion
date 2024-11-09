using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinningSound()
    {
        audioSource.Play();
    }
}
