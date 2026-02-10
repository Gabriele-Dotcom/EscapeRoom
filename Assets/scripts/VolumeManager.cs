using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Gestisce il volume audio del gioco, sincronizzando
/// Slider, AudioMixer e salvataggi locali tramite PlayerPrefs.
/// </summary>
public class VolumeManager : MonoBehaviour
{
    /// <summary>
    /// Riferimento all'AudioMixer principale.
    /// </summary>
    public AudioMixer mixer;

    /// <summary>
    /// Slider UI usato per modificare il volume.
    /// </summary>
    public Slider volumeSlider;

    /// <summary>
    /// Nome del parametro del mixer per il volume generale.
    /// </summary>
    private string mixerParameter = "VolumeGenerale";

    /// <summary>
    /// Nome del parametro del mixer per il volume degli effetti SFX.
    /// </summary>
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
    ///     Apply [label="ApplicaVolumeAlMixer(savedVolume)"];
    ///     Init -> Prefs -> CheckSlider;
    ///     CheckSlider -> SetSlider [label="Sì"];
    ///     CheckSlider -> Apply [label="No"];
    ///     SetSlider -> Apply;
    /// }
    /// \enddot
    /// </remarks>
    void Start()
    {
        // 1. Carica il valore salvato o usa il default 0.75
        float savedVolume = PlayerPrefs.GetFloat("SalvataggioVolume", 0.75f);
        Debug.Log("Caricamento Volume: " + savedVolume);

        // 2. Aggiorna lo slider se presente
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }

        // 3. Applica il volume al mixer
        ApplicaVolumeAlMixer(savedVolume);
    }

    /// <summary>
    /// Aggiorna il mixer e salva il valore quando lo slider viene mosso.
    /// Collegare questo metodo all'evento OnValueChanged dello Slider.
    /// </summary>
    /// <param name="valoreSlider">Valore compreso tra 0 e 1.</param>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="CambiaVolume(valoreSlider)", shape=ellipse];
    ///     Apply [label="ApplicaVolumeAlMixer(valoreSlider)"];
    ///     Save [label="PlayerPrefs.SetFloat + PlayerPrefs.Save()"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> Apply -> Save -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void CambiaVolume(float valoreSlider)
    {
        // Applica immediatamente il valore al mixer
        ApplicaVolumeAlMixer(valoreSlider);

        // Salva il valore localmente
        PlayerPrefs.SetFloat("SalvataggioVolume", valoreSlider);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Converte un valore lineare 0-1 in decibel e lo applica all'AudioMixer.
    /// </summary>
    /// <param name="valore">Valore lineare del volume (0-1).</param>
    /// <remarks>
    /// La formula utilizzata è: dB = log10(valore) * 20
    ///
    /// \dot
    /// digraph G {
    ///     rankdir=LR;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Val [label="Valore Lineare (0.0001 - 1.0)", shape=parallelogram];
    ///     Log [label="Mathf.Log10(valore)", style=filled, fillcolor=lightgrey];
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
        // Converte il valore lineare in decibel (-80 a 0)
        float dB = Mathf.Log10(Mathf.Clamp(valore, 0.0001f, 1f)) * 20;

        // Applica il valore al mixer principale e agli effetti SFX
        mixer.SetFloat(mixerParameter, dB);
        mixer.SetFloat(sfxParam, dB);
    }
}
