using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour
{

    public string sceneName;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Selectable")) {
            SceneManager.LoadScene(sceneName);
        }
    }

}
