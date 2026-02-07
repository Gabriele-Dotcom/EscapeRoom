using UnityEngine;

public class clickableObject : MonoBehaviour
{
    public string nomeOggetto;
    public GameObject pannelloIndizio;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (audioSource != null)
            audioSource.Play();

        pannelloIndizio.SetActive(true);
    }
}
