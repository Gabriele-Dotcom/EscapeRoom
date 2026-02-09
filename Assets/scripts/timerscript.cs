using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// Gestisce il conto alla rovescia, il sistema di pausa e l'attivazione del Game Over.
/// </summary>
public class timerscript : MonoBehaviour
{

    [SerializeField] GameObject GameOver_panel;

    [SerializeField] GameObject panel_pausa;

    [SerializeField] TextMeshProUGUI timertext;

    [SerializeField] float Duration;

    private float currentTime;
    private bool isTimerRunning = false; // variabile per controllare se il timer è in esecuzione
    private bool isPaused = false; // Stato della pausa

    void Start()
    {
        GameOver_panel.SetActive(false);
        if (panel_pausa != null) panel_pausa.SetActive(false); // Assicurati che parta chiuso

        currentTime = Duration;
        isTimerRunning = true;
        Time.timeScale = 1f; // Resetta il tempo all'avvio

        StartCoroutine(timeIEn());
    }
    /// <summary>
    /// Alterna lo stato di pausa del gioco, agendo sul Time.timeScale.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     In [label="TogglePause()", shape=ellipse];
    ///     Check [label="isPaused?", shape=diamond];
    ///     PauseOn [label="Time.timeScale = 0\nMostra Panel", style=filled, fillcolor=mistyrose];
    ///     PauseOff [label="Time.timeScale = 1\nNasconde Panel", style=filled, fillcolor=lightgreen];
    ///     
    ///     In -> Check;
    ///     Check -> PauseOn [label="Vero"];
    ///     Check -> PauseOff [label="Falso"];
    /// }
    /// \enddot
    /// </remarks>
    public void TogglePause()
    {
        if (panel_pausa == null) return;

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Blocca il tempo e il timer
            panel_pausa.SetActive(true);
            
        }
        else
        {
            Time.timeScale = 1f; // Riprende il tempo
            panel_pausa.SetActive(false);
       
        }
    }
    /// <summary>
    /// Coroutine che decrementa il tempo ogni frame.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     Loop [label="Tempo > 0?", shape=diamond];
    ///     UpdateUI [label="Aggiorna timertext"];
    ///     Sub [label="Sottrai Time.deltaTime"];
    ///     Wait [label="yield return null", style=dashed];
    ///     CheckEnd [label="isTimerRunning && Tempo <= 0?", shape=diamond];
    ///     GameOver [label="openGameOverPanel()", style=filled, fillcolor=orange];
    ///
    ///     Loop -> UpdateUI [label="Sì"];
    ///     UpdateUI -> Sub -> Wait;
    ///     Wait -> Loop;
    ///     Loop -> CheckEnd [label="No"];
    ///     CheckEnd -> GameOver [label="Sì"];
    ///     CheckEnd -> Fine [label="No"];
    /// }
    /// \enddot
    /// </remarks>

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
        if (isTimerRunning && currentTime <= 0) // Se non è stato fermato manualmente
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
    /// <summary>
    /// Attiva il pannello di fine gioco e avvia la transizione scenica.
    /// </summary>

    void openGameOverPanel()
    {
        isTimerRunning = false; // ferma il timer
        timertext.text = "0"; // Pulisce il testo del timer
        GameOver_panel.SetActive(true); // Mostra il pannello con la scritta Game Over

        // Cerchiamo lo script Switch_scene sul GameOver_panel
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