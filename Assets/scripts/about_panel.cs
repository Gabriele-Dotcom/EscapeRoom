using UnityEngine;

public class about_panel : MonoBehaviour
{
    public GameObject aboutPanel;

    // Mostra il pannello
    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
    }

    // Nasconde il pannello
    public void HideAbout()
    {
        aboutPanel.SetActive(false);
    }
}
