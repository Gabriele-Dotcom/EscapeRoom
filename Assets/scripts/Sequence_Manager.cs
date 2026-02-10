using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Gestisce la validazione di una sequenza di oggetti selezionati dall'utente.
/// Confronta la sequenza inserita con quella corretta e attiva eventi o messaggi di errore.
/// </summary>
public class Sequenze : MonoBehaviour
{
    /// <summary>
    /// Lista degli oggetti che rappresentano la sequenza corretta (soluzione).
    /// Impostabile dall'Inspector.
    /// </summary>
    [SerializeField] List<GameObject> listaOggetti = new();

    /// <summary>
    /// Lista temporanea contenente gli oggetti selezionati dall'utente.
    /// Viene confrontata con la sequenza corretta.
    /// </summary>
    List<GameObject> listaConfronto = new();

    /// <summary>
    /// Evento invocato quando la sequenza inserita è corretta.
    /// </summary>
    [SerializeField] UnityEvent eventoFineSequenza;

    /// <summary>
    /// GameObject utilizzato per mostrare un messaggio di errore
    /// quando la sequenza è errata.
    /// </summary>
    [SerializeField] GameObject ErroreSequenza = null;

    /// <summary>
    /// Aggiunge un oggetto alla sequenza corrente e verifica
    /// se la sequenza inserita dall'utente è corretta.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo ConfrontaSequenze:
    ///
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     edge [fontname=Helvetica, fontsize=9];
    ///
    ///     Inizio [label="ConfrontaSequenze(obj)", shape=ellipse];
    ///     AddList [label="Aggiungi obj a listaConfronto"];
    ///     CheckCount [label="listaConfronto.Count == listaOggetti.Count?", shape=diamond];
    ///     CheckEqual [label="SequenceEqual(listaOggetti)?", shape=diamond];
    ///     LogWin [label="Debug.Log: Sequenza Corretta"];
    ///     InvokeEvent [label="eventoFineSequenza.Invoke()", style=filled, fillcolor=lightgreen];
    ///     ShowError [label="ErroreSequenza.SetActive(true)", style=filled, fillcolor=mistyrose];
    ///     DelayHide [label="Invoke StopMessaggioErrore (4s)"];
    ///     ClearList [label="listaConfronto.Clear()"];
    ///     Fine [label="Fine", shape=ellipse];
    ///
    ///     Inizio -> AddList;
    ///     AddList -> CheckCount;
    ///     CheckCount -> Fine [label="No"];
    ///     CheckCount -> CheckEqual [label="Sì"];
    ///     CheckEqual -> LogWin [label="Sì"];
    ///     LogWin -> InvokeEvent;
    ///     InvokeEvent -> ClearList;
    ///     CheckEqual -> ShowError [label="No"];
    ///     ShowError -> DelayHide;
    ///     DelayHide -> ClearList;
    ///     ClearList -> Fine;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="obj">
    /// Oggetto selezionato dall'utente da aggiungere alla sequenza corrente.
    /// </param>
    public void ConfrontaSequenze(GameObject obj)
    {
        // Aggiunge l'oggetto selezionato alla lista di confronto
        listaConfronto.Add(obj);

        // Log di debug per visualizzare gli oggetti inseriti nella sequenza
        foreach (GameObject obj1 in listaConfronto)
            Debug.Log(obj1.name);

        // Verifica se la sequenza inserita ha raggiunto la lunghezza corretta
        if (listaConfronto.Count == listaOggetti.Count)
        {
            // Confronta la sequenza inserita con quella corretta
            if (listaConfronto.SequenceEqual(listaOggetti))
            {
                // Sequenza corretta: log e invocazione evento finale
                Debug.Log("Sequenza Corretta");
                eventoFineSequenza.Invoke();
            }
            else
            {
                // Sequenza errata: mostra messaggio di errore temporaneo
                ErroreSequenza.SetActive(true);
                Invoke("StopMessaggioErrore", 4.0f);
            }

            // Reset della sequenza di confronto per un nuovo tentativo
            listaConfronto.Clear();
        }
    }

    /// <summary>
    /// Nasconde il messaggio di errore della sequenza.
    /// Metodo richiamato tramite Invoke dopo un ritardo.
    /// </summary>
    private void StopMessaggioErrore()
    {
        // Disattiva il pannello di errore
        ErroreSequenza.SetActive(false);
    }
}
