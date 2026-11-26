using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootUI : MonoBehaviour
{
    /*
     * Niveau 1 (Nul):
     * - On a une reference vers le joueur
     * - A chaque frame on met l'interface à jour
     *
     * Niveau 2 (Presque OK) :
     * - On trouve le joueur dans la scene
     * - A chaque frame on met l'interface à jour
     *
     * Niveau 3 (Opti) :
     * - On trouve le joueur dans la scene
     * - On met a jour l'interface que quand le nombre de balle change
    */


    [SerializeField]
    private PlayerShoot playerShoot;

    //Reference vers la jauge
    [SerializeField] private Image fill;
    //Reference vers le text
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        //On récupère les balles max
        int maxBulletCount = playerShoot.GetMaxBulletCount();
        //On récupère les balles actuelles
        int currentBulletCount = playerShoot.GetCurrentBulletCount();
        
        // Text = "ValeurActuelle/ValeurMax" dynamiquement
        text.text = $"{currentBulletCount} / {maxBulletCount}";

        //Recuperer le % de balle (current/max)
        /*
         * Pour 5 balles sur 10 :
         * t = 5 / 10 = 0.5f (50%)
         *
         * Pour 7 balles sur 20 :
         * t = 7 / 20 = 0.35f (35%)
         */
        float t = (float)currentBulletCount / maxBulletCount;
        
        //On update l'image
        fill.fillAmount = t;
    }
}
