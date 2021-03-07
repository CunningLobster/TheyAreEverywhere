﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField]Color baseColor = Color.white;
    [SerializeField]Color blockedColor = Color.red;
    [SerializeField]Color exploredColor = Color.yellow;
    [SerializeField]Color pathColor = Color.cyan;

    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
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
        label.enabled = true;
    }

    private void DisplayCoordinates()
    {
        //put this script in the Editor folder when build the game
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        
        label.text = coordinates.x + "," + coordinates.y;
    }

    void SetColorOfCoordinates()
    {
        if (gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable) {label.color = blockedColor;}

        else if (node.isPath) { label.color = pathColor; }

        else if (node.isExplored) {label.color = exploredColor;}

        else { label.color = baseColor; }
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
