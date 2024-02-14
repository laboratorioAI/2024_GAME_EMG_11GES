using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DemoBookController : MonoBehaviour {

	public AnimatedBookController bookController;		// Reference to the BookController script

	public Sprite[] pageBackground;
	private int pageStyleIndex = 0;

	// Use this for initialization

	//*********************************************************************
	 //Instancia del socket para escuchar los gestos
    readSocket socket = new readSocket();
    // Start is called before the first frame update
    //Gesto reconocido
    String gesto = "";
	SceneLoadManager gestorEscena = new SceneLoadManager();
	//**********************************************************************

	void Start () 
	{

	}
	// Control book with Left / Right arrows
	void Update () {
		try{

			gesto = socket.Update();

			if (Input.GetKeyDown (KeyCode.RightArrow)|| gesto == "waveOut") {
			bookController.TurnToPreviousPage();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)|| gesto == "waveIn") {
			bookController.TurnToNextPage();
		}
		if(gesto == "pinch"){
                IrDesert();
            }

		}catch (Exception ex)
        {
            socket.Start();
        } 
		
	}
	

	public void switchPageStyle() {
		pageStyleIndex++;
		if (pageStyleIndex >= pageBackground.Length) {
			pageStyleIndex = 0;
		}
		bookController.defaultBackground = pageBackground [pageStyleIndex];

		foreach (AnimatedBookController.PageObjects page in bookController.getPageObjects()) {
			page.RectoImage.sprite = pageBackground [pageStyleIndex];
			page.VersoImage.sprite = pageBackground [pageStyleIndex];
		}
	}

	 void IrDesert(){
        gestorEscena.LoadNextScene(3);
    }

	
}
