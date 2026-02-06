using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
/// <summary>
/// Gestisce la validazione di una sequenza di oggetti selezionati dall'utente.
/// </summary>
public class Sequenze : MonoBehaviour
{
    int corrette = 0;
    public int MAXcorrette;
    public List<GameObject> listaOggetti = new();
    List<GameObject> listaConfronto = new();
    public UnityEvent eventoFineSequenza;
    public void ConfrontaSequenze(GameObject obj)
    /// <summary>
    /// Aggiunge un oggetto alla sequenza corrente e verifica se corrisponde alla soluzione.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     edge [fontname=Helvetica, fontsize=9];
    ///
    ///     Inizio [label="ConfrontaSequenze(obj)", shape=ellipse];
    ///     AddList [label="Aggiungi obj a listaConfronto"];
    ///     CheckCount [label="Count == 3?", shape=diamond];
    ///     CheckEqual [label="SequenceEqual?", shape=diamond];
    ///     LogWin [label="Debug: Sequenza Corretta"];
    ///     InvokeEvent [label="eventoFineSequenza.Invoke()", style=filled, fillcolor=lightgreen];
    ///     ClearList [label="listaConfronto.Clear()", style=filled, fillcolor=mistyrose];
    ///     Fine [label="Fine", shape=ellipse];
    ///
    ///     Inizio -> AddList;
    ///     AddList -> CheckCount;
    ///     CheckCount -> Fine [label="No"];
    ///     CheckCount -> CheckEqual [label="Sì"];
    ///     CheckEqual -> LogWin [label="Sì"];
    ///     LogWin -> InvokeEvent;
    ///     InvokeEvent -> Fine;
    ///     CheckEqual -> ClearList [label="No"];
    ///     ClearList -> Fine;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="obj">L'oggetto selezionato da aggiungere alla sequenza.</param>
    {
        //Debug.Log("La lista contiene " + listaOggetti.Count + " elementi.");
        listaConfronto.Add(obj);
        if (listaConfronto.Count == 3)
        {
            if (listaConfronto.SequenceEqual(listaOggetti))
            {
                Debug.Log("Sequenza Corretta");
                eventoFineSequenza.Invoke();
            }
            else
                listaConfronto.Clear();
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
