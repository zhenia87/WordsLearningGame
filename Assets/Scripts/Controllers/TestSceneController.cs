using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TestSceneController : MonoBehaviour 
{
    public Text logTxt;
    public InputField englishWordInputField;
    public InputField translatedWordInputField;

    void Awake()
    {
        logTxt.text = "";
    }
	// Use this for initialization
	void Start () 
    {
        
	}

    public void SelectUnit()
    {
        Application.LoadLevel(Scenes.MAIN);
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
        DataService.Instance.CreateWordItem(englishWord, translatedWord);
    }

    private void UpdateWords()
    {
        var words = DataService.Instance.GetAllWordItems();
        ToConsole(words);
    }
}
