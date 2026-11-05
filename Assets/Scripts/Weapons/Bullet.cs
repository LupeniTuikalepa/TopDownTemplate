using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody rb;

    private int bulletDamage;
    
    private void Start()
    {
        //Detruit la balle dans 15 secondes
        //C'est un * Garde fou *
        Destroy(gameObject, 15);
    }

    public void Fire(Vector3 direction, float speed, int damage)
    {
        rb.linearVelocity = direction.normalized * speed;
        
        bulletDamage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 1 : Est-ce que c'est un truc qui a des pvs ? (Un enemy)
        // 2 : Recuperer son script
        // 3 : Enlever des PVs
        // 4 : S'autodétruire
        
        //Etape 1 :
        Enemy hitEnemy = collision.gameObject.GetComponent<Enemy>();
        //Null : Rien du tout/Boite vide
        //  Comparaison ref :
        //  == : Est ce que c'est égal?
        //  != : Est ce que c'est différent?
        
        //Est-ce qu'on a touché un objet avec le script enemy?
        if (hitEnemy != null)
        {
            //Infliger des dégats.
            hitEnemy.AddOrRemoveHealth(-bulletDamage);
            
            //Utilisation de la methode optionnelle a la place
            //hitEnemy.Damage(bulletDamage);
        }

        //Se détruire au premier objet touché
        Destroy(gameObject);
    }
}
