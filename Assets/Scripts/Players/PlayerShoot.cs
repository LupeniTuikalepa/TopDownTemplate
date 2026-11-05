using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Stats")]
    //Temps de rechargement
    [SerializeField]
    private float reloadTime;

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

    //Compteur en temps réel.
    private float lastShotTime = 0;

    //Degats de balles
    [SerializeField] private int bulletDamage;

    [Header("References")] [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField] 
    private PlayerControls playerControls;

    [SerializeField] 
    private Transform gun;

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

        //Temps entre chaques balles
        float timeBetweenBullets = 1 / fireRate;

        /*
         Opérateurs :
            - lastShotTime -= soustraction
            - lastShotTime *= multiplication
            - lastShotTime /= division
        */
        //Time.deltaTime : Temps en secondes depuis la frame précédente
        /*
         * Ajouter à LastShotTime le temps en secondes d'une frame
         * Frame 1 :
         *          (lastShotTime = 0)
         *          += 0.016
         *
         * Est ce que c'est assez ? Non.
         *
         * Frame 2 :
         *          (lastShotTime = 0.016)
         *          += 0.032f
         *          (lastShotTime = 0.048)
         *
         * Est ce que c'est assez ? Non.
         */
        lastShotTime += Time.deltaTime;
        
        
        /*
         Pour les if :
            Et = &&
            Ou = ||
            
            Comparateurs :
            == : Egal?
            > : Superieur ?
            < : Inferieur ?
            >= : Superieur ou égal ?
            <= : Inferieur ou égal ?
        */
        //Si je devrais etre en train de tirer ET que j'ai au moins une balle...
        // ET SI le temps depuis le dernier tir est supérieur ou egal au temps entre chaque balle
        if (playerControls.isShooting == true && currentBulletCount > 0 && lastShotTime >= timeBetweenBullets)
        {
            //Reset du timer
            lastShotTime = 0;
            
            //Tirer
            Shoot();
        }

        //Si je devrais etre en train de recharger...
        if (playerControls.isReloading)
            //Alors recharger.
            Reload();
    }

    private void Shoot()
    {
        //Spawn la balle et on stock le gameobject
        //La balle spawn a la position du gun et avec son orientation
        GameObject spawnedBullet = Instantiate(bulletPrefab, gun.position, gun.rotation);

        //On regarde si il a le script
        Bullet leScriptDeLaBalle = spawnedBullet.GetComponent<Bullet>();

        //On execute Fire du script sur la balle qu'on a spawn
        leScriptDeLaBalle.Fire(transform.forward, bulletSpeed, bulletDamage, bulletRange);

        //currentBulletCount--; : Enlever 1.
        //currentBulletCount++; : Ajouter 1
        
        currentBulletCount -= 1;
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