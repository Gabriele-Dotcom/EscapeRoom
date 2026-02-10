using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestisce la transizione di fine livello e il caricamento
/// di una nuova scena tramite un effetto di dissolvenza.
/// </summary>
public class Switch_scene : MonoBehaviour
{
    /// <summary>
    /// GameObject utilizzato per l'effetto di transizione (es. immagine nera).
    /// </summary>
    public GameObject e = null;

    /// <summary>
    /// Pannello di vittoria mostrato prima del cambio scena.
    /// </summary>
    public GameObject pannelloVittoria = null;

    /// <summary>
    /// Nome della scena da caricare dopo la transizione.
    /// </summary>
    public string nomeScenaDaCaricare = null;

    /// <summary>
    /// Carica la scena specificata dal nome.
    /// Metodo richiamato tramite Invoke dopo la transizione.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="CambiaScena()", shape=ellipse];
    ///     Load [label="SceneManager.LoadScene(nomeScenaDaCaricare)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> Load -> End;
    /// }
    /// \enddot
    /// </remarks>
    void CambiaScena()
    {
        SceneManager.LoadScene(nomeScenaDaCaricare);
    }

    /// <summary>
    /// Avvia la transizione di fine livello mostrando il pannello di vittoria,
    /// eseguendo una dissolvenza e caricando la nuova scena.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo Transizione:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Start [label="Transizione()", shape=ellipse];
    ///     ShowPanel [label="pannelloVittoria.SetActive(true)?", shape=diamond];
    ///     ActivateE [label="e.SetActive(true)"];
    ///     GetImage [label="GetComponent<Image>()"];
    ///     Fade [label="img.CrossFadeAlpha(254, 3s)"];
    ///     InvokeLoad [label="Invoke CambiaScena (3s)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> ShowPanel;
    ///     ShowPanel -> ActivateE [label="Sì"];
    ///     ShowPanel -> ActivateE [label="No"];
    ///     ActivateE -> GetImage;
    ///     GetImage -> Fade;
    ///     Fade -> InvokeLoad;
    ///     InvokeLoad -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void Transizione()
    {
        // Attiva il pannello di vittoria se assegnato
        if (pannelloVittoria != null)
            pannelloVittoria.SetActive(true);

        // Attiva l'oggetto usato per la transizione
        e.SetActive(true);

        // Recupera il componente Image per l'effetto di dissolvenza
        Image img = e.GetComponent<Image>();

        // Esegue la dissolvenza dell'immagine
        img.CrossFadeAlpha(254.0f, 3.0f, true);

        // Carica la nuova scena dopo la durata della transizione
        Invoke("CambiaScena", 3.0f);
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
