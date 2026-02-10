using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Gestisce la visualizzazione casuale di indizi testuali
/// selezionati da una lista predefinita.
/// </summary>
public class suggerimenti : MonoBehaviour
{
    /// <summary>
    /// Lista di stringhe contenente tutti gli indizi disponibili.
    /// Impostabile dall'Inspector.
    /// </summary>
    [SerializeField]
    public List<string> ListaIndizi = new();

    /// <summary>
    /// Riferimento al componente TextMeshPro UI
    /// utilizzato per mostrare l'indizio selezionato.
    /// </summary>
    [SerializeField]
    private TMP_Text TestoDaMostrare;

    /// <summary>
    /// Seleziona un indizio casuale dalla lista
    /// e lo visualizza nell'interfaccia utente.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo Mostra_indizio:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Inizio [label="Mostra_indizio()", shape=ellipse];
    ///     GetCount [label="ListaIndizi.Count"];
    ///     Randomize [label="Random.Range(0, Count)"];
    ///     UpdateUI [label="TestoDaMostrare.text = ListaIndizi[indice]"];
    ///     Fine [label="Fine", shape=ellipse];
    ///
    ///     Inizio -> GetCount -> Randomize -> UpdateUI -> Fine;
    /// }
    /// \enddot
    /// </remarks>
    private void Mostra_indizio()
    {
        // Genera un indice casuale in base al numero di indizi disponibili
        int IndiceRandom = Random.Range(0, ListaIndizi.Count);

        // Aggiorna il testo UI con l'indizio selezionato
        TestoDaMostrare.text = ListaIndizi[IndiceRandom];
    }

    /// <summary>
    /// Metodo di Unity chiamato automaticamente
    /// quando il GameObject viene attivato.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo OnEnable:
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Trigger [label="Evento OnEnable()", shape=ellipse, style=filled, fillcolor=orange];
    ///     Call [label="Esegui Mostra_indizio()"];
    ///     Log [label="Debug.Log: Suggerimenti enabled"];
    ///     Fine [label="Fine", shape=ellipse];
    ///
    ///     Trigger -> Call -> Log -> Fine;
    /// }
    /// \enddot
    /// </remarks>
    private void OnEnable()
    {
        // Mostra un indizio casuale quando l'oggetto viene abilitato
        Mostra_indizio();

        // Log di debug
        Debug.Log("Suggerimenti enabled");
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
