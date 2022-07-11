using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Es el control de audio del video juego con el menú de opción 
/// </summary>
public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioSource[] soundEffects;

    public AudioSource Bgm;

    public void Awake() { 
        instance = this;
    }
/// <summary>
/// Metodo reproductor de los audios.
/// </summary>
/// <param name="SoundToPlay"></param>
    public void PlaySFX(int SoundToPlay) {
        soundEffects[SoundToPlay].Stop();
        soundEffects[SoundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[SoundToPlay].Play();
    }


}
