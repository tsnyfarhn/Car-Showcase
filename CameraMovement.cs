using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("CAMERA")]
    public Transform mainCam;
    public Transform tireCam;
    public Transform frontCam;

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
    public static bool isMainCam = true;

    public static Transform _mainCam;
    public static Transform _tireCam;
    public static Transform _frontCam;
    public static GameObject _obj;

    void Start()
    {
        _mainCam = mainCam;
        _tireCam = tireCam;
        _frontCam = frontCam;
        _obj = obj.gameObject;

        mainCam.position = Vector3.zero;

        distance = Vector3.Distance(mainCam.position, obj.position);
    }

    void Update()
    {
        if (isMainCam)
        {
            mainCam.position = obj.position - mainCam.forward * distance;

            Rotation();
            Zoom();
        }
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
        mainCam.rotation = Quaternion.Lerp(mainCam.rotation, Qt, Time.deltaTime * orbitDamping);
    }

    void Zoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }
}
