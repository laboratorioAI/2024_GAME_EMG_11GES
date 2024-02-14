using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class menuConfiguracion : MonoBehaviour
{
    //Fuente de audio
    public AudioSource AudioSource;
    //botones
    public Button btnvolver;
    //botones
    public Text valorVolumen;
    //Volumen
    float musicVolumen;
    //Slider
    public Slider volumenSlider;
    //gestor de la escena
    SceneLoadManager gestorEscena = new SceneLoadManager();
    //Instancia del socket para escuchar los gestos
    readSocket socket = new readSocket();
    // Start is called before the first frame update
    //Gesto reconocido
    String gesto = "";
    void Start()
    {
        musicVolumen = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolumen;
        volumenSlider.value = musicVolumen;
        valorVolumen.text = ((int) (musicVolumen*100.0f)).ToString()+"%";
        btnvolver.onClick.AddListener(IrMenuPrincipal);
        
    }

    // Update is called once per frame
    void Update()
    {
        try{
            gesto = socket.Update();
            if(gesto == "open" && musicVolumen <1.0f){
                volumenSlider.value = volumenSlider.value+0.1f;
            }else if (gesto == "fist" && musicVolumen >0.0f){
                if(volumenSlider.value > 0.9f){
                    volumenSlider.value = 0.90f;
                }else{
                    volumenSlider.value = volumenSlider.value-0.1f;
                }  
            }else if(gesto == "pinch"){
                IrMenuPrincipal();
            }
        }catch (Exception ex)
        {
            socket.Start();
        }
        
        musicVolumen = volumenSlider.value;
        AudioSource.volume = volumenSlider.value;
        PlayerPrefs.SetFloat("volume", volumenSlider.value);
        valorVolumen.text = ((int) (volumenSlider.value*100.0f)).ToString()+"%";
    }
    void IrMenuPrincipal(){
        gestorEscena.LoadNextScene(0);
    }
}
