using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CleanupBarrier : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(collider.gameObject);
    }
}
