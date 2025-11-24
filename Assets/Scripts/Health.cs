using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage( float damageToTake )
    {
        currentHealth -= damageToTake;
        OnTakeDamage.Invoke();
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
