using UnityEngine;

/// <summary>
/// Gestisce l'attivazione e la disattivazione del pannello dei suggerimenti (Hint).
/// Permette di mostrare o nascondere il pannello ed eventualmente riprodurre un suono.
/// </summary>
public class ShowHint : MonoBehaviour
{
    /// <summary>
    /// Riferimento al pannello dei suggerimenti da mostrare o nascondere.
    /// </summary>
    public GameObject hintPanel;

    /// <summary>
    /// Riferimento all'AudioSource utilizzato per riprodurre un suono
    /// quando il pannello dei suggerimenti viene mostrato.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Metodo chiamato all'avvio dello script.
    /// Recupera l'AudioSource associato al GameObject.
    /// </summary>
    void Start()
    {
        // Recupera l'AudioSource se presente sul GameObject
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Metodo chiamato automaticamente da Unity quando l'utente
    /// clicca sul GameObject con il mouse.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="OnMouseDown()", shape=ellipse];
    ///     Call [label="ShowHintPanel()"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> Call -> End;
    /// }
    /// \enddot
    /// </remarks>
    void OnMouseDown()
    {
        // Mostra il pannello dei suggerimenti
        ShowHintPanel();
    }

    /// <summary>
    /// Mostra il pannello dei suggerimenti e riproduce un suono se disponibile.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="ShowHintPanel()", shape=ellipse];
    ///     CheckAudio [label="audioSource != null?", shape=diamond];
    ///     PlayAudio [label="audioSource.Play()"];
    ///     ShowPanel [label="hintPanel.SetActive(true)"];
    ///     Log [label="Debug.Log"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> CheckAudio;
    ///     CheckAudio -> PlayAudio [label="Sì"];
    ///     CheckAudio -> ShowPanel [label="No"];
    ///     PlayAudio -> ShowPanel;
    ///     ShowPanel -> Log;
    ///     Log -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void ShowHintPanel()
    {
        // Riproduce il suono associato, se presente
        if (audioSource != null)
            audioSource.Play();

        // Attiva il pannello dei suggerimenti
        hintPanel.SetActive(true);

        // Log di debug
        Debug.Log("Hint panel shown");
    }

    /// <summary>
    /// Nasconde il pannello dei suggerimenti.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="HideHintPanel()", shape=ellipse];
    ///     HidePanel [label="hintPanel.SetActive(false)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> HidePanel -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void HideHintPanel()
    {
        // Disattiva il pannello dei suggerimenti
        hintPanel.SetActive(false);
    }
}
