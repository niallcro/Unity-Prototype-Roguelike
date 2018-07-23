using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public Player player;
  LevelManager levelManager;

	// Use this for initialization
	void Start () {
    player = FindObjectOfType<Player>();
    levelManager = FindObjectOfType<LevelManager>();
    player.OnPlayerDeath += GameOver;
    player.OnPlayerWin += GameWon;
	}
	
	// Update is called once per frame
	void Update () {
    if(Input.GetKeyDown(KeyCode.Equals)) {
      print("Health up");
      player.ChangeHealth(1);
    }
    if(Input.GetKeyDown(KeyCode.Minus)) {
      print("Health down");
      player.ChangeHealth(-1);
    }
  }

  private void GameOver() {
    levelManager.Lose();
  }

  private void GameWon() {
    levelManager.Win();
  }
}
