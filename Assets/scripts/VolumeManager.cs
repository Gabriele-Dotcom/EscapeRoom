using UnityEngine;
using UnityEngine.Audio; // Fondamentale per il Mixer
using UnityEngine.UI;    // Fondamentale per lo Slider

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;

    public void CambiaVolume(float valoreSlider)
    {
        // "VolumeManager" deve essere il nome che appare in 'Exposed Parameters' nel Mixer
        mixer.SetFloat("VolumeGenerale", valoreSlider);
    }
}