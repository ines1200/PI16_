using UnityEngine;

public class CouvercleControlRight : MonoBehaviour
{
    public GameObject couvercle;  // Référence au couvercle
    public Transform rightHand;  // Référence à la position de la main droite
    public float openHeight = 0.5f;  // Hauteur à laquelle le couvercle est ouvert
    public float closedHeight = 0.1f;  // Hauteur à laquelle le couvercle est fermé
    public float speed = 2f;  // Vitesse à laquelle le couvercle se déplace

    private bool isHoldingCouvercle = false;  // Pour savoir si la main droite est en contact avec le couvercle

    void Update()
    {
        if (isHoldingCouvercle)
        {
            // Déplacer le couvercle en fonction de la position de la main droite
            float handMovement = rightHand.position.y;

            if (handMovement > closedHeight)
            {
                // Ouvrir le couvercle si la main monte
                couvercle.transform.position = Vector3.MoveTowards(couvercle.transform.position, 
                                                             new Vector3(couvercle.transform.position.x, openHeight, couvercle.transform.position.z),
                                                             speed * Time.deltaTime);
            }
            else
            {
                // Fermer le couvercle si la main descend
                couvercle.transform.position = Vector3.MoveTowards(couvercle.transform.position, 
                                                             new Vector3(couvercle.transform.position.x, closedHeight, couvercle.transform.position.z),
                                                             speed * Time.deltaTime);
            }
        }
    }

    // Détecter la main droite qui entre en contact avec le couvercle
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))  // Vérifie que l'objet qui entre en collision est la main droite
        {
            isHoldingCouvercle = true;  // Commencer à soulever le couvercle
        }
    }

    // Quand la main droite quitte le couvercle, on arrête de le soulever
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand"))  // Quand la main droite quitte le couvercle
        {
            isHoldingCouvercle = false;  // Arrêter de soulever le couvercle
        }
    }
}

