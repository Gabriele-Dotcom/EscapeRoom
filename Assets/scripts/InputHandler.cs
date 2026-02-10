using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
/// <summary>
/// Gestisce l'input utente per l'interazione con oggetti nel mondo 2D.
/// </summary>


public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    /// <summary>
    /// Metodo invocato dal sistema di Input (Input Action Asset).
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     edge [fontname=Helvetica, fontsize=8];
    ///     
    ///     Start [label="onClick Event", shape=ellipse, style=filled, fillcolor=lightgrey];
    ///     CheckContext [label="context.started?"];
    ///     Raycast [label="Esegui Raycast 2D"];
    ///     HitCheck [label="Colpito qualcosa?", shape=diamond];
    ///     TagCheck [label="Tag è 'Hint'?", shape=diamond];
    ///     LogEmpty [label="Debug: Niente di interessante"];
    ///     ShowHint [label="Esegui ShowHintPanel()", style=filled, fillcolor=lightblue];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> CheckContext;
    ///     CheckContext -> End [label="No"];
    ///     CheckContext -> Raycast [label="Sì"];
    ///     Raycast -> HitCheck;
    ///     HitCheck -> LogEmpty [label="No"];
    ///     HitCheck -> TagCheck [label="Sì"];
    ///     TagCheck -> ShowHint [label="Sì"];
    ///     TagCheck -> End [label="No"];
    ///     LogEmpty -> End;
    ///     ShowHint -> End;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="context">Informazioni sul contesto dell'azione di input.</param>

    public void onClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue()));
        /*if(rayHit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
        {
            GameObject HintAperti = GameObject.FindGameObjectWithTag("Hint_open");
            if (HintAperti != null) HintAperti.SetActive(false); else Debug.Log("Nessun pannello hint aperto da chiudere");
        }*/
        if (!rayHit.collider)
        {
            Debug.Log("Niente di interessante");
            return;
        }
        else if (rayHit.collider.CompareTag("Hint"))
        {
            rayHit.collider.GetComponent<ShowHint>()?.ShowHintPanel();
            Debug.Log(rayHit.collider.gameObject.name);
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
