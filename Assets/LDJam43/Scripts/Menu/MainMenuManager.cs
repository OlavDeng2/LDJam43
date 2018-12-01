using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    private Panel[] menuPanels;

	// Use this for initialization
	void Awake () {
        menuPanels = GetComponentsInChildren<Panel>(true);
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
	
}
