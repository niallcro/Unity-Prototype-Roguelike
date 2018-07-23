using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void StartGame() {
    SceneManager.LoadScene("Level01");
  }

  public void Lose() {
    SceneManager.LoadScene("Lose");
  }

  public void Win() {
    SceneManager.LoadScene("Win");
  }

}
