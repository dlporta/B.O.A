using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Es el cambio de escena entre pantallas
/// </summary>
public class cambioescena : MonoBehaviour
{
    public int numeroscena;
/// <summary>
/// Metodo de cambio de escena
/// </summary>
    public void cambiodescena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(numeroscena);
    }
}
