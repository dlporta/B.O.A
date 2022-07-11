using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase para salir del juego
/// </summary>
public class salida : MonoBehaviour
{
   public void ExitGame()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
