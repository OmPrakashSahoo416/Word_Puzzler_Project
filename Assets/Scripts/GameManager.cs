using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class thing //Forming a class of different items.
{
    public GameObject item;
    public string name;
    public int index;
}

public class GameManager : MonoBehaviour
{ 
    [SerializeField] int checkIndex = 0;
    [SerializeField] int presentIndex = 0;

    [SerializeField] Button hintButton; //Initializing hint button.
    [SerializeField] TMP_Text hintText;
    [SerializeField] TMP_Text formedWord;
    [SerializeField] Canvas gameCanvas; //Game Window.
    [SerializeField] Canvas startScreenCanvas; // Start UI.

    public thing[] things; //Instance of class of an item.
    public string activeObjectName;
    public int stringLength;

    private void Start()
    {
        hintButton.gameObject.SetActive(false); //Hint button disabled at start.
        hintText.gameObject.SetActive(false); ////Hint word disabled at start.

        gameCanvas.gameObject.SetActive(false); // Game Canvas deactivated at first.
        startScreenCanvas.gameObject.SetActive(true); //Start Screen active at first.

        StartCoroutine(ActivateHintButton()); //Hint button activation timer.

        presentIndex = Random.Range(0, things.Length); //Object index as a random number.

        stringLength = things[presentIndex].name.Length; //Used for reference in Check_Value Script.
        activeObjectName = things[presentIndex].name;
        hintText.text = activeObjectName; //Setting hint word as active item name.

        things[presentIndex].item.SetActive(true); //Start the game with a random image.
    }

    private void Update()
    {
        //Looping to obtain the active object details.
        foreach(thing t in things) 
        {
            if (t.item.activeInHierarchy)
            {             
                activeObjectName = t.name;
                stringLength = t.name.Length;
                hintText.text = t.name;
            }
        }
    }

    public void NextButton() //Next button functionality.
    {
        hintButton.gameObject.SetActive(false); //Everytime on click Next set hint button inactive.
        formedWord.text = "";
        StartCoroutine(ActivateHintButton());
        foreach(thing t in things) //Disabling object active in heirarchy.
        { 
            if (t.item.activeInHierarchy)
            {
                checkIndex = t.index-1;
                activeObjectName = t.name;
                stringLength = t.name.Length;
                hintText.text = t.name;
            }
            t.item.SetActive(false); //disables currently opened object.
        }

        for(int i = 0; i < things.Length; i++) //Randomnly generating next item.
        {
            presentIndex = Random.Range(0, things.Length); //Setting index value as random number.

            //Activated item is not equal to next item then generate.
            if (presentIndex != checkIndex)
            {
                things[presentIndex].item.SetActive(true);
                break;
            }
            
        }
    }

    IEnumerator ActivateHintButton() //Hint button counter for next 30 seconds.
    {
        yield return new WaitForSeconds(30f);
        hintButton.gameObject.SetActive(true);

    }

    IEnumerator Hint_Word_Activation() //Hint word getting only activated for 2 seconds.
    {
        hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        hintText.gameObject.SetActive(false);
    }

    public void HintButton() // Hint button functionality.
    {
        StartCoroutine(Hint_Word_Activation());
    }

    public void QuitButton()
    {
        Application.Quit(); //Quitting the game.
    }

    public void PlayButton() //Pressing on play button on Start UI.
    {
        StartCoroutine(ActivateHintButton());
        gameCanvas.gameObject.SetActive(true);
        startScreenCanvas.gameObject.SetActive(false);
    }

    public void Mainmenu() //Takes back to Start UI.
    {
        gameCanvas.gameObject.SetActive(false);
        startScreenCanvas.gameObject.SetActive(true);
    }
}

