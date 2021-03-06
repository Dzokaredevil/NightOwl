using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

	// задаём объект и его скорость
    private float mouseMass = 0.3f;
	private float maxHeigth = 15;
	private Rigidbody body;
	private Vector3 ascentForce = new Vector3(0, 80);
	private Vector3 flightVelocity = new Vector3 (10, 0);
	private Vector3 descentVelocity = new Vector3 (10 / 3f, -12);

	public GameObject hero;

	private GameObject soundObj;
	private AudioSource audioPl;
	// подключаем аудио
	public AudioClip tummy;
	public AudioClip flying;
	// запускаем сову лететь
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
        }	// если нажали стрелку вниз, то опускаемся
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
	{	// столкнулись с деревом - проигрыш, нас перекидывает в начало уровня
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
			//изменения при съедении мыши
			body.mass += mouseMass; // изменяем массу совы
			audioPl.clip = mouse; // проигрываем звук
			audioPl.Play ();
			TextMesh textObject = GameObject.Find("Text Mass").GetComponent<TextMesh>();
			textObject.text = (body.mass * 10).ToString (); // выводим новый вес
			Destroy(otherObj.gameObject); // объект пропадает
		}
		if (otherObj.gameObject.name.Contains("CoMou"))
		{
			//изменения при съедении компьютерной мыши
			body.mass -=mouseMass/2;
			audioPl.clip = kasp;
			audioPl.Play ();
			TextMesh textObject = GameObject.Find("Text Mass").GetComponent<TextMesh>();
			textObject.text = (body.mass * 10).ToString ();
			Destroy(otherObj.gameObject);
		}
		if (otherObj.gameObject.name.Contains("endGame"))
		{
			// столкновение с большим бревном
			audioPl.clip = win;
			audioPl.Play ();
			PlayerPrefs.SetFloat("res", body.mass * 10);
			SceneManager.LoadScene ("myMenu");
		}
		if (otherObj.gameObject.name.Contains("uv2"))
		{	// столкновение с маленьким бревном - телепортация
			float[] pos = { 58, 146+58, 260+58, 332+58 };

			audioPl.clip = eggeas;
			audioPl.Play ();
			hero.transform.position = new Vector3 (pos [Random.Range (0, 3)], hero.transform.position.y, hero.transform.position.z);
		}
	}
}
