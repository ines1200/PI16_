using UnityEngine;

public class WaterPouring : MonoBehaviour
{
    public ParticleSystem waterParticles;  // Référence au système de particules d'eau
    public GameObject bottleObject;  // Référence à l'objet bouteille 3D
    public GameObject glassObject;  // Référence à l'objet représentant le verre (récipient)
    public GameObject waterInGlass;  // Référence à l'objet représentant l'eau dans le verre
    private bool isPouring = false;  // Pour savoir si l'eau est en train de couler
    private Transform bottleTransform;  // Référence au transform de la bouteille (pour l'inclinaison)
    private float maxWaterHeight;  // Hauteur maximale du niveau d'eau (la moitié du verre)
    private float currentWaterHeight = 0.0f;  // Hauteur actuelle de l'eau dans le verre

    void Start()
    {
        // Assurer que le système de particules est désactivé au départ
        waterParticles.Stop();
        bottleTransform = bottleObject.transform;  // Récupère le transform de l'objet bouteille

        // Récupère la hauteur maximale du verre (mi-hauteur)
        maxWaterHeight = glassObject.transform.localScale.y / 2;
    }

    void Update()
    {
        // Détecter l'inclinaison de la bouteille pour activer ou désactiver l'écoulement de l'eau
        if (bottleTransform.rotation.eulerAngles.x > 45 && !isPouring)
        {
            StartPouring();
        }
        else if (bottleTransform.rotation.eulerAngles.x < 45 && isPouring)
        {
            StopPouring();
        }

        // Si l'eau est en train de couler et que le niveau d'eau n'a pas atteint la limite
        if (isPouring && currentWaterHeight < maxWaterHeight)
        {
            PourWater();
        }
    }

    void StartPouring()
    {
        // Active les particules lorsque la bouteille est inclinée
        waterParticles.Play();
        isPouring = true;
    }

    void StopPouring()
    {
        // Arrête les particules lorsque la bouteille est droite
        waterParticles.Stop();
        isPouring = false;
    }

    void PourWater()
    {
        // Augmente la hauteur de l'eau dans le verre en fonction de la vitesse de versement
        float pourSpeed = 0.01f;  // Vitesse de l'écoulement de l'eau

        currentWaterHeight += pourSpeed * Time.deltaTime;

        // Limite la hauteur de l'eau pour qu'elle ne dépasse pas la moitié du verre
        if (currentWaterHeight > maxWaterHeight)
        {
            currentWaterHeight = maxWaterHeight;
        }

        // Met à jour l'échelle du cylindre représentant l'eau dans le verre
        waterInGlass.transform.localScale = new Vector3(0.15f, currentWaterHeight, 0.15f);
        waterInGlass.transform.localPosition = new Vector3(0, currentWaterHeight / 2, 0);  // Ajuste la position pour bien remplir le verre
    }
}
