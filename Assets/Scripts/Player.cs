using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float playerSpeed = 100.0f;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement() {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 move = moveDirection * Time.deltaTime * playerSpeed;
        transform.Translate(move);
    }
}
