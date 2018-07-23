using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public float damage;
  public float bulletSpeed;
  Vector3 target;

	// Use this for initialization
	void Start () {
    Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
    
	}

  private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Enemy") {
      other.GetComponent<EnemyController>().TakeDamage(damage);
      Destroy(gameObject);
    }

    if(other.tag == "Building") {
      Destroy(gameObject);
    }
  }
}
