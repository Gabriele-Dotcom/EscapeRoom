using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void onClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Pointer.current.position.ReadValue()));
        if(!rayHit.collider) return;

        rayHit.collider.GetComponent<ShowHint>()?.ShowHintPanel();
        //rayHit.collider.GetComponent<ShowHint>()?.HideHintPanel();

        Debug.Log(rayHit.collider.gameObject.name);
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
