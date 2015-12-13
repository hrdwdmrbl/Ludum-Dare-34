using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Maze MazePrefab;

    private Maze mazeInstance;

    private IEnumerator mazeGenerate;

    // Use this for initialization
    void Start () {
        BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space)) {
            RestartGame();
        }
	}

    private void BeginGame () {
        mazeInstance = Instantiate(MazePrefab) as Maze;
        mazeGenerate = mazeInstance.Generate();
        StartCoroutine(mazeGenerate);
    }

    private void RestartGame () {
        StopCoroutine(mazeGenerate);
        Destroy(mazeInstance);
        BeginGame();
    }
}
