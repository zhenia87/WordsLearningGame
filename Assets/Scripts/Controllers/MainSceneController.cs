using UnityEngine;
using System.Collections;

public class MainSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnUnitSelected(int id)
    {
        if (id <= 0)
        {
            Application.LoadLevel("WordSelecting");
        }
        else
        {
            Application.LoadLevel("WordSelecting");
        }
    }
}
