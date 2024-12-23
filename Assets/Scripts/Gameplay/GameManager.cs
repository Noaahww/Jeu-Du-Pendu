using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// Liste de mes mots pour le pendu
    private List<string> wordList = new List<string> {"banane","ananas","lourd","joie","aigle","estomac","souhait","table","lampe","citoyen","mouton","aiguille","musique","jaune","tapis","laborieux","papillon","commande","sifflet","froid","rapide","niche","prison","microscope","loupe","brouette","architecture","gentil","pelouse","cloche"};
    private string hiddenWord;
    private char[] shownWordArray;
    private string shownWord;
    [SerializeField] private PenduController penduController;
    [SerializeField] private WordUi wordUi;
    [SerializeField] private GameOverUi gameOverUi;
    private int error = 0;
    
    /// Donne en réference le script a la variable instance (Singleton)
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        /// Selection du mot au hasard parmis toute la liste au start
        hiddenWord = SelectWord();
        /// on fait apparaitre le mot sous forme d'un "_" 
        SetShownWord(hiddenWord);
        /// on reset le pendu
        error = 0;
        penduController.UpdatePendu(error);
    }

    string SelectWord() 
    {
        int rand = UnityEngine.Random.Range(0,wordList.Count);
        return wordList[rand];
    }

    ///Creer le mot et le faire apparaitre au start sous forme de "_"
     void SetShownWord(string word)
    {
        shownWordArray = new char[word.Length];

        for (int i = 0; i < word.Length; i++) 
        {
            shownWordArray[i] = '_';
        }

        wordUi.UpdateText(CreateWord());
    }

    /// ca renvoie le mot sous forme de string (chaine de charactère)
    string CreateWord()
    {
        shownWord = "";

        for (int i = 0; i < shownWordArray.Length; i++)
        {
            shownWord += shownWordArray[i];
        }
        return shownWord;
    }

    ///Lorsque la bonne lettre est appuyer, alors la lettre apparait sur le mot a la place du "_"
    public void CheckWord(char c)
    {
        if(hiddenWord.Contains(Char.ToLower(c)))
        {
            ///le mot contient la lettre
            ///modifié le shownWord.
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if(hiddenWord[i] == Char.ToLower(c))
                {
                    shownWordArray[i] = c;
                }
            }

           wordUi.UpdateText(CreateWord());
           ///Tester condition de victoire
           if (!CreateWord().Contains('_'))
           {
                gameOverUi.GameOver(true);
           }
        }
        else
        {
            ///le mot ne contient pas la lettre
            ///le joueur perd une vie
            ///si le joueur n'a plus de vie => GAME OVER
            error++;
            penduController.UpdatePendu(error);
            if (error>=7)
            {
                gameOverUi.GameOver(false);
            }
        }
    }
}
