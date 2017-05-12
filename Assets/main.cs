using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

	// Use this for initialization
    private float mouseMass = 0.3f;
	private float maxHeigth = 15;
	private Rigidbody body;
	private Vector3 ascentForce = new Vector3(0, 80);
	private Vector3 flightVelocity = new Vector3 (10, 0);
	private Vector3 descentVelocity = new Vector3 (10 / 3f, -12);

	public GameObject hero;

	private GameObject soundObj;
	private AudioSource audioPl;

	public AudioClip tummy;
	public AudioClip flying;

	void Start () {
		soundObj = GameObject.Find ("Audio Effects");
		audioPl = soundObj.GetComponent(typeof( AudioSource)) as AudioSource;
		body = gameObject.GetComponent<Rigidbody>();
		body.velocity = flightVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
		//base.gameObject.AddForce (new Vector3 (0, 8, 0));
		if (Input.GetKey ("space")) {
			audioPl.Play ();
			//SceneManager.LoadScene (1);
        }
		if (Input.GetKey ("down")) {
            body.velocity = descentVelocity;
		} else {
			body.velocity = flightVelocity;
			if (body.position.y < maxHeigth) {
				body.AddForce ((ascentForce*(maxHeigth - body.position.y))/body.mass);
			}
		}
	}

	void OnCollisionEnter(Collision otherObj)
	{
		if (otherObj.gameObject.name.Contains("TreeHH"))
		{
			audioPl.clip = win98;
			audioPl.Play ();
			Debug.Log("lose");
			SceneManager.LoadScene("x1");
		}
	}

	void OnTriggerEnter(Collider otherObj) 
	{
		if (otherObj.gameObject.name.Contains("Mouse"))
		{
			//Debug.Log("good job");
			body.mass += mouseMass;
			audioPl.clip = mouse;
			audioPl.Play ();
			TextMesh textObject = GameObject.Find("Text Mass").GetComponent<TextMesh>();
			textObject.text = (body.mass * 10).ToString ();
			Destroy(otherObj.gameObject);
		}
		if (otherObj.gameObject.name.Contains("CoMou"))
		{
			//Debug.Log("good job");
			body.mass -=mouseMass/2;
			audioPl.clip = kasp;
			audioPl.Play ();
			TextMesh textObject = GameObject.Find("Text Mass").GetComponent<TextMesh>();
			textObject.text = (body.mass * 10).ToString ();
			Destroy(otherObj.gameObject);
		}
		if (otherObj.gameObject.name.Contains("endGame"))
		{

			audioPl.clip = win;
			audioPl.Play ();
			PlayerPrefs.SetFloat("res", body.mass * 10);
			SceneManager.LoadScene ("myMenu");
		}
		if (otherObj.gameObject.name.Contains("uv2"))
		{
			float[] pos = { 58, 146+58, 260+58, 332+58 };

			audioPl.clip = eggeas;
			audioPl.Play ();
			hero.transform.position = new Vector3 (pos [Random.Range (0, 3)], hero.transform.position.y, hero.transform.position.z);
		}
	}
}
