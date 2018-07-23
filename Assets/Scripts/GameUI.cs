using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

  Image healthbarImage;
  // Image weaponImage;
  private Object[] healthbarSprites;
  public Player player;

	// Use this for initialization
	void Start () {
    player = FindObjectOfType<Player>();
    healthbarImage = transform.Find("Healthbar").GetComponent<Image>();
    // weaponImage = transform.Find("Weapon").GetComponent<Image>();
		healthbarSprites = Resources.LoadAll("Healthbar", typeof(Sprite));
    SetHealthbarImage();
    // SetWeaponImage();
	}
	
	// Update is called once per frame
	void Update () {
		SetHealthbarImage();
    // SetWeaponImage();
	}

  void SetHealthbarImage() {
    healthbarImage.sprite = (Sprite)healthbarSprites[player.health];
  }

  // void SetWeaponImage() {
  //   Weapon playerWeapon = player.GetComponent<WeaponInventory>().GetWeapon();
  //   weaponImage.sprite = playerWeapon.GetComponent<Image>().sprite;
  // }

}
