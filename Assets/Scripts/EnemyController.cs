using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

  public float health = 2f;
  public float aggroRange = 5f;
  public float movementSpeed = 2f;
  private Vector3 originalPosition;
  private Vector3 targetDirection;
  public GameObject player;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
    player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
    DestroyIfDead();
    Move();
	}

  void moveTowardsPoint (Vector3 targetPosition, float speed) {
    Vector3 displacementFromTarget = targetPosition - transform.position;
    Vector3 directionToTarget = displacementFromTarget.normalized;
    Vector3 velocity = directionToTarget * speed;
    transform.Translate(velocity * Time.deltaTime);
  }

  void Move() {
    if(DistanceFromPlayer() < aggroRange) {
      moveTowardsPoint (player.transform.position, movementSpeed);
    } else {
      if (originalPosition != transform.position) {
        moveTowardsPoint (originalPosition, movementSpeed);
      }
    }
  }

  public float DistanceFromPlayer() {
    Vector3 displacementFromTarget = player.transform.position - transform.position;
    float distanceFromTarget = displacementFromTarget.magnitude;
    return distanceFromTarget;
  }

  public void TakeDamage(float damage) {
    health -= damage;
  }

  void DestroyIfDead() {
    if(health <= 0) {
      Destroy(gameObject);
    }
  }

  void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, aggroRange);
  }
}
