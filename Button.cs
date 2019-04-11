using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    private void Start() {
        //Set anti-aliasing to use x8 Multisampling
        QualitySettings.antiAliasing = 8;
    }

    //Load next scene
    public void Begin(string scene) {
        SceneManager.LoadScene(scene);
    }

}
