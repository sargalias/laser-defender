using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour {
    [SerializeField] private int health = 100;

    private void OnCollisionEnter2D(Collision2D other) {
        LaserDamage laserDamage = other.gameObject.GetComponent<LaserDamage>();
        int damageTaken = laserDamage.GetDamage();
        laserDamage.Hit();

        health -= damageTaken;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
