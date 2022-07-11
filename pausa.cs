using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Permite detener, reuinicias, y reanudar el tiempo del juego
/// </summary>
public class pausa : MonoBehaviour
{

    [SerializeField] private GameObject botonpausa;
    [SerializeField] private GameObject menupausa;
    private bool juegopausado = false;

    void Start()
    {
        reanudar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegopausado)
            {
                reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }
    /// <summary>
    /// metodo para detener el tiempo del juego
    /// </summary>
    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;
        botonpausa.SetActive(false);
        menupausa.SetActive(true);

    }

    /// <summary>
    /// metodo para reanudar el tiempo del juego
    /// </summary>
    public void reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        botonpausa.SetActive(true);
        menupausa.SetActive(false);
    }
    /// <summary>
    /// metodopara reinicial el nivel
    /// </summary>
    public void restar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
