using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

  private Animator animator;
  private bool doorOpen;

	void Start () {
    doorOpen = false;
		animator = GetComponent<Animator>();
	}

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Player") {
      doorOpen = true;
      animator.SetTrigger("DoorOpeningTrigger");
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if(doorOpen) {
      doorOpen = false;
      animator.SetTrigger("DoorClosingTrigger");
    }
  }
}
