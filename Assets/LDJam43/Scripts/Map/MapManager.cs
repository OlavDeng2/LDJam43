using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

    public int currentPoint = 0;

    public MapPoint[] mapPoints;

    public Image[] pointsOnMap;

	// Use this for initialization
	void Awake () {

        DisableAllLevels();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //enable the current point which the player is in.
    public void SetCurrentPoint(int newPoint)
    {
        DisableAllLevels();
        currentPoint = newPoint;
        mapPoints[newPoint - 1].gameObject.SetActive(true);
        pointsOnMap[newPoint - 1].color = new Color32(255,255,225,100);
    }

    //set the next point which the palyer is in
    public void SetNextPoint()
    {
        DisableAllLevels();

        currentPoint++;
        mapPoints[currentPoint - 1].gameObject.SetActive(true);
        pointsOnMap[currentPoint - 1].color = new Color32(255, 255, 225, 100);
    }

    public void CloseMap()
    {
        this.gameObject.SetActive(false);
    }

    //This disables all levels for use when switching between points as well as for beginning
    private void DisableAllLevels()
    {
        foreach (MapPoint mapPoint in mapPoints)
        {
            mapPoint.gameObject.SetActive(false);

        }
    }
}
