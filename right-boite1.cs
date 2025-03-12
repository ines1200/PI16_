using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndPlaceBox : MonoBehaviour
{
    public Transform targetPosition; // Position cible sur le conteneur
    private XRGrabInteractable grabInteractable; // Référence au composant XRGrabInteractable
    private bool isPlaced = false; // Vérifie si la boîte a été placée

    void Start()
    {
        // Récupère le composant XRGrabInteractable attaché à l'objet
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Vérifie que le composant XRGrabInteractable est bien attaché à l'objet
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable n'est pas attaché à l'objet.");
        }
    }

    // Cette méthode est appelée quand l'objet est saisi
    public void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("RightHand"))
        {
            // Lorsque la boîte est saisie avec la main droite, on désactive le "placement" automatique
            isPlaced = false;
        }
    }

    // Cette méthode est appelée quand l'objet est relâché
    public void OnSelectExited(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("RightHand"))
        {
            // Lorsque la boîte est relâchée, on vérifie si elle est placée sur le conteneur
            if (targetPosition != null && !isPlaced)
            {
                PlaceOnContainer();
            }
        }
    }

    // Cette méthode permet de "placer" la boîte sur la position cible du conteneur
    private void PlaceOnContainer()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.5f)
        {
            // Si la boîte est proche de la position cible, on la place directement sur le conteneur
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation; // Optionnel : pour que la boîte soit alignée avec le conteneur
            isPlaced = true; // Marquer la boîte comme placée
        }
    }
}
