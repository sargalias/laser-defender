using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LaserDamage : MonoBehaviour {
    [SerializeField] private int damage = 100;

    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }
}
