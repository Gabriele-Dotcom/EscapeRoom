using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class sfxmanager : MonoBehaviour
{
    [Header("Configurazione Audio")]
    public AudioClip soundEffect;   // Il suono da riprodurre
    [Range(0f, 0.5f)]
    public float pitchVariation = 0.1f; // +/- variazione del pitch

    private AudioSource audioSource;

    void Awake()
    {
        // Prende l'AudioSource dall'oggetto o lo crea se non presente
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Se c'è un bottone UI sullo stesso oggetto, collega automaticamente PlaySFX
        Button btn = GetComponent<Button>();
        
       if (btn != null)
        {
            btn.onClick.AddListener(PlaySFX);
        } 
    }

    /// <summary>
    /// Riproduce il suono con una leggera variazione di pitch
    /// </summary>
    public void PlaySFX()
    {
        if (soundEffect == null || audioSource == null)
        {
            Debug.LogWarning($"Manca AudioClip o AudioSource su {gameObject.name}");
            return;
        }

        // Variazione casuale del pitch per rendere il suono più naturale
        audioSource.pitch = Random.Range(1f - pitchVariation, 1f + pitchVariation);
        audioSource.PlayOneShot(soundEffect);
    }

    /// <summary>
    /// Permette di assegnare un AudioClip da codice e riprodurlo subito
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.pitch = Random.Range(1f - pitchVariation, 1f + pitchVariation);
        audioSource.PlayOneShot(clip);
    }
}
