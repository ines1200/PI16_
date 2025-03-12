using UnityEngine;

public class BoxPlacement : MonoBehaviour
{
    public StepManager stepManager;  // Référence au StepManager
    public Transform targetPosition; // La position où l'objet doit être placé correctement (par exemple, la pompe)

    // Appelée lorsque la boîte est posée au bon endroit
    public void OnBoxPlaced()
    {
        if (IsBoxCorrectlyPlaced())
        {
            // Si l'objet est au bon endroit, passe à l'étape suivante
            stepManager.CompleteStep();
        }
    }

    // Fonction pour vérifier si la boîte est bien placée
    bool IsBoxCorrectlyPlaced()
    {
        // Vérifie si la boîte est proche de la position cible (par exemple la pompe)
        return Vector3.Distance(transform.position, targetPosition.position) < 0.1f;
    }
}
