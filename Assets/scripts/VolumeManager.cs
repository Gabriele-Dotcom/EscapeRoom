using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// Gestisce il volume audio del gioco, sincronizzando Slider, AudioMixer e salvataggi locali.
/// </summary>

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    private string mixerParameter = "VolumeGenerale";
    private string sfxParam = "VolumeSFX";  
    /// <summary>
    /// Inizializza il volume all'avvio caricando i dati salvati.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     Init [label="Start()", shape=ellipse];
    ///     Prefs [label="PlayerPrefs.GetFloat"];
    ///     CheckSlider [label="Slider presente?", shape=diamond];
    ///     SetSlider [label="volumeSlider.value = savedVolume"];
    ///     Apply [label="ApplicaVolumeAlMixer()"];
    ///     Init -> Prefs -> CheckSlider;
    ///     CheckSlider -> SetSlider [label="Sì"];
    ///     CheckSlider -> Apply [label="No"];
    ///     SetSlider -> Apply;
    /// }
    /// \enddot
    /// </remarks>
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
    /// <summary>
    /// Aggiorna il mixer e salva il valore quando lo slider viene mosso.
    /// </summary>
    /// <param name="valoreSlider">Valore compreso tra 0 e 1.</param>

    // Questa funzione va collegata all'evento OnValueChanged dello Slider
    public void CambiaVolume(float valoreSlider)
    {
        ApplicaVolumeAlMixer(valoreSlider);

        // 4. Salva il valore ogni volta che muovi lo slider
        PlayerPrefs.SetFloat("SalvataggioVolume", valoreSlider);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Converte il valore lineare in Decibel e aggiorna l'AudioMixer.
    /// </summary>
    /// <remarks>
    /// La formula utilizzata è: $dB = \log_{10}(valore) \cdot 20$
    /// 
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///     
    ///     Val [label="Valore Lineare (0.0001 - 1.0)", shape=parallelogram];
    ///     Log [label="Mathf.Log10", style=filled, fillcolor=lightgrey];
    ///     Mult [label="Moltiplica x 20"];
    ///     Res [label="Decibel (-80 a 0)", shape=parallelogram];
    ///     Mix [label="mixer.SetFloat", shape=box, style=filled, fillcolor=lightgreen];
    ///     
    ///     Val -> Log -> Mult -> Res -> Mix;
    /// }
    /// \enddot
    /// </remarks>

    private void ApplicaVolumeAlMixer(float valore)
    {
        // Converte 0-1 in decibel (-80 a 0)
        float dB = Mathf.Log10(Mathf.Clamp(valore, 0.0001f, 1f)) * 20;
        mixer.SetFloat(mixerParameter, dB);
        mixer.SetFloat(sfxParam, dB);
    }
}