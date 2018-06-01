using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript2 : MonoBehaviour {

	private Rigidbody rb, rb1, rb2;
	public GameObject Earth, Venus;
	private float distance, gravity;
	private Vector3 direction;

	public void Start(){
		rb = GetComponent<Rigidbody> ();
		rb2 = Earth.GetComponent<Rigidbody> ();
		rb1 = Venus.GetComponent<Rigidbody> ();
		rb1.AddForce (Venus.transform.forward * 50f, ForceMode.Impulse);
		rb2.AddForce (Earth.transform.forward * 30f, ForceMode.Impulse);
	}
	public void Update(){
		//EARTH
		direction = gameObject.transform.position - Earth.transform.position;
		distance = direction.magnitude;
		gravity = 6.67f * Mathf.Pow(10, -5) * rb.mass * rb2.mass / (distance * distance);
		rb2.AddForce (gravity * direction.normalized, ForceMode.Acceleration);

		//VENUS
		direction = gameObject.transform.position - Venus.transform.position;
		distance = direction.magnitude;
		gravity = 6.67f * Mathf.Pow(10, -5) * rb.mass * rb1.mass / (distance * distance);
		rb1.AddForce (gravity * direction.normalized, ForceMode.Acceleration);
	}
}
