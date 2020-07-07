using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {
    [SerializeField] private float minFireDelay = 0;
    [SerializeField] private float maxFireDelay = 0;
    [SerializeField] private GameObject projectile = null;

    private float remainingTimeToFire = 0;

    private void Start() {
        ResetFireDelay();
    }

    private void ResetFireDelay() {
        remainingTimeToFire = Random.Range(minFireDelay, maxFireDelay);
    }

    private void Update() {
        remainingTimeToFire -= Time.deltaTime;
        if (remainingTimeToFire <= 0) {
            Fire();
            ResetFireDelay();
        }
    }

    private void Fire() {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
