using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch_scene : MonoBehaviour
{
    public GameObject e;
    public GameObject T;
    public string NomeScena;
    void CambiaScena()
    {
       
        SceneManager.LoadScene(NomeScena);
    }
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
