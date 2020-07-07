using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDamage : MonoBehaviour {
    [SerializeField] private PlayerData playerData = null;
    private int health;

    private void Start() {
        health = playerData.health;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "EnemyProjectile") {
            health = DamageDealer.Hit(other, health);

            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
