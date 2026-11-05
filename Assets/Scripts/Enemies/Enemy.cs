using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private int maxHealth;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Die()
    {
        Debug.Log("Bruh");
    }

    //Optionnel
    //Mathf.Abs = Valeur absolue (donc positive)
    public void Heal(int amount) => AddOrRemoveHealth(Mathf.Abs(amount));
    public void Damage(int amount) => AddOrRemoveHealth(-Mathf.Abs(amount));
    
    public void AddOrRemoveHealth(int health)
    {
        //Modification de la vie
        currentHealth += health;
        
        //Si la vie dépasse le max, on limite au max
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //Si la vie passe en dessous de 0...
        if (currentHealth <= 0)
        {
            //... Limiter à 0
            currentHealth = 0;
            
            //... et mourir
            Die();
        }
    }
}
