using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Gestisce il conto alla rovescia, il sistema di pausa
/// e l'attivazione della schermata di Game Over.
/// </summary>
public class timerscript : MonoBehaviour
{
    /// <summary>
    /// Pannello mostrato quando il tempo scade (Game Over).
    /// </summary>
    [SerializeField] GameObject GameOver_panel;

    /// <summary>
    /// Pannello della pausa di gioco.
    /// </summary>
    [SerializeField] GameObject panel_pausa;

    /// <summary>
    /// Riferimento al testo UI che visualizza il tempo rimanente.
    /// </summary>
    [SerializeField] TextMeshProUGUI timertext;

    /// <summary>
    /// Durata iniziale del timer.
    /// </summary>
    [SerializeField] float Duration;

    /// <summary>
    /// Tempo corrente rimanente.
    /// </summary>
    private float currentTime;

    /// <summary>
    /// Indica se il timer è attualmente in esecuzione.
    /// </summary>
    private bool isTimerRunning = false;

    /// <summary>
    /// Stato attuale della pausa.
    /// </summary>
    private bool isPaused = false;

    /// <summary>
    /// Inizializzazione del timer e dei pannelli UI.
    /// Avvia la coroutine del conto alla rovescia.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Start [label="Start()", shape=ellipse];
    ///     HideGO [label="GameOver_panel.SetActive(false)"];
    ///     HidePause [label="panel_pausa.SetActive(false)?", shape=diamond];
    ///     InitTime [label="currentTime = Duration"];
    ///     SetRun [label="isTimerRunning = true"];
    ///     ResetScale [label="Time.timeScale = 1"];
    ///     StartCo [label="StartCoroutine(timeIEn)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> HideGO -> HidePause -> InitTime -> SetRun -> ResetScale -> StartCo -> End;
    /// }
    /// \enddot
    /// </remarks>
    void Start()
    {
        GameOver_panel.SetActive(false);

        if (panel_pausa != null)
            panel_pausa.SetActive(false);

        currentTime = Duration;
        isTimerRunning = true;
        Time.timeScale = 1f;

        StartCoroutine(timeIEn());
    }

    /// <summary>
    /// Alterna lo stato di pausa del gioco,
    /// agendo sul Time.timeScale e sulla UI.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="TogglePause()", shape=ellipse];
    ///     CheckNull [label="panel_pausa == null?", shape=diamond];
    ///     Toggle [label="isPaused = !isPaused"];
    ///     Check [label="isPaused?", shape=diamond];
    ///     PauseOn [label="Time.timeScale = 0\nMostra panel_pausa", style=filled, fillcolor=mistyrose];
    ///     PauseOff [label="Time.timeScale = 1\nNasconde panel_pausa", style=filled, fillcolor=lightgreen];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> CheckNull;
    ///     CheckNull -> End [label="Sì"];
    ///     CheckNull -> Toggle [label="No"];
    ///     Toggle -> Check;
    ///     Check -> PauseOn [label="Vero"];
    ///     Check -> PauseOff [label="Falso"];
    ///     PauseOn -> End;
    ///     PauseOff -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void TogglePause()
    {
        if (panel_pausa == null) return;

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            panel_pausa.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            panel_pausa.SetActive(false);
        }
    }

    /// <summary>
    /// Coroutine che decrementa il tempo rimanente
    /// aggiornando il testo UI ogni frame.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Loop [label="currentTime > 0 && isTimerRunning?", shape=diamond];
    ///     UpdateUI [label="Aggiorna timertext"];
    ///     Sub [label="currentTime -= Time.deltaTime"];
    ///     Wait [label="yield return null", style=dashed];
    ///     CheckEnd [label="isTimerRunning && currentTime <= 0?", shape=diamond];
    ///     GameOver [label="openGameOverPanel()", style=filled, fillcolor=orange];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Loop -> UpdateUI [label="Sì"];
    ///     UpdateUI -> Sub -> Wait;
    ///     Wait -> Loop;
    ///     Loop -> CheckEnd [label="No"];
    ///     CheckEnd -> GameOver [label="Sì"];
    ///     CheckEnd -> End [label="No"];
    /// }
    /// \enddot
    /// </remarks>
    IEnumerator timeIEn()
    {
        while (currentTime > 0 && isTimerRunning)
        {
            timertext.text = Mathf.CeilToInt(currentTime).ToString();
            currentTime -= Time.deltaTime;
            yield return null;
        }

        if (isTimerRunning && currentTime <= 0)
        {
            openGameOverPanel();
        }
    }

    /// <summary>
    /// Ferma il timer in caso di vittoria,
    /// bloccando immediatamente la coroutine.
    /// </summary>
    public void StopTimerAndFinish()
    {
        isTimerRunning = false;
        StopAllCoroutines();
        Debug.Log("Timer fermato per vittoria!");
    }

    /// <summary>
    /// Attiva il pannello di Game Over
    /// e avvia la transizione di cambio scena.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="openGameOverPanel()", shape=ellipse];
    ///     StopTimer [label="isTimerRunning = false"];
    ///     ResetText [label="timertext = 0"];
    ///     ShowPanel [label="GameOver_panel.SetActive(true)"];
    ///     GetSwitch [label="GetComponent<Switch_scene>()"];
    ///     Check [label="scriptScena != null?", shape=diamond];
    ///     Transition [label="scriptScena.Transizione()", style=filled, fillcolor=lightblue];
    ///     Error [label="Debug.LogError"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> StopTimer -> ResetText -> ShowPanel -> GetSwitch;
    ///     GetSwitch -> Check;
    ///     Check -> Transition [label="Sì"];
    ///     Check -> Error [label="No"];
    ///     Transition -> End;
    ///     Error -> End;
    /// }
    /// \enddot
    /// </remarks>
    void openGameOverPanel()
    {
        isTimerRunning = false;
        timertext.text = "0";
        GameOver_panel.SetActive(true);

        Switch_scene scriptScena = GameOver_panel.GetComponent<Switch_scene>();

        if (scriptScena != null)
        {
            scriptScena.Transizione();
        }
        else
        {
            Debug.LogError("Attenzione: non ho trovato lo script Switch_scene sull'oggetto GameOver_panel!");
        }
    }
}
