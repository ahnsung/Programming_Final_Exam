using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemType itemType;
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            if (itemType == ItemType.Potion)
            {
                player.Heal(1);
                Debug.Log("포션 획득: 체력 1 회복");
            }
            else if (itemType == ItemType.Skill)
            {
                Debug.Log("스킬 아이템 획득");
            }

            Destroy(gameObject);
        }
    }
}