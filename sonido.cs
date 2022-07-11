using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Clase para el control del volumen del juego
/// </summary>
public class sonido : MonoBehaviour
{
    public Slider controlvolumen;
    public GameObject[] audios;
    
    public AudioSource Bgm;

    void Start() 
    {
        audios = GameObject.FindGameObjectsWithTag("audio");
        controlvolumen.value = PlayerPrefs.GetFloat("volumensave", 1f);
    }
    /// <summary>
    /// metodo de control del volumen
    /// </summary>
    private void Update() {
        foreach (var au in audios)
            au.GetComponent<AudioSource>().volume = controlvolumen.value;
    }
    /// <summary>
    /// metodo de guardado del volumen
    /// </summary>
    public void Guardarvolumen()
    {
        PlayerPrefs.SetFloat("volumensave", controlvolumen.value);
    }
}
