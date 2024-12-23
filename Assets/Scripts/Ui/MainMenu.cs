using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // permet de changer de scene lorsque l'ont appuie sur Play et/ou sur Quit dans le main menu
    public void PlayGame()
    {
        AudioManager.instance.PlaySfx1();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
