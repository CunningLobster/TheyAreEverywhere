using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float pathPercent = 0f;

            transform.LookAt(endPosition);

            while (pathPercent < 1)
            {
                pathPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, pathPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
