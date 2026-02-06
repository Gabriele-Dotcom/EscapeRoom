using UnityEngine;
using UnityEngine.UI;

public class sfxmanager : MonoBehaviour
{
    [Header("Configurazione Audio")]
    public AudioSource sfxSource;   // l' AudioManager/Mixer Source
    public AudioClip soundEffect;   // Il suono specifico 

    [Range(0.8f, 1.2f)]
    public float pitchRange = 0.1f; // Variabilità del suono

    void Start()
    {
        // Se è un bottone UI, si collega da solo
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(PlaySFX);
        }

        // Se non hai trascinato l'AudioSource, lo cerca nell'AudioManager
        if (sfxSource == null)
        {
            // Cerca l'oggetto chiamato "AudioManager" e prende la sua AudioSource
            GameObject am = GameObject.Find("AudioManager");
            if (am != null) sfxSource = am.GetComponent<AudioSource>();
        }
    }

    // Questa funzione può essere chiamata da QUALSIASI COSA (script, eventi, animazioni)
    public void PlaySFX()
    {
        if (sfxSource != null && soundEffect != null)
        {
            // Applica una leggera variazione per non annoiare l'orecchio
            float randomPitch = Random.Range(1f - pitchRange, 1f + pitchRange);
            sfxSource.pitch = randomPitch;

            sfxSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning($"Manca AudioClip o AudioSource su {gameObject.name}");
        }
    }
}