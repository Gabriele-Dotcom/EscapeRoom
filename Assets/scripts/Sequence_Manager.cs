using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Sequenze : MonoBehaviour
{
    int corrette = 0;
    public int MAXcorrette;
    public List<GameObject> listaOggetti = new();
    List<GameObject> listaConfronto = new();
    public UnityEvent eventoFineSequenza;
    public void ConfrontaSequenze(GameObject obj)
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
