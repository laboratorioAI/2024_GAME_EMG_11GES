using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CargarPantalla : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoProgreso;
    [SerializeField] Slider sliderProgreso;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Carga());
        }
    }

   private IEnumerator Carga()
   {
        sliderProgreso.gameObject.SetActive(true);
        AsyncOperation operacionCarga = SceneManager.LoadSceneAsync(1);
        
        while (operacionCarga.isDone == false)
        {
           float progreso = Mathf.Clamp01(operacionCarga.progress / .09f);
           sliderProgreso.value = progreso;
           textoProgreso.text = "" + progreso * 100 + "%";
        }
        yield return  null;

    }

}