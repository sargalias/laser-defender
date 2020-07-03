using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour {
    [SerializeField] GameObject enemy = null;
    [SerializeField] float delayBetweenSpawns = 0;
    [SerializeField] int numEnemies = 0;

    private IEnumerator SpawnWave() {
        for (int i = 0; i < numEnemies; i++) {
            Instantiate(enemy);
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
        Destroy(gameObject);
    }

    private void Start() {
        StartCoroutine(SpawnWave());
    }
}
