using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch_scene : MonoBehaviour
{
    public GameObject e;
    public string nomeScenaDaCaricare;
    void CambiaScena()
    {
        SceneManager.LoadScene(nomeScenaDaCaricare);
    }
    public void Transizione()
    {
        e.SetActive(true);
        Image img = e.GetComponent<Image>();
        //Transizione
        img.CrossFadeAlpha(254.0f, 3.0f, true);
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