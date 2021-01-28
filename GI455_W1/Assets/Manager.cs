using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public InputField inputWord;
    public Text result;

    public void FindTheWord()
    {
        if (inputWord.text == "Swing")
        {
            result.text = " [<color=#008000ff>" +inputWord.text + "</color>] is found";
        }
        else if (inputWord.text == "Sweep")
        {
            result.text = " [<color=#008000ff>" +inputWord.text + "</color>] is found";
        }
        else if (inputWord.text == "Swap")
        {
            result.text = " [<color=#008000ff>" +inputWord.text + "</color>] is found";
        }
        else if (inputWord.text == "Swear")
        {
            result.text = " [<color=#008000ff>" +inputWord.text + "</color>] is found";
        }
        else if (inputWord.text == "Swoosh")
        {
            result.text = " [<color=#008000ff>" +inputWord.text + "</color>] is found";
        }
        else 
        {
            result.text = " [<color=#ff0000ff>" +inputWord.text + "</color>] is not found";
        }
    }
}
