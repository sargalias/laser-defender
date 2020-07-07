using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject {
    public GameObject bullet = null;
    public float playerSpeed = 0;
    public float paddingPercent = 0;
    public float bulletFireRatePerMinute = 0;
    public int health;
}
