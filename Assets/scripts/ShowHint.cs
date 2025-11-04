using UnityEngine;

public class ShowHint : MonoBehaviour
{
    public GameObject hintPanel;

    public void ShowHintPanel()
    {
        hintPanel.SetActive(true);
        Debug.Log("Hint panel shown");
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
