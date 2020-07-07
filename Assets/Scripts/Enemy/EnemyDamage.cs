﻿using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour {
    [SerializeField] private EnemyData enemyData = null;
    private int health;

    private void Start() {
        health = enemyData.health;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PlayerProjectile") {
            LaserDamage laserDamage = other.gameObject.GetComponent<LaserDamage>();
            int damageTaken = laserDamage.GetDamage();
            laserDamage.Hit();

            health -= damageTaken;

            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
