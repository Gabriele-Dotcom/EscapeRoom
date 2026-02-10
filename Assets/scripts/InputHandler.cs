using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

/// <summary>
/// Gestisce l'input utente per l'interazione con oggetti nel mondo 2D.
/// Questa classe intercetta il click dell'utente e verifica se è stato colpito
/// un oggetto rilevante tramite Raycast 2D.
/// </summary>
public class InputHandler : MonoBehaviour
{
    /// <summary>
    /// Riferimento alla camera principale della scena.
    /// Utilizzata per convertire la posizione del puntatore da schermo a mondo.
    /// </summary>
    private Camera _mainCamera;

    /// <summary>
    /// Inizializzazione dei riferimenti necessari.
    /// Recupera la Camera principale all'avvio dello script.
    /// </summary>
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    /// <summary>
    /// Metodo invocato dal sistema di Input (Input Action Asset).
    /// Gestisce il click dell'utente e l'interazione con oggetti 2D.
    /// </summary>
    /// <remarks>
    /// Flusso logico del metodo onClick:
    ///
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     edge [fontname=Helvetica, fontsize=8];
    ///
    ///     Start [label="Evento onClick", shape=ellipse, style=filled, fillcolor=lightgrey];
    ///     CheckStarted [label="context.started?"];
    ///     ExitEarly [label="Ritorna (ignora input)"];
    ///     Raycast [label="Raycast 2D dalla posizione del puntatore"];
    ///     HitCheck [label="Collider colpito?", shape=diamond];
    ///     LogEmpty [label="Debug.Log: Niente di interessante"];
    ///     TagCheck [label="Tag == Hint?", shape=diamond];
    ///     ShowHint [label="ShowHintPanel()", style=filled, fillcolor=lightblue];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> CheckStarted;
    ///     CheckStarted -> ExitEarly [label="No"];
    ///     CheckStarted -> Raycast [label="Sì"];
    ///     ExitEarly -> End;
    ///     Raycast -> HitCheck;
    ///     HitCheck -> LogEmpty [label="No"];
    ///     HitCheck -> TagCheck [label="Sì"];
    ///     LogEmpty -> End;
    ///     TagCheck -> ShowHint [label="Sì"];
    ///     TagCheck -> End [label="No"];
    ///     ShowHint -> End;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="context">
    /// Contesto dell'azione di input fornito dal sistema Input System.
    /// Contiene informazioni sullo stato dell'input (started, performed, canceled).
    /// </param>
    public void onClick(InputAction.CallbackContext context)
    {
        // Verifica che l'evento sia appena iniziato
        if (!context.started) return;

        // Esegue un Raycast 2D dalla posizione del puntatore sullo schermo
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(
            _mainCamera.ScreenPointToRay(
                Pointer.current.position.ReadValue()
            )
        );

        /*
         * Blocco commentato:
         * Logica opzionale per chiudere pannelli Hint aperti
         * quando si clicca fuori dall'interfaccia UI.
         */

        // Se il Raycast non colpisce alcun collider
        if (!rayHit.collider)
        {
            // Nessun oggetto rilevante colpito
            Debug.Log("Niente di interessante");
            return;
        }
        // Se il collider colpito ha il tag "Hint"
        else if (rayHit.collider.CompareTag("Hint"))
        {
            // Recupera il componente ShowHint e mostra il pannello Hint
            rayHit.collider.GetComponent<ShowHint>()?.ShowHintPanel();

            // Log del nome dell'oggetto colpito
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }

    /// <summary>
    /// Metodo chiamato una volta prima del primo Update.
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
