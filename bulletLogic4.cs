using UnityEngine;

public class bulletLogic4 : MonoBehaviour, IBulletLogic
{
    private Rigidbody2D rb;
    private shootingScript shootingScript;

    public float projectileSpeed;
    public float shootCooldown;
    public float recoilAmount;
    public Sprite weaponSprite;
    public AudioClip weaponSound;

    public float lifetime;
    public float baseProjectileDamage;
    //public float enhancedProjectileDamage;
    public float currentProjectileDamage;

    public float ProjectileSpeed => projectileSpeed;
    public float ShootCooldown => shootCooldown;
    public Sprite WeaponSprite => weaponSprite;
    public AudioClip WeaponSound => weaponSound;
    public float RecoilAmount => recoilAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        shootingScript = player.GetComponent<shootingScript>();

        Destroy(gameObject, lifetime);

        currentProjectileDamage = baseProjectileDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IEnemy enemy = other.gameObject.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentProjectileDamage);
                SelfDestruct();
            }
        }
        else
        {
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
