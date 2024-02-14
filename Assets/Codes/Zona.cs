using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public int numeroEscena; // Nombre de la escena a cargar
    public float pauseDuration = 2f; // Duración de la pausa en segundos

    private bool shouldChangeScene = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Puedes ajustar la etiqueta del objeto si es necesario
        {
            shouldChangeScene = true;
        }
    }

    private void Update()
    {
        if (shouldChangeScene)
        {
            StartCoroutine(ChangeSceneWithPause());
            shouldChangeScene = false;
        }
    }

    private IEnumerator ChangeSceneWithPause()
    {
        // Realiza la pausa
        yield return new WaitForSecondsRealtime(pauseDuration);

        // Cambia de escena
        SceneManager.LoadScene(numeroEscena);
    }
}
