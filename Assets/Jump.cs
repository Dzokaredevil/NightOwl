using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	// Use this for initialization
	public Rigidbody bird;
    public Vector3 descentSpeed = new Vector3(0, -15, 0);
    public float maxHeigth = 3;
    public float ascentForceCoefficient = 15f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey("space")))
        {
            bird.velocity = descentSpeed;
            Debug.Log(bird.position.y);
        } else
        {
            bird.velocity = Vector3.zero;
            if (bird.position.y < maxHeigth) {
                bird.AddForce(new Vector3(0, (maxHeigth - bird.position.y)*ascentForceCoefficient + 10, 0));
            } else
            {
                bird.transform.LookAt(bird.position + Vector3.forward);
            }
        }
    }
}
