using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameOutput;
    [SerializeField] private GameObject keyboardPanel;
    private string outputText = "";
    private int letterCounter = 0;
    private int displayNumber;

    public void EnterMushroomName(int index)
    {
        displayNumber = index;
        keyboardPanel.SetActive(true);
        nameOutput.text = "";
    }

    private void AddLetter(char letter)
    {
        if (letterCounter < 8)
        {
            outputText += letter;
            nameOutput.text = outputText;
            letterCounter++;
        }
    }

    public void RemoveLetter()
    {
        if (letterCounter > 0)
        {
            outputText = outputText.Remove(outputText.Length - 1, 1);
            nameOutput.text = outputText;
            letterCounter--;
        }
    }

    public void EnterName()
    {
        FindObjectOfType<GameManager>().GetComponent<GameManager>(). SaveMushroomName(displayNumber, outputText);
        keyboardPanel.SetActive(false);
        outputText = "";
        letterCounter = 0;
        nameOutput.text = "";
    }
    
    #region "Letters"
    public void AddLetterA()
    {
        AddLetter('a');
    }
    public void AddLetterB()
    {
        AddLetter('b');
    }
    public void AddLetterC()
    {
        AddLetter('c');
    }
    public void AddLetterD()
    {
        AddLetter('d');
    }
    public void AddLetterE()
    {
        AddLetter('e');
    }
    public void AddLetterF()
    {
        AddLetter('f');
    }
    public void AddLetterG()
    {
        AddLetter('g');
    }
    public void AddLetterH()
    {
        AddLetter('h');
    }
    public void AddLetterI()
    {
        AddLetter('i');
    }
    public void AddLetterJ()
    {
        AddLetter('j');
    }
    public void AddLetterK()
    {
        AddLetter('k');
    }
    public void AddLetterL()
    {
        AddLetter('l');
    }
    public void AddLetterM()
    {
        AddLetter('m');
    }
    public void AddLetterN()
    {
        AddLetter('n');
    }
    public void AddLetterO()
    {
        AddLetter('o');
    }
    public void AddLetterP()
    {
        AddLetter('p');
    }
    public void AddLetterQ()
    {
        AddLetter('q');
    }
    public void AddLetterR()
    {
        AddLetter('r');
    }
    public void AddLetterS()
    {
        AddLetter('s');
    }
    public void AddLetterT()
    {
        AddLetter('t');
    }
    public void AddLetterU()
    {
        AddLetter('u');
    }
    public void AddLetterV()
    {
        AddLetter('v');
    }
    public void AddLetterW()
    {
        AddLetter('w');
    }
    public void AddLetterX()
    {
        AddLetter('x');
    }
    public void AddLetterY()
    {
        AddLetter('y');
    }
    public void AddLetterZ()
    {
        AddLetter('z');
    }
    #endregion
}
