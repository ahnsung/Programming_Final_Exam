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
            bool added = InventoryManager.Instance.AddItem(itemType);

            if (added)
            {
                Destroy(gameObject);
            }
        }
    }
}