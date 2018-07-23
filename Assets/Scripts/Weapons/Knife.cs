using System.Collections;
using UnityEngine;

public class Knife : Weapon {

  private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

  public override void UseWeapon() {
    print("Using knife");
    //animator.SetTrigger("UseKnife");
    animator.SetBool("Attacking", true);
  }
}