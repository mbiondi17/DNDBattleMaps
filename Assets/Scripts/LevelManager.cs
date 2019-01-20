using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) {
			if(SceneManager.GetActiveScene().name == "Title Page") {
				Quit();
			}
			else {
				SceneManager.LoadScene("Title Page");
			}
		}
    }

    public void LoadLevelByName(string levelName) {
		try {
			SceneManager.LoadScene(levelName);
		}
		catch(Exception ex) {
			Debug.LogError(ex.InnerException);
			Debug.Log("Level did not exist!");
		}
	}

	public void LoadNextLevel() {
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        try{
		    SceneManager.LoadScene(nextSceneIndex);
        } catch (Exception ex) {
            Debug.Log("No level with build index: " + nextSceneIndex);
            Debug.LogError("Exception: " + ex.InnerException);
        }

	}
	
	public void Quit() {
		Application.Quit();
	}
}
