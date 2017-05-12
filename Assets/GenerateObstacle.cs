using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateObstacle : MonoBehaviour
{
	public GameObject obstacles;
	public bool gen=true;
	public float seconds=0;
	public int updateCounter=0;
	public int maxRange=100;
	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject Bird;

    private List<GameObject> generatedObstacles = new List<GameObject>();
    private int camLimitX = -4;
	// Use this for initialization
	void Start()
	{

	}
	void Update()
	{
        if (gen)
        {
            gen = false;
            Invoke("GenerateNewObstacle", Random.Range(4, 8));
        }
        else
        {
            updateCounter++;
        }
		if(updateCounter >= maxRange)
		{
			gen=true;
			updateCounter=0;
		}

        generatedObstacles.RemoveAll(item => item.transform.position.x < camLimitX);

		if(Bird.transform.position.y >= 6.206661 || Bird.transform.position.y < -12.7736)
			RestartTheGame();
	}

	void RestartTheGame()
	{
		//Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(1);
	}

	void GenerateNewObstacle()
	{
		generatedObstacles.Add(Instantiate(obstacles));
	}
}