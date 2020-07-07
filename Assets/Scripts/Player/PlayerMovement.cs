using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private PlayerData playerData = null;
    private float paddingPercent;
    private float speed;

    Camera gameCamera = null;
    Vector3 minPosition = Vector3.zero;
    Vector3 maxPosition = Vector3.zero;

    private void Start() {
        paddingPercent = playerData.paddingPercent;
        speed = playerData.playerSpeed;

        gameCamera = Camera.main;
        minPosition = gameCamera.ViewportToWorldPoint(new Vector3(paddingPercent, paddingPercent, 0));
        maxPosition = gameCamera.ViewportToWorldPoint(new Vector3(1 - paddingPercent, 1 - paddingPercent, 0));

    }

    private void Update() {
        Vector2 newPosition = CalculateMovePosition();
        Move(newPosition);
    }

    private Vector2 CalculateMovePosition() {
        Vector2 moveDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
        Vector2 move = moveDirection * Time.deltaTime * speed;

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
}
