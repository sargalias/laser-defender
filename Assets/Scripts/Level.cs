using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private GameObject[] waves = null;
    [SerializeField] private float secondsBetweenSpawns = 0;
    private int currentWaveIndex = 0;

    private void Start() {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves() {
        while (true) {
            Instantiate(waves[currentWaveIndex]);
            currentWaveIndex = (currentWaveIndex + 1) % waves.Length;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
