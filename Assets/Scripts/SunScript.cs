using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SunScript : MonoBehaviour {

	public static SunScript Instance { set; get; }

	public GameObject planetPrefab;
	public float factor, maxRadius;
	public int maxPlanets;
	public ArrayList planets;
	private float distance, gravity;
	private Rigidbody rb;
	private GameObject temp;
	public Material red, blue, green;
	private Renderer rend;
	private string input;
	private bool start, impulse;
	public static bool auto;
	private int randSize;
	private string[] ar = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m"};
	private string tempString;

	public Text text;
	//public InputField sizeText;
	private float size;

	void Awake(){
		//planets = new GameObject[maxPlanets];
	}

	public void Start(){

		//size = float.Parse(sizeText.text);
		if (!auto)
			gameObject.transform.localScale = new Vector3 (Controller.size, Controller.size, Controller.size);
		else {
			tempString = ar [Random.Range (0, ar.Length)];
			randSize = Random.Range (1, 50);
			gameObject.transform.localScale = new Vector3 (randSize, randSize, randSize);
		}
		Debug.Log (tempString + randSize);
		planets = new ArrayList();
		rb = GetComponent<Rigidbody> ();	
		CreatePLanets ();
		//StartCoroutine (Delay());
		//AddImpulse ();

		start = false;
		impulse = false;



		Time.timeScale = 1;
	}

	public void CreatePLanets(){
		for (int i = 0; i < maxPlanets; i++) {
			temp = Instantiate (planetPrefab);
			planets.Add(temp);
			temp.transform.position = this.transform.position + new Vector3(Random.Range(-maxRadius, maxRadius), Random.Range(-5, 5), Random.Range(-maxRadius, maxRadius));
			rend = temp.GetComponent<Renderer> ();
			if (temp.transform.position.z >= -100 && temp.transform.position.z < -33){
				rend.material = red;
				temp.GetComponent<TrailRenderer> ().material = red;
			}
			if (temp.transform.position.z >= -33 && temp.transform.position.z < 33){
				rend.material = green;
				temp.GetComponent<TrailRenderer> ().material = green;
			}
			if (temp.transform.position.z >= 33 && temp.transform.position.z <= 100){
				rend.material = blue;
				temp.GetComponent<TrailRenderer> ().material = blue;
			}
		}
	}
	public void AddImpulse(int x, int y, int z){
		Debug.Log ("Impulse called");
		if (!impulse) {
			if (z == 0) {
				foreach (GameObject planet in planets) {
					if (planet.transform.position.z >= 0)
						planet.GetComponent<Rigidbody> ().AddForce (-planet.transform.forward * 5f * x, ForceMode.Impulse);
					else
						planet.GetComponent<Rigidbody> ().AddForce (planet.transform.forward * 5f * y, ForceMode.Impulse);
				}
			} else if (z == 1) {
				foreach (GameObject planet in planets) {
					if (planet.transform.position.z >= 0)
						planet.GetComponent<Rigidbody> ().AddForce (-planet.transform.right * 5f * x, ForceMode.Impulse);
					else
						planet.GetComponent<Rigidbody> ().AddForce (planet.transform.right * 5f * y, ForceMode.Impulse);
				}
			} else if (z == 2){
				foreach (GameObject planet in planets) {
					if (planet.transform.position.x >= 0)
						planet.GetComponent<Rigidbody> ().AddForce (-planet.transform.forward * 5f * x, ForceMode.Impulse);
					else
						planet.GetComponent<Rigidbody> ().AddForce (planet.transform.forward * 5f * y, ForceMode.Impulse);
				}
			}
			else if (z == 3){
				foreach (GameObject planet in planets) {
					if (planet.transform.position.x >= 0)
						planet.GetComponent<Rigidbody> ().AddForce (-planet.transform.right * 5f * x, ForceMode.Impulse);
					else
						planet.GetComponent<Rigidbody> ().AddForce (planet.transform.right * 5f * y, ForceMode.Impulse);
				}
			}else {
				foreach (GameObject planet in planets) {
					planet.GetComponent<Rigidbody> ().AddForce (Random.Range(-1f, 1f) * 5f, Random.Range(-1f, 1f) * 5f, Random.Range(-1f, 1f) * 5f, ForceMode.Impulse);
				}
			}
			impulse = true;
			Time.timeScale = 1;
		}
	}

//	private IEnumerator Delay(){
//		yield return new WaitForSeconds (3);
//	}

	public void Update(){
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Scene0");
		}
			
		Debug.Log (Time.timeScale);
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Time.timeScale == 1)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
		if (!auto)
			input = Input.inputString;
		else {
			input = tempString;
		}
			switch(input){
		case "a":
			text.text = "";
				if (!impulse) {
					AddImpulse (1, 1, 0);
					start = true;
				}
				break;
			case "b":
			text.text = "";
				if (!impulse) {
					AddImpulse (-1, -1, 0);
					start = true;
				}
				break;
			case "c":
			text.text = "";
				if (!impulse) {
					AddImpulse (1, -1, 0);
					start = true;
				}
				break;
			case "d":
			text.text = "";
				if (!impulse) {
					AddImpulse (-1, 1, 0);
					start = true;
				}
				break;
			case "e":
			text.text = "";
				if (!impulse) {
					AddImpulse (1, 1, 1);
					start = true;
				}
				break;
			case "f":
			text.text = "";
				if (!impulse) {
					AddImpulse (-1, -1, 1);
					start = true;
				}
				break;
			case "g":
			text.text = "";
				if (!impulse) {
					AddImpulse (1, -1, 1);
					start = true;
				}
				break;
			case "h":
			text.text = "";
				if (!impulse) {
					AddImpulse (-1, 1, 1);
					start = true;
				}
				break;
		case "i":
			text.text = "";
			AddImpulse (1, 1, 2);
			start = true;
			break;
		case "j":
			text.text = "";
			AddImpulse (-1, -1, 2);
			start = true;
			break;
		case "k":
			text.text = "";
			AddImpulse (1, 1, 3);
			start = true;
			break;
		case "l":
			text.text = "";
			AddImpulse (-1, -1, 3);
			start = true;
			break;
		case "m":
			text.text = "";
			AddImpulse (0, 0, 4);
			start = true;
			break;
		default:
			//text.text = "Select a valid case!";
				break;
			}

		if (start) {
			foreach (GameObject planet in planets) {
				Vector3 direction = transform.position - planet.transform.position;
				distance = direction.magnitude;
				Vector3 gravityDirection = direction.normalized;
				//gravity = factor * 6.7f * rb.mass * planet.GetComponent<Rigidbody> ().mass / (distance * distance);
				if (!auto)
					gravity = factor * 6.7f * rb.mass * Controller.size / (10 * (distance * distance));
				else
					gravity = factor * 6.7f * rb.mass * randSize / (10 * (distance * distance));
				Vector3 gravityVector = gravityDirection * gravity;
				//planet.GetComponent<Rigidbody> ().AddForce (planet.transform.forward, ForceMode.Acceleration);
				planet.GetComponent<Rigidbody> ().AddForce (gravityVector, ForceMode.VelocityChange);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log (col.name);
		if (col.gameObject.tag == "Planet") {
			planets.Remove (col.gameObject);
			Destroy (col.gameObject);
		}
	}
}
