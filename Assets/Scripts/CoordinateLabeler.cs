using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField]Color baseColor = Color.white;
    [SerializeField]Color blockedColor = Color.gray;
    Waypoint waypoint;

    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }

    void Update()
    {
        DisplayCoordinates();

        UpdateObjectName();
        SetColorOfCoordinates();
        ToggleLabeles();
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        
        label.text = coordinates.x + "," + coordinates.y;
    }

    void SetColorOfCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = baseColor;
        }
        else 
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabeles()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
