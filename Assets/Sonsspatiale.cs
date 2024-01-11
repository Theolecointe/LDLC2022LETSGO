using UnityEngine;

public class SpatializedAudio : MonoBehaviour
{
    public AudioClip soundClip;
    public Transform target; // Le joueur ou un objet représentant le point d'écoute
    private AudioSource audioSource;

    void Start()
    {
        // Créez et configurez l'AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.spatialBlend = 1.0f; // Assurez-vous que la spatialisation est activée
        audioSource.maxDistance = 10f; // Ajustez la distance maximale à laquelle le son peut être entendu

        // Commencez à jouer le son
        audioSource.Play();
    }

    void Update()
    {
        // Assurez-vous que le AudioSource et la cible sont définis
        if (audioSource != null && target != null)
        {
            // Calculez la position relative du son par rapport à la cible
            Vector3 relativePosition = target.position - transform.position;

            // Normalisez les coordonnées pour obtenir des valeurs entre -1 et 1
            float normalizedX = Mathf.Clamp(relativePosition.x / 5.0f, -1f, 1f);
            float normalizedY = Mathf.Clamp(relativePosition.y / 5.0f, -1f, 1f);
            float normalizedZ = Mathf.Clamp(relativePosition.z / 5.0f, -1f, 1f);

            // Ajustez la position spatiale du son en fonction de la position relative
            audioSource.spatialBlend = 1.0f - Mathf.Abs(normalizedX); // Réduire la spatialisation le long de l'axe opposé (Y)
            audioSource.panStereo = normalizedX; // Axe X
            // Ajoutez des ajustements supplémentaires pour les axes Y et Z si nécessaire
        }
    }
}