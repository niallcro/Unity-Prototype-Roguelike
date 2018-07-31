using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public float damage;
  public float bulletSpeed;
  Vector3 target;
  Vector2 direction;

	// Use this for initialization
	void Start () {
    Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    direction = target - transform.position;
    direction.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
    GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
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
