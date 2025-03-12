using UnityEngine;

public class HoldGlass : MonoBehaviour
{
    public GameObject glass;  // Référence au verre
    public Transform leftHand;  // Main gauche en VR
    private bool isHolding = false;  // Pour savoir si le verre est pris par la main gauche

    void Update()
    {
        if (isHolding)
        {
            // Maintenir le verre dans la position de la main gauche
            glass.transform.position = leftHand.position;
            glass.transform.rotation = leftHand.rotation;
        }
    }

    // Lorsque la main gauche touche le verre, on commence à le maintenir
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            isHolding = true;
        }
    }

    // Lorsque la main gauche ne touche plus le verre, on arrête de le tenir
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Glass"))
        {
            isHolding = false;
        }
    }
}
