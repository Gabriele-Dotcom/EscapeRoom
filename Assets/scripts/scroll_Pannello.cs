using UnityEngine;

public class scrollPanel : MonoBehaviour
{
    public GameObject scroll_Pannello;
    // Mostra il pannello
    public void ShowScroll()
    {
        scroll_Pannello.SetActive(true);

    }

    // Nasconde il pannello
    public void HideScroll()
    {
        scroll_Pannello.SetActive(false);
    }
}
