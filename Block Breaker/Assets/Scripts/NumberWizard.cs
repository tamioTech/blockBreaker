using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        UpdateGuessText();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPressHigher()
    {
        min = guess;
        NextGuess();

    }

    public void OnPressLower()
    {
        max = guess;
        NextGuess();
        
    }
    public void OnPressCorrect()
    {
        guessText.text = "I WIN!";
    }

    void NextGuess()
    {
        guess = Random.Range(min, max);
        UpdateGuessText();
    }

    void UpdateGuessText()
    {
        guessText.text = guess.ToString();
    }


    void StartGame()
    {
        max += 1;
        guess = (min + max) / 2;


    }

}
