using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    [Header("Stats")]
    //Temps de rechargement
    [SerializeField] private float reloadTime;

    //Nombre de balles
    [SerializeField] private int maxBulletCount;
    
    private int currentBulletCount;

    //Vitesse balle
    [SerializeField, Tooltip("en metres/secondes")]
    private float bulletSpeed;

    //Portee tir
    [SerializeField] private float bulletRange;

    //Cadence tirs
    [SerializeField, Tooltip("par secondes")]
    private float fireRate;

    //Degats de balles
    [SerializeField] private int bulletDamage;

    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField] 
    private PlayerControls playerControls;

    private void Start()
    {
        Reload();
    }

    //Appelé à chaque frame
    private void Update()
    {
        Aim();

        /*
        - Personne ne fait ça
        if (playerControls.isShooting is true)
        - C'est pour les debutant
        if (playerControls.isShooting == true)
        - Top ça
        if (playerControls.isShooting)
        */
        
        //Pour les if :
        //Et = &&
        //Ou = ||
        
        //Si je devrais etre en train de tirer ET que j'ai au moins une balle...
        if (playerControls.isShooting == true && currentBulletCount > 0)
        {
            //Tirer
            Shoot();
        }
        
        //Si je devrais etre en train de recharger...
        if(playerControls.isReloading)
            //Alors recharger.
            Reload();
    }

    private void Shoot()
    {
        //Spawn la balle et on stock le gameobject
        GameObject spawnedBullet = Instantiate(bulletPrefab);
        
        //On regarde si il a le script
        Bullet leScriptDeLaBalle = spawnedBullet.GetComponent<Bullet>();
        
        //On execute Fire du script sur la balle qu'on a spawn
        leScriptDeLaBalle.Fire(transform.forward, bulletSpeed);
    }

    private void Reload()
    {
        currentBulletCount = maxBulletCount;
        //Debug.Log("Reload");
    }

    private void Aim()
    {
        //Debug.Log($"Aiming {playerControls.aimInput}");
    }
}