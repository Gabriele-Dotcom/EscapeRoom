using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestisce la riproduzione degli effetti sonori (SFX).
/// Assicura la presenza di un AudioSource e permette di riprodurre
/// suoni con una leggera variazione di pitch per maggiore naturalezza.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class sfxmanager : MonoBehaviour
{
    /// <summary>
    /// Clip audio utilizzata come effetto sonoro principale.
    /// </summary>
    [Header("Configurazione Audio")]
    public AudioClip soundEffect;   // Il suono da riprodurre

    /// <summary>
    /// Valore massimo di variazione del pitch applicato casualmente.
    /// </summary>
    [Range(0f, 0.5f)]
    public float pitchVariation = 0.1f; // +/- variazione del pitch

    /// <summary>
    /// Riferimento all'AudioSource associato all'oggetto.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Inizializzazione del gestore audio.
    /// Recupera l'AudioSource e collega automaticamente
    /// il metodo PlaySFX al bottone UI, se presente.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     Start [label="Awake()", shape=ellipse];
    ///     GetAudio [label="GetComponent<AudioSource>()"];
    ///     Setup [label="audioSource.playOnAwake = false"];
    ///     GetButton [label="GetComponent<Button>()"];
    ///     CheckBtn [label="Button esiste?", shape=diamond];
    ///     AddListener [label="btn.onClick.AddListener(PlaySFX)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     Start -> GetAudio;
    ///     GetAudio -> Setup;
    ///     Setup -> GetButton;
    ///     GetButton -> CheckBtn;
    ///     CheckBtn -> AddListener [label="Sì"];
    ///     CheckBtn -> End [label="No"];
    ///     AddListener -> End;
    /// }
    /// \enddot
    /// </remarks>
    void Awake()
    {
        // Recupera l'AudioSource dall'oggetto
        audioSource = GetComponent<AudioSource>();

        // Disabilita la riproduzione automatica all'avvio
        audioSource.playOnAwake = false;

        // Verifica la presenza di un Button UI sullo stesso GameObject
        Button btn = GetComponent<Button>();

        // Se presente, collega l'evento onClick alla riproduzione del suono
        if (btn != null)
        {
            btn.onClick.AddListener(PlaySFX);
        }
    }

    /// <summary>
    /// Riproduce il suono configurato con una leggera variazione casuale del pitch.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="PlaySFX()", shape=ellipse];
    ///     Check [label="soundEffect o audioSource null?", shape=diamond];
    ///     Warn [label="Debug.LogWarning"];
    ///     SetPitch [label="audioSource.pitch = Random.Range"];
    ///     Play [label="audioSource.PlayOneShot(soundEffect)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> Check;
    ///     Check -> Warn [label="Sì"];
    ///     Check -> SetPitch [label="No"];
    ///     Warn -> End;
    ///     SetPitch -> Play;
    ///     Play -> End;
    /// }
    /// \enddot
    /// </remarks>
    public void PlaySFX()
    {
        // Controllo di sicurezza su AudioClip e AudioSource
        if (soundEffect == null || audioSource == null)
        {
            Debug.LogWarning($"Manca AudioClip o AudioSource su {gameObject.name}");
            return;
        }

        // Imposta una variazione casuale del pitch
        audioSource.pitch = Random.Range(1f - pitchVariation, 1f + pitchVariation);

        // Riproduce l'effetto sonoro
        audioSource.PlayOneShot(soundEffect);
    }

    /// <summary>
    /// Riproduce immediatamente un AudioClip passato come parametro.
    /// Utile per riprodurre suoni dinamicamente da codice.
    /// </summary>
    /// <remarks>
    /// \dot
    /// digraph G {
    ///     rankdir=TB;
    ///     node [shape=rect, fontname=Helvetica, fontsize=10];
    ///
    ///     In [label="PlaySFX(clip)", shape=ellipse];
    ///     Check [label="clip == null?", shape=diamond];
    ///     Play [label="audioSource.PlayOneShot(clip)"];
    ///     End [label="Fine", shape=ellipse];
    ///
    ///     In -> Check;
    ///     Check -> End [label="Sì"];
    ///     Check -> Play [label="No"];
    ///     Play -> End;
    /// }
    /// \enddot
    /// </remarks>
    /// <param name="clip">
    /// Clip audio da riprodurre.
    /// </param>
    public void PlaySFX(AudioClip clip)
    {
        // Se il clip non è valido, termina l'esecuzione
        if (clip == null) return;

        // Riproduce il clip audio passato come parametro
        audioSource.PlayOneShot(clip);
    }
}
