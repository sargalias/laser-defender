using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private Transform path = null;
    [SerializeField] private float speed = 0;

    private List<Transform> waypoints = new List<Transform>();
    private int currentWaypointIndex = 0;

    private void Start() {
        foreach (Transform waypoint in path) {
            waypoints.Add(waypoint);
        }
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (currentWaypointIndex < waypoints.Count) {
            Transform waypoint = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);

            if (transform.position == waypoint.position) {
                currentWaypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
