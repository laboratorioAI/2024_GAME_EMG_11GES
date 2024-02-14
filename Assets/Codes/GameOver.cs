using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOver : MonoBehaviour
{   public AudioSource AudioSource;
    //botones del menú
    public Button btnReiniciar;
   // public Button btnVolumen;
    public Button btnSalir;
    //gestor de la escena
    SceneLoadManager gestorEscena = new SceneLoadManager();
    //Instancia del socket para escuchar los gestos
    readSocket socket = new readSocket();
    //Cambio de sprite para efectos visuales de botones
    public Sprite pressedSprite;
    //Nombre del gesto obtenido
    String gesto = "";
    //Opci[on actual en el menú
    int opcionActual = 0;
    //Instancio para obtener los eventos del sistema
    GameObject myEventSystem;
    //Volumen
    float musicVolumen = 0.1f;
    void Start()
    {
        //Configuración del volumen
        //Se obtiene el volumen definido en anteriores sesiones
        musicVolumen = PlayerPrefs.GetFloat("volume");
        //Se configura el sonido en el juego
        AudioSource.volume = musicVolumen;
        //Se obtienne la instancia de eventos del sistema
        myEventSystem = GameObject.Find("EventSystem");
        //Se establece como seleccionado el primer botón de pantalla
        btnReiniciar.Select();
        //Se definen las funciones para la acción de clicks en los botones
        btnReiniciar.onClick.AddListener(IrDesert);
        btnSalir.onClick.AddListener(SalirAplicacion);
       // btnVolumen.onClick.AddListener(IrConfiguracionVolumen);
    }

    // Update is called once per frame
    void Update()
    {
        try{
            //Se obtiene gesto realizado
            gesto = socket.Update();
            //Se verifica el gesto y si est[a relacionado con una acción
                //Desplazamiento de opciones hacía arriba
            if(gesto == "waveOut" && opcionActual >0){
                opcionActual -= 1; 
                ActualizarOpcion();
                //Desplazamiento de opciones hacia abajo
            }else if (gesto == "waveIn" && opcionActual <3){
                opcionActual += 1; 
                ActualizarOpcion();
                //Seleccion de la opcion actual
            }else if (gesto == "pinch" || gesto == "Forward"){
                RealizarOpcion();
            }
        }catch (Exception ex)
        {
            socket.Start();
        }
    }
    //Ir a la escena del Desierto
    void IrDesert(){
        gestorEscena.LoadNextScene(3);
    }
    //Salir de la aplicaci[on (no funciona en el editor)
    void SalirAplicacion(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
    //Ir a la escena de configuración de volumen 
    void IrConfiguracionVolumen(){
        gestorEscena.LoadNextScene(5);
    }
    //Se actualiza la opción seleccionada según el gesto y la posición de la opción
    void ActualizarOpcion(){
        switch(opcionActual)
        {
            case 0: 
                btnReiniciar.Select();
                break;
            case 1: 
                btnSalir.Select();
                break;
            default:
                btnReiniciar.Select();
                break;
        }
    }
    //Se cambia el spride del botón y se invoca el metodo de click del botón seleccionado
    void RealizarOpcion(){
        switch(opcionActual)
        {
            case 0: 
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                btnReiniciar.image.sprite = pressedSprite;
                btnReiniciar.onClick.Invoke();

                break;
            case 1: 
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
                btnSalir.image.sprite = pressedSprite;
                SalirAplicacion();
                break;
            default:
                btnReiniciar.Select();
                break;
        }
    }

}
