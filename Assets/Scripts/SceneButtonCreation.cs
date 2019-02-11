using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;

public class SceneButtonCreation : MonoBehaviour
{

    public Button levelButton = null;
    public RectTransform buttonParent = null;

    void Start()
    {

        var columns = 3;
        var columnWidth = buttonParent.sizeDelta.x / columns;
        var rowHeight = 100;
        var rows = 0;
        var activeScenes = new List<String>();
        var rowPadding = 50;

        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            if(SceneUtility.GetScenePathByBuildIndex(i) != SceneManager.GetActiveScene().path) {
                activeScenes.Add(SceneUtility.GetScenePathByBuildIndex(i));
            }
        }

        rows = Mathf.CeilToInt(activeScenes.Count / 3.0f);
        buttonParent.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonParent.GetComponent<RectTransform>().sizeDelta.x, rows*rowHeight);

        for(int i = 0; i < activeScenes.Count; i++) {
            //create button for scene!
            var newButton = GameObject.Instantiate(levelButton);

            var pathChunks = activeScenes[i].Split('/');
            var sceneName = pathChunks[pathChunks.Length - 1].Split('.')[0];
            newButton.GetComponentInChildren<Text>().text = sceneName;
            newButton.GetComponent<RectTransform>().anchorMin = new Vector2(0,1);
            newButton.GetComponent<RectTransform>().anchorMax = new Vector2(0,1);
            newButton.GetComponent<Transform>().SetParent(buttonParent);

            var columnNumber = (i) % columns; 
            var buttonX = columnWidth*columnNumber - (columnWidth / 2) - (newButton.GetComponent<RectTransform>().sizeDelta.x * 0.825f);
            var buttonRow = Mathf.FloorToInt(i / columns);
            var buttonY = (-1 * buttonRow * rowHeight) - rowPadding + buttonParent.GetComponent<RectTransform>().sizeDelta.y / 2;

            newButton.GetComponent<RectTransform>().localPosition = new Vector2(buttonX, buttonY);

            newButton.GetComponent<Button>().onClick.AddListener(delegate {GameObject.Find("GameManager").GetComponent<LevelManager>().LoadLevelByName(sceneName);});  



        }
    }
    void Update()
    {
        
    }
}
