using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] public List<string> ListaIndizi = new();

    [SerializeField] private TMP_Text TestoDaMostrare;
    private void Mostra_indizio ()
    {
        int IndiceRandom = Random.Range(0, ListaIndizi.Count);
        TestoDaMostrare.text = ListaIndizi[IndiceRandom];
    }

    private void OnEnable()
    {
        Mostra_indizio();
        Debug.Log("Suggerimenti enabled");
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
