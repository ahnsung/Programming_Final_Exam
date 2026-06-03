using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 1;
    public float destroyY = 6f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Monster monster = other.GetComponent<Monster>();

        if (monster != null)
        {
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}