using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform path { set; get; }
    public float speed { set; get; }

    private List<Transform> waypoints = new List<Transform>();
    private int currentWaypointIndex = 0;

    private void Start() {
        foreach (Transform waypoint in path) {
            waypoints.Add(waypoint);
        }
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update() {
        if (currentWaypointIndex < waypoints.Count) {
            Move();
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Move() {
        Transform waypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);

        if (transform.position == waypoint.position) {
            currentWaypointIndex++;
        }
    }
}
