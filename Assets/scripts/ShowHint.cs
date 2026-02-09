using UnityEngine;

/// <summary>
/// Gestisce l'attivazione e disattivazione del pannello dei suggerimenti (Hint).
/// </summary>
public class ShowHint : MonoBehaviour
{
    public GameObject hintPanel;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        ShowHintPanel();
    }

    public void ShowHintPanel()
    {
        if (audioSource != null)
            audioSource.Play();

        hintPanel.SetActive(true);
        Debug.Log("Hint panel shown");
    }

    public void HideHintPanel()
    {
        hintPanel.SetActive(false);
    }
}
