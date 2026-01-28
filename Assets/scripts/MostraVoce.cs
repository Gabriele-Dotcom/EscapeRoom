using UnityEngine;

public class MostraVoce : MonoBehaviour
{
    public void ShowAbout(GameObject VoceMenu)

    {
        VoceMenu.SetActive(true);
        Debug.Log("About panel shown");
    }

    // Nasconde il pannello
    public void HideAbout(GameObject VoceMenu)
    {
        VoceMenu.SetActive(false);
        
    }
}
