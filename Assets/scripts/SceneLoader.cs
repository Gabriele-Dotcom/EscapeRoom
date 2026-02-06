using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Classe responsabile del caricamento delle scene di Unity.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Carica una scena specifica tramite il suo nome.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     Step1 [label="Inizio: LoadNewLevel(toLoad)", shape=ellipse];
    ///     TryBlock [label="Try: SceneManager.LoadScene", style=filled, fillcolor=lightyellow];
    ///     Success [label="Scena Caricata", shape=diamond, color=green];
    ///     CatchBlock [label="Catch: System.Exception", style=filled, fillcolor=mistyrose];
    ///     LogError [label="Debug.LogError: Scene doesn't exist"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Step1 -> TryBlock;
    ///     TryBlock -> Success [label="Successo"];
    ///     TryBlock -> CatchBlock [label="Errore"];
    ///     CatchBlock -> LogError;
    ///     Success -> End;
    ///     LogError -> End;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="toLoad">Nome della scena da caricare presente nelle Build Settings.</param>
    
    public void LoadNewLevel(string toLoad)
    {
        try
        {
            SceneManager.LoadScene(toLoad);
        }
        catch(System.Exception)
        {
            Debug.LogError("Scene doesn't exist");
        }
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
