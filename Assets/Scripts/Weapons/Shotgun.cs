using System.Collections;
using UnityEngine;

public class Shotgun : Weapon {
  public override void UseWeapon() {
    print("Using " + gameObject);
  }
}