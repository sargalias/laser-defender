using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private float playerSpeed = 100.0f;
    [SerializeField] private float paddingPercent = 0.05f;
    [SerializeField] private float bulletFireRatePerMinute = 60f;

    internal Action HandlePlayerMovement;
    internal Action HandleFireBullet;

    void Start() {
        HandlePlayerMovement = PrepareHandlePlayerMovement();
        HandleFireBullet = PrepareFireBullet();
    }

    void Update() {
        HandlePlayerMovement();
        HandleFireBullet();
    }

    private Action PrepareHandlePlayerMovement() {
        Camera gameCamera = Camera.main;
        Vector3 minPosition = gameCamera.ViewportToWorldPoint(new Vector3(paddingPercent, paddingPercent, 0));
        Vector3 maxPosition = gameCamera.ViewportToWorldPoint(new Vector3(1 - paddingPercent, 1 - paddingPercent, 0));

        Func<Vector2> CalculateMovePosition = () => {
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
        };

        Action<Vector2> Move = (Vector2 position) => {
            transform.position = position;
        };

        Action HandlePlayerMovement = () => {
            Vector2 newPosition = CalculateMovePosition();
            Move(newPosition);
        };

        return HandlePlayerMovement;
    }

    private Action PrepareFireBullet() {
        DateTime lastBulletFired = DateTime.Now;
        float bulletYDisplacement = GetComponent<SpriteRenderer>().size.y / 2;

        Action HandleFireBullet = () => {
            Boolean canFire = lastBulletFired.AddMinutes(1 / bulletFireRatePerMinute) <= DateTime.Now;
            if (canFire && Input.GetButton("Fire1")) {
                Instantiate(bullet, transform.position, Quaternion.identity);
                lastBulletFired = DateTime.Now;
            }
        };

        return HandleFireBullet;
    }
}
