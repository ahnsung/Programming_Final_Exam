using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHp = 3;
    public float moveSpeed = 2f;
    public int score = 10;

    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

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
        Destroy(gameObject);
    }
}