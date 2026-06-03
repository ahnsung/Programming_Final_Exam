using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Game/Monster Data")]
public class MonsterData : ScriptableObject
{
    public string monsterName;

    public int maxHp;

    public float moveSpeed;

    public int score;

    public float dropChance;
}