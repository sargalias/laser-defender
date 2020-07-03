using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Laser : MonoBehaviour {
    [SerializeField]
    float speed = 100.0f;

    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

}
