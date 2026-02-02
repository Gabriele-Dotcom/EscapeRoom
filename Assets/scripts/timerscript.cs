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

    [SerializeField] float Duration;
    private float currentTime;
    private bool isTimerRunning = false; // variabile per controllare se il timer è in esecuzione

   
    void Start()
{
        GameOver_panel.SetActive(false);
        currentTime = Duration;
        isTimerRunning = true;
        StartCoroutine(timeIEn());
    }
    IEnumerator timeIEn()
    {

        while (currentTime > 0 && isTimerRunning)
        {
            // Aggiorna il testo formattandolo (es. senza decimali)
            timertext.text = Mathf.CeilToInt(currentTime).ToString();
            // Sottrae il tempo passato tra i frame (più preciso di 1f)
            currentTime -= Time.deltaTime;
            yield return null;
        }
        if (isTimerRunning) // Se non è stato fermato manualmente
            {
                openGameOverPanel();
            }
        }

    public void StopTimerAndFinish()
    {
        isTimerRunning = false; // Ferma il ciclo while
        StopAllCoroutines();    // Blocca immediatamente la coroutine
        Debug.Log("Timer fermato per vittoria!");
    }

    void openGameOverPanel()
    {
        isTimerRunning = false; // ferma il timer
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