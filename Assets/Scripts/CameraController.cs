using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public Transform target;
  public float smoothing = 5f;
  private Vector3 offset;

	void Start () {
    target = FindObjectOfType<Player>().transform;
    offset = transform.position - target.position;
  }
	
	void FixedUpdate () {
    CameraFollow();
	}

  void CameraFollow() {
		Vector3 targetCameraPosition = target.position + offset;
    transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime);
  }
}
