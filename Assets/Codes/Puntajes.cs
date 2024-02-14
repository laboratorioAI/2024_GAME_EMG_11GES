using UnityEngine;
using TMPro;

public class Puntajes : MonoBehaviour
{
    private float puntos;
    public TextMeshProUGUI textMesh;

    private void Start()
    {
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        ActualizarTexto();
    }
}
