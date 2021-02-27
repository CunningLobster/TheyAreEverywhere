using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject ballista;
    [SerializeField] bool isPlaceable;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
