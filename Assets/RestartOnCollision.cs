using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(1);
    }

}
