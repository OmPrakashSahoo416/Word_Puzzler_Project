using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterToWord : MonoBehaviour
{
    [SerializeField] Button letter;
    [SerializeField] TMP_Text letter_Text;
    [SerializeField] TMP_Text wordFormation;

    private void Start()
    {
        wordFormation = GameObject.FindGameObjectWithTag("WordFormation").GetComponent<TMP_Text>(); //Getting the formed word reference.

        wordFormation.text = ""; //Initializing formed word to empty string.
        letter = GetComponent<Button>(); //Each button of letter.
        letter_Text = GetComponentInChildren<TMP_Text>(); //Text component of letter button.
    }

    public void UpdateText()
    {
        wordFormation.text += letter_Text.text; //Adding letters to the word going to be formed.
        
    }
}
