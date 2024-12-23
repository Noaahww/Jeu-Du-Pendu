using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLetter : MonoBehaviour
{
    [SerializeField] private char letter;
    private TextMeshProUGUI tmp;
    /// Appeller les lettres du clavier au start
    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = letter.ToString();
    }

    // fonction affiliée au clic du boutton. envoie la référence de la variable letter vers la fonction CheckWord contenue dans la classe GameManager
    public void GetLetter()
    {
        AudioManager.instance.PlaySfx1();
        GameManager.instance.CheckWord(letter);
    }
}
