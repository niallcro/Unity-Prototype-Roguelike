using System.Collections;
using UnityEngine;

public class Handgun : Weapon {

  public Bullet bullet;
  Transform muzzle;

	protected override void Start () {
    base.Start();
    muzzle = transform.Find("Muzzle");
  }

  public override void UseWeapon() {
    print("Using " + gameObject);
    Instantiate(bullet, muzzle.position, muzzle.rotation);
  }
}