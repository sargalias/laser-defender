using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public static int Hit(Collider2D other, int health) {
        LaserDamage laserDamage = other.gameObject.GetComponent<LaserDamage>();
        int damageTaken = laserDamage.GetDamage();
        laserDamage.Hit();

        return health - damageTaken;
    }
}
