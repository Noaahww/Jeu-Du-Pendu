using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUi : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI tmp;
    
    // possibilité d'appuyer sur le boutton restart pour recommencer lorsque la partie est fini
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // possibilité d'appuyer sur le boutton quit pour quitter lorsque la partie est fini
    public void Quit()
    {
        Application.Quit();
    }

    // Si je gagne alors il y aura écris victoire, si je perd il y aura écris perdu
    public void GameOver(bool isWin)
    {
        if (isWin) 
        {
            tmp.text = "Victoire";
        }
        else 
        {
            tmp.text = "Perdu";
        }
        panel.SetActive(true);
    }
}
