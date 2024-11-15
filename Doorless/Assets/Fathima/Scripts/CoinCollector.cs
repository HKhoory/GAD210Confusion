using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public GameObject winPanel; 
    public AudioClip winSound; 
    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if(coinSound != null) 
            {
                audioSource.PlayOneShot(coinSound);
            }
            else
            {
                Debug.Log("MISSING AUDIOOOO");
            }
            Destroy(other.gameObject); // Destroy the coin after collection
        }
    }

    public void TriggerWinCondition()
    {
        // Play win sound
        audioSource.PlayOneShot(winSound);

        // Display win panel
        winPanel.SetActive(true);

    }
}
