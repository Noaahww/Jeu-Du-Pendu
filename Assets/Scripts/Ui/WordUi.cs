using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI word;

    /// Utiliser pour que le text apparaisse a la place des "_"
    public void UpdateText(string newText)
    {
        word.text = newText;
    }
}
