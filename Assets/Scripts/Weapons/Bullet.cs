using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public float damage;
  public float bulletSpeed;
  Vector3 target;
  Vector2 direction;

  void Start () {
    Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    direction = target - transform.position;
    direction.Normalize();
  }

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
