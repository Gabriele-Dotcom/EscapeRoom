using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsabile del caricamento delle scene di Unity.
/// Fornisce un metodo per cambiare scena gestendo eventuali errori.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Carica una scena specifica tramite il suo nome.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo LoadNewLevel:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Step1 [label="Inizio: LoadNewLevel(toLoad)", shape=ellipse];
    ///     TryBlock [label="Try: SceneManager.LoadScene(toLoad)", style=filled, fillcolor=lightyellow];
    ///     Success [label="Scena caricata correttamente?", shape=diamond, color=green];
    ///     CatchBlock [label="Catch: System.Exception", style=filled, fillcolor=mistyrose];
    ///     LogError [label="Debug.LogError: Scene doesn't exist"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Step1 -> TryBlock;
    ///     TryBlock -> Success [label="Sì"];
    ///     TryBlock -> CatchBlock [label="No"];
    ///     CatchBlock -> LogError;
    ///     Success -> End;
    ///     LogError -> End;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="toLoad">
    /// Nome della scena da caricare, deve essere presente nelle Build Settings.
    /// </param>
    public void LoadNewLevel(string toLoad)
    {
        // Blocco try per tentare il caricamento della scena
        try
        {
            // Carica la scena specificata dal nome
            SceneManager.LoadScene(toLoad);
        }
        // Gestione dell'eccezione nel caso la scena non esista o non sia caricabile
        catch (System.Exception)
        {
            // Log di errore in console
            Debug.LogError("Scene doesn't exist");
        }
    }

    /// <summary>
    /// Metodo chiamato una volta all'avvio dello script.
    /// Attualmente non contiene logica.
    /// </summary>
    void Start()
    {
        // Intenzionalmente vuoto
    }

    /// <summary>
    /// Metodo chiamato una volta per frame.
    /// Attualmente non contiene logica.
    /// </summary>
    void Update()
    {
        // Intenzionalmente vuoto
    }
}
