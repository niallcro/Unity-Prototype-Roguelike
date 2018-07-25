using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

  public PortalController connectedPortal;

  void OnTriggerEnter2D(Collider2D other) {
      other.transform.position = connectedPortal.transform.position + new Vector3(transform.localScale.x, transform.localScale.x);
  }
}
