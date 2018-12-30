using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public float sensitivityX = 9.0f;
    public float sensitivityY = 9.0f;

    public float minX = -90.0f;
    public float maxX = 90.0f;
    public float minY = -45.0f;
    public float maxY = 45.0f;

    private Quaternion originalRot;
    private float rotX = 0;
    private float rotY = 0;

    private void Start() {

        originalRot = transform.localRotation;
    }
    void Update() {

        Quaternion quaternionX;
        Quaternion quaternionY;

        rotX += Input.GetAxis("Mouse X") * sensitivityX;
        rotY += Input.GetAxis("Mouse Y") * sensitivityY;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);


        quaternionX = Quaternion.AngleAxis(rotX, Vector3.up);
        quaternionY = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * quaternionX * quaternionY;
   }
}
