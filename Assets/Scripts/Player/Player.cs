using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private PlayerData playerData = null;
    private PlayerData instance;
    private float bulletFireRatePerMinute;
    private GameObject projectile;

    internal Action HandleFireBullet;

    void Start() {
        instance = Instantiate(playerData);
        bulletFireRatePerMinute = instance.bulletFireRatePerMinute;
        projectile = instance.bullet;

        HandleFireBullet = PrepareFireBullet();
    }

    void Update() {
        HandleFireBullet();
    }

    private Action PrepareFireBullet() {
        DateTime lastBulletFired = DateTime.Now;

        Action HandleFireBullet = () => {
            Boolean canFire = lastBulletFired.AddMinutes(1 / bulletFireRatePerMinute) <= DateTime.Now;
            if (canFire && Input.GetButton("Fire1")) {
                Instantiate(projectile, transform.position, Quaternion.identity);
                lastBulletFired = DateTime.Now;
            }
        };

        return HandleFireBullet;
    }
}
