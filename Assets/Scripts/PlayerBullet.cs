using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    [SerializeField]
    float speed = 100.0f;

    float maxY;

    void Start() {
        Camera camera = Camera.main;
        maxY = camera.ViewportToWorldPoint(Vector3.one).y;
    }

    void Update() {
        Move();
    }

    private void Move() {
        Vector2 move = Vector2.up * Time.deltaTime * speed;
        transform.Translate(move);
        if (transform.position.y > maxY) {
            Destroy(gameObject);
        }
    }
}
