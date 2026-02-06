using UnityEngine;
/// <summary>
/// Gestisce la visibilità dei pannelli o delle voci di menu nell'interfaccia utente.
/// </summary>

public class MostraVoce : MonoBehaviour
{
    /// <summary>
    /// Attiva il pannello specificato e logga l'azione.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     In [label="Chiamata ShowAbout", shape=ellipse];
    ///     Set [label="VoceMenu.SetActive(true)"];
    ///     Log [label="Debug.Log"];
    ///     Out [label="Fine", shape=ellipse];
    ///     In -> Set -> Log -> Out;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="VoceMenu">Il GameObject da attivare.</param>
    


    public void ShowAbout(GameObject VoceMenu)

    {
        VoceMenu.SetActive(true);
        Debug.Log("About panel shown");         
    }
    /// <summary>
    /// Nasconde il pannello specificato.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     In [label="Chiamata HideAbout", shape=ellipse];
    ///     Set [label="VoceMenu.SetActive(false)", fillcolor=tomato, style=filled];
    ///     Out [label="Fine", shape=ellipse];
    ///     In -> Set -> Out;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="VoceMenu">Il GameObject da disattivare.</param>
    
    public void HideAbout(GameObject VoceMenu)
    {   // Nasconde il pannello
        VoceMenu.SetActive(false);
        
    }
}
