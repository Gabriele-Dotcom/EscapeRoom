using UnityEngine;

/// <summary>
/// Gestisce la visibilità dei pannelli o delle voci di menu nell'interfaccia utente.
/// Questa classe fornisce metodi per mostrare e nascondere elementi UI.
/// </summary>
public class MostraVoce : MonoBehaviour
{
    /// <summary>
    /// Attiva il pannello specificato e registra l'azione nel log.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo ShowAbout:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="Chiamata ShowAbout", shape=ellipse];
    ///     Set [label="VoceMenu.SetActive(true)"];
    ///     Log [label="Debug.Log"];
    ///     Out [label="Fine", shape=ellipse];
    ///
    ///     In -> Set -> Log -> Out;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="VoceMenu">
    /// Il GameObject della voce di menu o pannello UI da attivare.
    /// </param>
    public void ShowAbout(GameObject VoceMenu)
    {
        // Attiva la voce di menu o pannello UI
        VoceMenu.SetActive(true);

        // Log dell'avvenuta visualizzazione del pannello
        Debug.Log("About panel shown");
    }

    /// <summary>
    /// Disattiva (nasconde) il pannello specificato.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo HideAbout:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="Chiamata HideAbout", shape=ellipse];
    ///     Set [label="VoceMenu.SetActive(false)", fillcolor=tomato, style=filled];
    ///     Out [label="Fine", shape=ellipse];
    ///
    ///     In -> Set -> Out;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="VoceMenu">
    /// Il GameObject della voce di menu o pannello UI da disattivare.
    /// </param>
    public void HideAbout(GameObject VoceMenu)
    {
        // Disattiva la voce di menu o pannello UI
        VoceMenu.SetActive(false);
    }
}
