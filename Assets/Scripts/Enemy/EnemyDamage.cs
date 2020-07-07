using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour {
    [SerializeField] private EnemyData enemyData = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PlayerProjectile") {
            LaserDamage laserDamage = other.gameObject.GetComponent<LaserDamage>();
            int damageTaken = laserDamage.GetDamage();
            laserDamage.Hit();

            enemyData.health -= damageTaken;

            if (enemyData.health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
