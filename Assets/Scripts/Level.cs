using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] GameObject enemy = null;

    private void Start() {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {
        while (true) {
            Instantiate(enemy);
            yield return new WaitForSeconds(1);
        }
    }
}
