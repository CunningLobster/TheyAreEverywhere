using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 1f;
    [SerializeField] float scrollSpeed = 10f;


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;
        float zoom = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        transform.Translate(moveX, zoom, moveY, Space.World);
        
    }
}
