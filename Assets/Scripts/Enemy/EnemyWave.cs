using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour {
    [SerializeField] GameObject enemy = null;
    [SerializeField] float delayBetweenSpawns = 0;
    [SerializeField] int numEnemies = 0;
    [SerializeField] float speed = 0;
    [SerializeField] Transform path = null;

    private void Start() {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave() {
        for (int i = 0; i < numEnemies; i++) {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
        Destroy(gameObject);
    }

    private void SpawnEnemy(GameObject enemy) {
        GameObject enemyObject = Instantiate(enemy);
        enemyObject.transform.position = new Vector2(500, 500);
        EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();
        enemyMovement.speed = speed;
        enemyMovement.path = path;
    }
}
