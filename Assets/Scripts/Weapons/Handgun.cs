using System.Collections;
using UnityEngine;

public class Handgun : Weapon {

  public Bullet bullet;

  public override void UseWeapon() {
    print("Using " + gameObject);
    Instantiate(bullet, transform.position, Quaternion.identity);
  }
}