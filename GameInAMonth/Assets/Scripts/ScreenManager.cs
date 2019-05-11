using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

    private static ScreenManager screenManager;
    public Fade fader;
    // Use this for initialization

    public static ScreenManager Instance {
        get {
            return screenManager;
        }
    }
    void Awake() {
        if (screenManager == null) {
            screenManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (screenManager != this) {
            Destroy(gameObject);
        }
    }

    public void startGame() {
        fader.FadeOut(() => SceneManager.LoadScene(1));
    }
    public void ChangeScene(int sceneIndex) {
        fader.FadeOut(() => SceneManager.LoadScene(sceneIndex));
    }
    public void ChangeScene(string sceneName) {
        fader.FadeOut(() => SceneManager.LoadScene(sceneName));
    }
}
