using UnityEngine;
/// <summary>
/// Gestisce l'attivazione e disattivazione del pannello dei suggerimenti (Hint).
/// </summary>
public class ShowHint : MonoBehaviour
{
    /// <summary>
    /// Riferimento al pannello UI del suggerimento.
    /// </summary>
    public GameObject hintPanel;
    /// <summary>
    /// Attiva il pannello del suggerimento e stampa un log di conferma.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     In [label="Chiamata ShowHintPanel", shape=ellipse];
    ///     Active [label="hintPanel.SetActive(true)", style=filled, fillcolor=lightgreen];
    ///     Log [label="Debug.Log"];
    ///     Out [label="Fine", shape=ellipse];
    ///     In -> Active -> Log -> Out;
    /// }
    /// \enddot
    /// </remarks

    public void ShowHintPanel()
    {
        hintPanel.SetActive(true);
        Debug.Log("Hint panel shown");
    }
    /// <summary>
    /// Disattiva il pannello del suggerimento.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     In [label="Chiamata HideHintPanel", shape=ellipse];
    ///     Deactive [label="hintPanel.SetActive(false)", style=filled, fillcolor=mistyrose];
    ///     Out [label="Fine", shape=ellipse];
    ///     In -> Deactive -> Out;
    /// }
    /// \enddot
    /// </remarks>

    public void HideHintPanel()
    {
        hintPanel.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
