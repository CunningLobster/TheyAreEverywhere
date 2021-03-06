using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicCamera : MonoBehaviour
{
    [Header("Control Speed")]
    [SerializeField] float cameraSpeed = 1f;
    [SerializeField] float scrollSpeed = 10f;

    [Header("Camera Position Limits")]
    [SerializeField] float minHorizontalPosition = 0f;
    [SerializeField] float maxHorizontalPozition = 290f;
    [SerializeField] float minVerticalPosition = 0f;
    [SerializeField] float maxVerticalPosition = 290f;

    [Header("Zoom Limits")]
    [SerializeField] float minCameraAltitude = -40f;
    [SerializeField] float maxCameraAltitude = 40f;

    float newHorizontalPosition;
    float newVertialPosition;
    float newCameraAltitude;

    void Update()
    {
        UpdateCameraPosition();
    }

    void MoveCamera()
    {
        float moveX = Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;

        newHorizontalPosition = transform.position.x + moveX;
        newHorizontalPosition = Mathf.Clamp(newHorizontalPosition, minHorizontalPosition, maxHorizontalPozition);

        newVertialPosition = transform.position.z + moveY;
        newVertialPosition = Mathf.Clamp(newVertialPosition, minVerticalPosition, maxVerticalPosition);
    }

    void ZoomCamera()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        newCameraAltitude = transform.position.y - zoom;
        newCameraAltitude = Mathf.Clamp(newCameraAltitude, minCameraAltitude, maxCameraAltitude);
    }

    void UpdateCameraPosition()
    {
        MoveCamera();
        ZoomCamera();

        transform.position = new Vector3(newHorizontalPosition, newCameraAltitude, newVertialPosition);
    }
}
