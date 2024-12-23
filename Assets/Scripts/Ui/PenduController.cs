using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenduController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image penduImage;
    

    ///Appeller les images de 1-8 a chaque vie perdu
    public void UpdatePendu(int error)
    {   
        penduImage.sprite = sprites[error];
    }
}
