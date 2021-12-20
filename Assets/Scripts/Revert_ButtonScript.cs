using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Revert_ButtonScript : MonoBehaviour
{
    [SerializeField] TMP_Text formedWord;

    private void Start()
    {
        formedWord = GameObject.FindGameObjectWithTag("WordFormation").GetComponent<TMP_Text>(); //Getting the formed word reference.
    }
    public void RemoveLetter()
    {
        formedWord.text = formedWord.text.Remove(formedWord.text.Length-1); //On clicking remove button, remove the last letter in the formed word. 
    }
}
