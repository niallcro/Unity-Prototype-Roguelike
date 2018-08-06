using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public float damage;
  public float bulletSpeed;
  public float lifetime;
  Vector3 target;
  Vector2 direction;

  void Start() {
    Destroy (gameObject, lifetime);
  }

  void Update () {
    transform.position += transform.up * bulletSpeed * Time.deltaTime;
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
