using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public Text logTxt;
    public InputField englishWordInputField;
    public InputField translatedWordInputField;
    private DataService ds;
    void Awake()
    {
        logTxt.text = "";

    }
	// Use this for initialization
	void Start () 
    {
        ds = new DataService("words.bytes");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnButtonClick(int id)
    {
        logTxt.text = "";
        if (!string.IsNullOrEmpty(englishWordInputField.text) && !string.IsNullOrEmpty(translatedWordInputField.text))
        {
            AddWord(englishWordInputField.text, translatedWordInputField.text);
            UpdateWords();
            englishWordInputField.text = translatedWordInputField.text = "";
        }
        else
        {
            logTxt.text += "\n fill empty fields!!!";
        }
    }

    private void ToConsole(IEnumerable<WordItem> words)
    {
        foreach (var word in words)
        {
            ToConsole(word.ToString());
        }
    }

    private void ToConsole(string msgV)
    {
        Debug.Log(msgV);
        logTxt.text += msgV + "\n";
    }

    private void AddWord(string englishWord, string translatedWord)
    {
        ds.CreateWordItem(englishWord, translatedWord);
    }

    private void UpdateWords()
    {
        var words = ds.GetWordItems();
        ToConsole(words);
    }
}
