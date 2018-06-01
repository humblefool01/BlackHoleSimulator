using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public static Controller Instance { set; get; }

	public Text text;
	public InputField input;
	public static int size;

	public void Start(){
		SunScript.auto = false;
	}
	public void Update(){
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (input.text != "") {
			size = int.Parse (input.text);
		} else {
			size = 10;
		}
		if (size <= 0 || size >= 50) {
			size = 10;
		}
	}
	public void OnClick(){
		SceneManager.LoadScene ("Scene1");
	}
	public void Auto(){
		SunScript.auto = true;
		SceneManager.LoadScene ("Scene1");
	}
}
