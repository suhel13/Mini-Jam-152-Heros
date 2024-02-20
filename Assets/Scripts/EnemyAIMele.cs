using UnityEngine;

public class EnemyAIMele : MonoBehaviour, IDeathAble
{
    [SerializeField] float movementSpeed;
    int direction = 1;

    [SerializeField] float cooldownDuration;
    float cooldownTimer;
    [SerializeField] float maxOffCenterPosition;
    Rigidbody2D rb2D;

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        rb2D.velocity = Vector2.right * movementSpeed;
        direction = 1;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = Vector2.right * movementSpeed * direction * CooldownMod();
    }

    float CooldownMod()
    { return GameManager.instance.cameraMovement.cameraSpeed * 0.25f + 0.5f; }

    private void Update()
    {
        if (transform.position.x > maxOffCenterPosition && direction == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            direction = -1;
        }
        else if (transform.position.x < -maxOffCenterPosition && direction == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            direction = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HpManager hpMan;
        if (collision.TryGetComponent(out hpMan))
        {
            GetComponent<AudioSource>().Play();
            Debug.Log(GetComponent<AudioSource>().clip.name);
            hpMan.TakeDamage(1);
        }
    }
}