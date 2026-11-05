using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.4f;

    [SerializeField] 
    private PlayerControls playerControls;

    [SerializeField] 
    private Rigidbody rb;
    
    private void FixedUpdate()
    {
        MovePlayer();
        
        RotatePlayer();
    }
    
    private void MovePlayer()
    {
        Vector2 input = playerControls.movementInput;
        
        Vector3 direction = new Vector3(input.x, 0, input.y);

        Vector3 velocity = direction * speed;
        
        rb.linearVelocity =  velocity;
    }

    private void RotatePlayer()
    {
        //On recupere l'input
        Vector2 input = playerControls.aimInput;
        
        //Si je ne touche pas au stick alors ça sert a rien de tourner.
        // Est ce que la taille du vecteur est un peu superieure a 0.
        
        //sqrMagnitude : A utiliser dans 90% des cas, quand la valeur EXACTE de la taille d'un vecteur n'est pas nécéssaire
        if(input.sqrMagnitude <= 0.1f)
            return;
        
        Vector3 direction = new Vector3(input.x, 0, input.y);
        
        /*
         * On pourrait faire comme ça (c'est pas une grosse erreur)
         * transform.forward = direction;
         */
        
        //Demande a unity la rotation pour qu'on regarde dans la bonne direction avec la tete vers le haut
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        
        //Applique la rotation
        rb.rotation = targetRotation;
    }
}
