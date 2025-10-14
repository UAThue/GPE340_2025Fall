using UnityEngine;


[RequireComponent(typeof(Weapon))]
public class WA_Autofire : MonoBehaviour
{
    [Header("Weapon Data")]
    public Transform firePoint;
    public float projectileForce = 5000.0f;
    public float fireRate = 1.0f;

    [Header("Prefabs")]
    public GameObject projectilePrefab; 

    [Header("Autoregister Events")]
    public bool isAutoRegisterPrimaryAttack;
    public bool isAutoRegisterSecondaryAttack;

    // Private variables
    private bool isShooting = false;
    private float nextFireTime;
    private Weapon weaponComponent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Register our actual functions with the events in the weapon component
        weaponComponent = GetComponent<Weapon>();

        if (isAutoRegisterPrimaryAttack )
        {
            weaponComponent.onTriggerPressed.AddListener(StartShooting);
            weaponComponent.onTriggerReleased.AddListener(StopShooting);
        }

        if (isAutoRegisterSecondaryAttack)
        {
            weaponComponent.onAltFirePressed.AddListener(StartShooting);
            weaponComponent.onAltFireReleased.AddListener(StopShooting);
        }

        // Set our next fire time
        nextFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // If we are shooting, shoot a bullet
        if (isShooting)
        {
            TryShoot();
        }
    }

    public void TryShoot()
    {
        //TODO: if we can do whatever we need to to shoot, then shoot
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + (1/fireRate);
        }
    }

    public void Shoot()
    {
        // Projectile Shot
        // Instantiate the bullet
        GameObject theBullet = Instantiate( projectilePrefab, firePoint.position, firePoint.rotation ) as GameObject;

        // Set the data
        if (theBullet.TryGetComponent<DamageOnHit>(out var damageOnHitComponent)) 
        {         
            damageOnHitComponent.damageDone = weaponComponent.damageDone;
        }

        // Apply force
        Rigidbody rb = theBullet.GetComponent<Rigidbody>();
        rb.AddForce(projectileForce * firePoint.forward);

        // The bullet handles the rest
        // Debug.Log("pew!");
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }
}
