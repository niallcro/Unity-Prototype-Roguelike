using System.Collections;
using UnityEngine;

public class Shotgun : Weapon {
  
  public Bullet bullet;
  Transform muzzle;
  public float bulletSpread;
  public float numberOfBullets;

	protected override void Start () {
    base.Start();
    muzzle = transform.Find("Muzzle");
  }

  public override void UseWeapon() {
    print("Using " + gameObject);
    for(int i = 0; i < numberOfBullets; i++) {
      Bullet bulletInstance = Instantiate(bullet, muzzle.position, muzzle.rotation);
      bulletInstance.transform.Rotate(new Vector3(0,0,-bulletSpread/2), Space.Self);
      float range = bulletSpread / numberOfBullets;
      float z = Random.Range(i * range, i * range + range);
      bulletInstance.transform.Rotate(new Vector3(0,0,z), Space.Self);
      // Example (range = 25):
      // 0 - 25: i = 0, i * range = 0, i * range + range = 25 
      // 25 - 50: i = 1, i * range = 25, i * range + range = 50
      // 50 - 75: i = 2, i * range = 50, i * range + range = 75
      // 75 - 100: i = 3, i * range = 75, i * range + range = 100
    }
  }
}