using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

  public float movementSpeed = 3f;
  public int health;
  private int maxHealth = 5;
  private int minHealth = 0;
  Rigidbody2D rb;
  public event Action OnPlayerWin;
  public event Action OnPlayerDeath;
  private WeaponInventory playerWeapons;
  Vector2 velocity;

	void Start () {
    rb = GetComponent<Rigidbody2D>();
    playerWeapons = GetComponent<WeaponInventory>();
    SetHealth(maxHealth);
  }
	
	void FixedUpdate () {
    IsPlayerAlive();
    FaceMouse();
    MovePlayer();
	}

  void Update() {
    CheckForWeaponChange();

    if(Input.GetKey(KeyCode.Space)) {
      playerWeapons.GetWeapon().AttemptUseWeapon();
    }
  }

  void IsPlayerAlive() {
    if(health <= 0) {
      if(OnPlayerDeath != null) {
        OnPlayerDeath();
      }
    }
  }

  public void ChangeHealth(int changeHealthAmount) {
    int newHealth = health + changeHealthAmount;
    if(newHealth < minHealth) {
      health = minHealth;
    } else if(newHealth > maxHealth) {
      health = maxHealth;
    } else {
      health = newHealth;
    }
  }

  public void CheckForWeaponChange() {
    if(Input.GetKeyDown(KeyCode.RightBracket)) {
      playerWeapons.NextWeapon();
    }
    if(Input.GetKeyDown(KeyCode.LeftBracket)) {
      playerWeapons.PreviousWeapon();
    }
    if(Input.GetKeyDown(KeyCode.Alpha1)) {
      playerWeapons.SetWeapon(0);
    }
    if(Input.GetKeyDown(KeyCode.Alpha2)) {
      playerWeapons.SetWeapon(1);
    }
    if(Input.GetKeyDown(KeyCode.Alpha3)) {
      playerWeapons.SetWeapon(2);
    }
  }

  public void SetHealth(int newHealth) {
    health = newHealth;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Goal") {
      if(OnPlayerWin != null) {
        OnPlayerWin();
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Enemy") {

    }
  }

  void FaceMouse() {
    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
  }

  void MovePlayer() {
    
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");

    bool isMoving = (xInput != 0 || yInput != 0);

    if (isMoving) {
      Vector2 input = new Vector2(xInput , yInput);
      Vector2 velocity = input * movementSpeed * Time.deltaTime;
      Vector2 targetPosition = (Vector2)transform.position + velocity;
      rb.MovePosition(targetPosition);
    }
  }
}
