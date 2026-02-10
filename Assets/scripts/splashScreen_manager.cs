using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Gestisce la schermata iniziale (Splash Screen)
/// con un passaggio temporizzato alla scena successiva.
/// </summary>
public class SplashManager : MonoBehaviour
{
    /// <summary>
    /// Tempo di attesa in secondi prima di cambiare scena.
    /// </summary>
    public float attesa = 3.5f;

    /// <summary>
    /// Nome della scena da caricare dopo lo splash screen.
    /// </summary>
    public string nomeScenaGioco = "Main";

    /// <summary>
    /// Avvia la coroutine di caricamento all'inizio del ciclo di vita dello script.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Start [label="Start()", shape=ellipse];
    ///     StartCo [label="StartCoroutine(VaiAlGioco())"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> StartCo -> End;
    /// }
    /// \enddot
    /// </remarks>
    void Start()
    {
        StartCoroutine(VaiAlGioco());
    }

    /// <summary>
    /// Coroutine che gestisce l'attesa temporizzata e il caricamento della scena successiva.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Start [label="VaiAlGioco()", shape=ellipse];
    ///     Wait [label="yield return new WaitForSeconds(attesa)", style=filled, fillcolor=lightyellow];
    ///     Timer [label="Attesa Terminata?", shape=diamond];
    ///     Load [label="SceneManager.LoadScene(nomeScenaGioco)", style=filled, fillcolor=lightblue];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> Wait -> Timer;
    ///     Timer -> Wait [label="No (Continua attesa)"];
    ///     Timer -> Load [label="Sì"];
    ///     Load -> End;
    /// }
    /// \enddot
    /// </remarks>
    IEnumerator VaiAlGioco()
    {
        // Attende il tempo definito per la splash screen
        yield return new WaitForSeconds(attesa);

        // Carica la scena principale
        SceneManager.LoadScene(nomeScenaGioco);
    }
}
