using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timerscript : MonoBehaviour
{

    [SerializeField] GameObject GameOver_panel;

    [SerializeField] TextMeshProUGUI timertext;

    [SerializeField] float Duration, currentTime;
void Start()
{
    GameOver_panel.SetActive(false);
    currentTime = Duration; 
    timertext.text = currentTime.ToString();
    StartCoroutine(timeIEn());
}
    IEnumerator timeIEn()
    {
        while (currentTime >= 0)
        {
            timertext.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        openGameOverPanel();
    }

    void openGameOverPanel()
    {
        timertext.text = "0"; // Pulisce il testo del timer
        GameOver_panel.SetActive(true); // Mostra il pannello con la scritta Game Over

        // Cerchiamo lo script Switch_scene che hai messo sul GameOver_panel
        Switch_scene scriptScena = GameOver_panel.GetComponent<Switch_scene>();

        if (scriptScena != null)
        {
            // ATTIVIAMO la sequenza: Fade -> Aspetta 3s -> Cambia Scena
            scriptScena.Transizione();
        }
        else
        {
            Debug.LogError("Attenzione: non ho trovato lo script Switch_scene sull'oggetto GameOver_panel!");
        }
    }

}