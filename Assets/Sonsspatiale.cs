using UnityEngine;

public class SpatializedAudio : MonoBehaviour
{
    public AudioClip soundClip;
    public Transform target; // Le joueur ou un objet repr�sentant le point d'�coute
    private AudioSource audioSource;

    void Start()
    {
        // Cr�ez et configurez l'AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.spatialBlend = 1.0f; // Assurez-vous que la spatialisation est activ�e
        audioSource.maxDistance = 10f; // Ajustez la distance maximale � laquelle le son peut �tre entendu

        // Commencez � jouer le son
        audioSource.Play();
    }

    void Update()
    {
        // Assurez-vous que le AudioSource et la cible sont d�finis
        if (audioSource != null && target != null)
        {
            // Calculez la position relative du son par rapport � la cible
            Vector3 relativePosition = target.position - transform.position;

            // Normalisez les coordonn�es pour obtenir des valeurs entre -1 et 1
            float normalizedX = Mathf.Clamp(relativePosition.x / 5.0f, -1f, 1f);
            float normalizedY = Mathf.Clamp(relativePosition.y / 5.0f, -1f, 1f);
            float normalizedZ = Mathf.Clamp(relativePosition.z / 5.0f, -1f, 1f);

            // Ajustez la position spatiale du son en fonction de la position relative
            audioSource.spatialBlend = 1.0f - Mathf.Abs(normalizedX); // R�duire la spatialisation le long de l'axe oppos� (Y)
            audioSource.panStereo = normalizedX; // Axe X
            // Ajoutez des ajustements suppl�mentaires pour les axes Y et Z si n�cessaire
        }
    }
}