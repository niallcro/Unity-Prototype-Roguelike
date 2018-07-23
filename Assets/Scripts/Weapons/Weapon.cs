using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

  [SerializeField]
  protected float weaponCooldownSeconds;
  protected bool canUse = true;

  // protected virtual void Start() {}

  // protected virtual void Update() {}

	public virtual void AttemptUseWeapon () {
		if(canUse) {
      canUse = false;
      StartCoroutine(WeaponCooldown());
      UseWeapon();
    }
	}

  public abstract void UseWeapon();

  protected IEnumerator WeaponCooldown() {
    yield return new WaitForSeconds(weaponCooldownSeconds);
    canUse = true;
  }
}
