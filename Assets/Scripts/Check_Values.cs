using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Check_Values : MonoBehaviour
{
    [SerializeField] TMP_Text formedWord;
    [SerializeField] TMP_Text correctWord;
    [SerializeField] TMP_Text wrongWord;

    private GameManager gameManagerScript;


    private void Start()
    {
        gameManagerScript = GetComponent<GameManager>(); //Game Manager reference.
        formedWord = GameObject.FindGameObjectWithTag("WordFormation").GetComponent<TMP_Text>(); //Getting the formed word reference.
        correctWord.gameObject.SetActive(false); //Deactivating correct text at start.
        wrongWord.gameObject.SetActive(false); //Deactivating wrong text at start.
    }

    private void Update()
    {
        if (formedWord.text.Length == gameManagerScript.stringLength) //Checking number of letters for the word.
        {
            if(formedWord.text == gameManagerScript.activeObjectName) //If the word formed is correct.
            {
                correctWord.gameObject.SetActive(true);   
            }
            else 
            {
                wrongWord.gameObject.SetActive(true); //If the word formed is wrong.
            }
        }
        else if(formedWord.text.Length != gameManagerScript.activeObjectName.Length) //Disable correct/wrong text if word length is not equal to formed word length.
        {
            correctWord.gameObject.SetActive(false);
            wrongWord.gameObject.SetActive(false);
        }
    }
}
