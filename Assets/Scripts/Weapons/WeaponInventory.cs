using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponInventory : MonoBehaviour {

  public int currentWeaponIndex;
  public Weapon currentWeapon;

  public List<Weapon> weaponPrefabs;
  private List<Weapon> weapons;

  void Start() {
    InstantiateWeapons();
    SetStartingWeapon();
  }

  void InstantiateWeapons() {
    weapons = new List<Weapon>();
    foreach (Weapon prefab in weaponPrefabs) {
      Weapon weapon = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
      weapons.Add(weapon);
    }
  }

  public void SetStartingWeapon() {
    if(weapons != null) {
      currentWeaponIndex = 0;
      currentWeapon = weapons[currentWeaponIndex];
    }
  }

  public void NextWeapon() {
    currentWeaponIndex += 1;
    if(currentWeaponIndex >= weapons.Count) {
      currentWeaponIndex = 0;
    }
    SetWeapon(currentWeaponIndex);
  }

  public void PreviousWeapon() {
    currentWeaponIndex -= 1;
    if(currentWeaponIndex < 0) {
      currentWeaponIndex = weapons.Count-1;
    }
    SetWeapon(currentWeaponIndex);
  }

  public void SetWeapon(int index) {
    currentWeaponIndex = index;
    currentWeapon = weapons[index];
  }

  public Weapon GetWeapon() {
    return currentWeapon;
  }
}
