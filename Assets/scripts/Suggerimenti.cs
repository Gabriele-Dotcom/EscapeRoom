using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Gestisce la visualizzazione casuale di indizi testuali presi da una lista predefinita.
/// </summary>
public class suggerimenti : MonoBehaviour
{
    /// <summary>
    /// Lista di stringhe contenente tutti gli indizi possibili.
    /// </summary>
    [SerializeField] public List<string> ListaIndizi = new();
    /// <summary>
    /// Riferimento al componente TextMeshPro UI dove verrà scritto l'indizio.
    /// </summary>
    [SerializeField] private TMP_Text TestoDaMostrare;
    /// <remarks>
    /// Visualizza il flusso logico del metodo:
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     Inizio -> GetCount -> Randomize -> UpdateUI -> Fine;
    /// }
    /// \enddot
    /// </remarks>
    private void Mostra_indizio()
    {
        int IndiceRandom = Random.Range(0, ListaIndizi.Count);
        TestoDaMostrare.text = ListaIndizi[IndiceRandom];
    }
    /// <summary>
    /// Metodo di Unity chiamato quando l'oggetto viene attivato.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     Trigger [label="Evento OnEnable()", shape=ellipse, style=filled, fillcolor=orange];
    ///     Call [label="Esegui Mostra_indizio()"];
    ///     Log [label="Debug.Log: Suggerimenti enabled"];
    ///     
    ///     Trigger -> Call -> Log;
    /// }
    /// \enddot
    /// </remarks>

    private void OnEnable()
    {
        Mostra_indizio();
        Debug.Log("Suggerimenti enabled");
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
