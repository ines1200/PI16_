using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject button; // Référence au bouton
    public float pressDepth = 0.05f; // Profondeur de l'enfoncement du bouton

    private Vector3 originalPosition; // Position d'origine du bouton
    private bool isPressed = false;

    void Start()
    {
        // Enregistrer la position originale du bouton
        originalPosition = button.transform.position;
    }

    // Détection de la collision avec la main
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rightHand")) // Si c'est la main qui entre en contact
        {
            // Enfoncer le bouton (ou activer une animation)
            isPressed = true;
            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - pressDepth, button.transform.position.z);
            Debug.Log("Bouton pressé !");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("rightHand")) // Si la main quitte le bouton
        {
            // Remettre le bouton en position initiale
            isPressed = false;
            button.transform.position = originalPosition;
            Debug.Log("Bouton relâché !");
        }
    }
}
