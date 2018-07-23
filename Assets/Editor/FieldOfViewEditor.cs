using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {

  void OnSceneGUI() {
    FieldOfView fov = (FieldOfView) target;
    Handles.color = Color.magenta;
    Handles.DrawWireDisc(fov.transform.position, fov.transform.forward, fov.viewRadius);
    Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
    Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

    // Handles.color = Color.red;
    // foreach (Transform visibleTarget in fow.visibleTargets) {
    //     Handles.DrawLine(fow.transform.position, visibleTarget.position);
    // }
  }
}