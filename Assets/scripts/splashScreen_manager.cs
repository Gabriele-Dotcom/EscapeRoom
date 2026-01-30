using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashManager : MonoBehaviour
{
    public float attesa = 3.5f; // Tempo visibilità logo
    public string nomeScenaGioco = "Main"; 

    void Start()
    {
        StartCoroutine(VaiAlGioco());
    }

    IEnumerator VaiAlGioco()
    {
        yield return new WaitForSeconds(attesa);
        SceneManager.LoadScene(nomeScenaGioco);
    }
}