using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Data")]
    public MonsterData data;

    [Header("Drop")]
    public GameObject[] dropItemPrefabs;

    private int currentHp;

    void Start()
    {
        if (data == null)
        {
            Debug.LogError(gameObject.name + " MonsterData가 연결되지 않았습니다.");
            return;
        }

        currentHp = data.maxHp;
    }

    void Update()
    {
        if (data == null) return;

        transform.position += Vector3.down * data.moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (data == null) return;

        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(data.score);
        }

        TryDropItem();
        Destroy(gameObject);
    }

    void TryDropItem()
    {
        if (dropItemPrefabs == null || dropItemPrefabs.Length == 0)
            return;

        if (Random.value <= data.dropChance)
        {
            int randomIndex = Random.Range(0, dropItemPrefabs.Length);
            Instantiate(dropItemPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}