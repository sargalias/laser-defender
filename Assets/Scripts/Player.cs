using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private float playerSpeed = 100.0f;
    [SerializeField] private float paddingPercent = 0.05f;
    [SerializeField] private float bulletFireRatePerMinute = 60f;

    private DateTime lastBulletFired = DateTime.Now;
    private Vector3 minPosition;
    private Vector3 maxPosition;

    void Start() {
        Camera gameCamera = Camera.main;
        minPosition = gameCamera.ViewportToWorldPoint(new Vector3(paddingPercent, paddingPercent, 0));
        maxPosition = gameCamera.ViewportToWorldPoint(new Vector3(1 - paddingPercent, 1 - paddingPercent, 0));
    }

    void Update() {
        HandlePlayerMovement();
        HandleFireBullet();
    }

    private void HandlePlayerMovement() {
        Vector2 newPosition = CalculateMovePosition();
        Move(newPosition);
    }

    private Vector2 CalculateMovePosition() {
        Vector2 moveDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
        Vector2 move = moveDirection * Time.deltaTime * playerSpeed;

        Vector2 unclampedPosition = (Vector2)transform.position + move;
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(unclampedPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(unclampedPosition.y, minPosition.y, maxPosition.y)
        );
        return clampedPosition;
    }

    private void Move(Vector2 position) {
        transform.position = position;
    }

    private void HandleFireBullet() {
        Boolean canFire = lastBulletFired.AddMinutes(1 / bulletFireRatePerMinute) <= DateTime.Now;
        if (canFire && Input.GetButton("Fire1")) {
            Instantiate(bullet, Vector2.zero, Quaternion.identity);
            lastBulletFired = DateTime.Now;
        }
    }
}
