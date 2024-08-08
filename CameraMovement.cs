using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("CAMERA")]
    public Transform cam;

    [Header("OBJECT")]
    public Transform obj;

    [Header("SETTINGS")]
    public float mouseSpeed = 3f;    
    public float scrollSpeed = 5f;
    public float orbitDamping = 10f;
    public float minDistance = 0f;
    public float maxDistance = 5f;

    Vector3 LocalRot;
    float distance;

    void Start()
    {
        distance = Vector3.Distance(cam.position, obj.position);
    }

    void Update()
    {
        cam.position = obj.position - cam.forward * distance;

        Rotation();
        Zoom();
    }

    void Rotation()
    {
        if (Input.GetMouseButton(0))
        {
            LocalRot.x -= Input.GetAxis("Mouse Y") * mouseSpeed;
            LocalRot.y += Input.GetAxis("Mouse X") * mouseSpeed;

            LocalRot.x = Mathf.Clamp(LocalRot.x, 0f, 80f);
        }

        var Qt = Quaternion.Euler(LocalRot.x, LocalRot.y, 0f);
        cam.rotation = Quaternion.Lerp(cam.rotation, Qt, Time.deltaTime * orbitDamping);
    }

    void Zoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }
}
