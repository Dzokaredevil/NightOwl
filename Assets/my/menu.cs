using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public int load;
    public bool quit;
	public GameObject hero;

	private GameObject soundObj;
	private AudioSource audioPl;
	void Start () {
		soundObj = GameObject.Find ("AudioX");
		audioPl = soundObj.GetComponent(typeof( AudioSource)) as AudioSource;

		GetComponent<Renderer>().material.color = Color.black;
	}


    void OnMouseEnter()
    {
		audioPl.Play ();
		hero.transform.position = new Vector3(hero.transform.position.x ,this.transform.position.y,hero.transform.position.z);
		if (quit == true) {
			
			hero.transform.Rotate (0, 180, 0);
		}
        GetComponent<Renderer>().material.color = Color.red;
	}
    void OnMouseExit()
    {
		if (quit == true) {

			hero.transform.Rotate (0, 180, 0);
		}
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseUp()
    {
        if (quit == true)
        {
            Application.Quit();
        }
        if (quit == false)
        {
            SceneManager.LoadScene("x1");
        }
    }
}
