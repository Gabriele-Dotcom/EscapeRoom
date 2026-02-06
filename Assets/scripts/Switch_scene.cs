using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Gestisce la transizione visiva tra due scene utilizzando un effetto di dissolvenza.
/// </summary>
public class Switch_scene : MonoBehaviour
{
    /// <summary> Oggetto che contiene l'immagine per la dissolvenza (es. un pannello nero). </summary>
    public GameObject e;
    /// <summary> Oggetto da disattivare all'inizio della transizione (es. il menu attuale). </summary>
    public GameObject T;
    /// <summary> Nome della scena di destinazione. </summary>
    public string NomeScena;
    /// <summary>
    /// Esegue il caricamento effettivo della scena. Metodo richiamato tramite Invoke.
    /// </summary>
    void CambiaScena()
    {
       
        SceneManager.LoadScene(NomeScena);
    }
    /// <summary>
    /// Avvia la sequenza di transizione: spegne la UI attuale, attiva l'effetto fade e prenota il cambio scena.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     edge [fontname=Helvetica, fontsize=9];
    ///
    ///     Start [label="Chiamata Transizione()", shape=ellipse];
    ///     UI_Toggle [label="T.SetActive(false)\ne.SetActive(true)"];
    ///     Fade [label="img.CrossFadeAlpha(254, 3s)", style=filled, fillcolor=lightyellow];
    ///     Timer [label="Invoke('CambiaScena', 3s)", style=filled, fillcolor=lightblue];
    ///     Wait [label="Attesa 3 secondi...", shape=invhouse, style=dashed];
    ///     Load [label="SceneManager.LoadScene()", shape=box, style=filled, fillcolor=lightgreen];
    ///     End [label="Nuova Scena Caricata", shape=ellipse];
    ///
    ///     Start -> UI_Toggle;
    ///     UI_Toggle -> Fade;
    ///     Fade -> Timer;
    ///     Timer -> Wait;
    ///     Wait -> Load;
    ///     Load -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void Transizione()
    {
        T.SetActive(false);
        e.SetActive(true);
        Image img = e.GetComponent<Image>();
        //Transizione
        img.CrossFadeAlpha(254.0f, 3.0f, false);  
        //Carica nuova scena
        Invoke("CambiaScena", 3.0f);
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
