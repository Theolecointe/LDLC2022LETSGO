using UnityEngine;
using TMPro;

public class ChangeTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // R�f�rence � l'objet TextMeshProUGUI que vous souhaitez modifier

    void Start()
    {
        // Assurez-vous que l'objet TextMeshProUGUI est attribu� dans l'inspecteur Unity
        if (textMeshPro == null)
        {
            Debug.LogError("Veuillez attribuer un objet TextMeshProUGUI dans l'inspecteur Unity.");
            return;
        }

        // Exemple d'utilisation : changez le texte apr�s 2 secondes
        Invoke("ChangeTextMeshProText", 2f);
    }

    void ChangeTextMeshProText()
    {
        // Changez le texte de l'objet TextMeshProUGUI
        textMeshPro.text = "Nouveau texte avec TextMeshPro !";
    }
}


