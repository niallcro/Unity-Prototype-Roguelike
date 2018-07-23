using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGUI : MonoBehaviour {

  private Player player;
  private Text textArea;
  Quaternion rotation;

  void Awake() {
    rotation = transform.rotation;
  }
  void LateUpdate() {
    transform.rotation = rotation;
  }

	// Use this for initialization
	void Start () {
    player = GameObject.Find("Player").GetComponent<Player>();
    textArea = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
    textArea.text = "X: " + player.transform.position.x + "\n" + 
                    "Y: " + player.transform.position.y + "\n";
	}
}
