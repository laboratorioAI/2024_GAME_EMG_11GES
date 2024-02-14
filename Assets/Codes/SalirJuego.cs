using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalirJuego : MonoBehaviour
{
    public void SalirDelJuego()
    {
        //Application.Quit(); // Este método cierra la aplicación en un entorno de ejecución independiente
         UnityEditor.EditorApplication.isPlaying = false;
    }

}
