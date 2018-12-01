using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapPoint : MonoBehaviour {

    public int mapPoint = 0;
    public GameObject introPanel;
    public GameObject outroPanel;

    public MapManager mapManager;

	// Use this for initialization
	void Awake () {

        mapManager = FindObjectOfType<MapManager>();
        outroPanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void OpenMap()
    {
        mapManager.gameObject.SetActive(true);
    }
}
