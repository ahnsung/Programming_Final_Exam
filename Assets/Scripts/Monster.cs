using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHp = 3;
    public float moveSpeed = 2f;
    public int score = 10;

    [Header("Drop")]
    public GameObject[] dropItemPrefabs;
    public float dropChance = 0.5f;

    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        TryDropItem();
        Destroy(gameObject);
    }

    void TryDropItem()
    {
        if (dropItemPrefabs == null || dropItemPrefabs.Length == 0) return;

        float randomValue = Random.value;

        if (randomValue <= dropChance)
        {
            int randomIndex = Random.Range(0, dropItemPrefabs.Length);
            Instantiate(dropItemPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}