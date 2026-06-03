using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 7f;
    public float xLimit = 8f;

    [Header("Shoot")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;

    private float fireTimer;

    private float originalFireRate;
    private float rapidFireTimer;
    private bool isRapidFire;

    void Start()
    {
        originalFireRate = fireRate;
    }

    void Update()
    {
        Move();
        AutoShoot();
        UpdateSkillTimer();
    }

    void Move()
    {
        float x = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                x = -1f;
            }

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                x = 1f;
            }
        }

        Vector3 pos = transform.position;
        pos.x += x * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);

        transform.position = pos;
    }

    void AutoShoot()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;

            if (bulletPrefab != null && firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }
        }
    }

    public void ActivateRapidFire(float duration)
    {
        isRapidFire = true;
        rapidFireTimer = duration;
        fireRate = 0.08f;
    }

    void UpdateSkillTimer()
    {
        if (!isRapidFire)
            return;

        rapidFireTimer -= Time.deltaTime;

        if (rapidFireTimer <= 0f)
        {
            isRapidFire = false;
            fireRate = originalFireRate;
        }
    }
}