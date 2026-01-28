using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewLevel(string toLoad)
    {
        try
        {
            SceneManager.LoadScene(toLoad);
        }
        catch(System.Exception)
        {
            Debug.LogError("Scene doesn't exist");
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
