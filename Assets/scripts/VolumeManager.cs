using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    private string mixerParameter = "VolumeGenerale";

    void Start()
    {
        // 1. Carica il valore salvato. Se è la prima volta, usa 0.75
        float savedVolume = PlayerPrefs.GetFloat("SalvataggioVolume", 0.75f);

        Debug.Log("Caricamento Volume: " + savedVolume);

        // 2. Forza lo slider della scena attuale sulla posizione salvata
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }

        // 3. Applica il volume al Mixer
        ApplicaVolumeAlMixer(savedVolume);
    }

    // Questa funzione va collegata all'evento OnValueChanged dello Slider
    public void CambiaVolume(float valoreSlider)
    {
        ApplicaVolumeAlMixer(valoreSlider);

        // 4. Salva il valore ogni volta che muovi lo slider
        PlayerPrefs.SetFloat("SalvataggioVolume", valoreSlider);
        PlayerPrefs.Save();
    }

    private void ApplicaVolumeAlMixer(float valore)
    {
        // Converte 0-1 in decibel (-80 a 0)
        float dB = Mathf.Log10(Mathf.Clamp(valore, 0.0001f, 1f)) * 20;
        mixer.SetFloat(mixerParameter, dB);
    }
}