using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/// <summary>
/// Gestisce la schermata iniziale (Splash Screen) con un passaggio temporizzato alla scena successiva.
/// </summary>
public class SplashManager : MonoBehaviour
{
    /// <summary>
    /// Tempo di attesa in secondi prima di cambiare scena.
    /// </summary>
    public float attesa = 3.5f; // Tempo visibilità logo
    /// <summary>
    /// Nome della scena da caricare dopo lo splash screen.
    /// </summary>
    public string nomeScenaGioco = "Main";
    /// <summary>
    /// Avvia la coroutine di caricamento all'inizio del ciclo di vita dello script.
    /// </summary>
    void Start()
    {
        StartCoroutine(VaiAlGioco());
    }
    /// <summary>
    /// Coroutine che gestisce l'attesa temporizzata e il caricamento della scena.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     Start [label="Inizio Coroutine", shape=ellipse];
    ///     Wait [label="yield return new WaitForSeconds(attesa)", style=filled, fillcolor=lightyellow];
    ///     Timer [label="Attesa Terminata?", shape=diamond];
    ///     Load [label="SceneManager.LoadScene(nomeScenaGioco)", style=filled, fillcolor=lightblue];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> Wait;
    ///     Wait -> Timer;
    ///     Timer -> Wait [label="No (Continua attesa)"];
    ///     Timer -> Load [label="Sì"];
    ///     Load -> End;
    /// }
    /// \enddot
    /// </remarks>

    IEnumerator VaiAlGioco()
    {
        yield return new WaitForSeconds(attesa);
        SceneManager.LoadScene(nomeScenaGioco);
    }
}