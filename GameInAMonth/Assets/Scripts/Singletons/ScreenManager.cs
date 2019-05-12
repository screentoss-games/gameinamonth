using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ScreenManager : MonoBehaviour {

    private static ScreenManager screenManager;
    private Animator animator;
    private UnityAction afterFade;
    // Use this for initialization

    public static ScreenManager Instance {
        get {
            return screenManager;
        }
    }
    void Awake() {
        if (screenManager == null) {
            screenManager = this;
            animator = GetComponent<Animator>();
            DontDestroyOnLoad(gameObject);
        }
        else if (screenManager != this) {
            Destroy(gameObject);
        }
    }

    public void startGame() {
        FadeOut(() => SceneManager.LoadScene(1));
    }
    public void ChangeScene(int sceneIndex) {
        FadeOut(() => SceneManager.LoadScene(sceneIndex));
    }
    public void ChangeScene(string sceneName) {
        FadeOut(() => SceneManager.LoadScene(sceneName));
    }

    private void FadeOut(UnityAction afterFade) {
        if(this.afterFade != null) {
            Debug.Log("Cannot set multiple fade out actions!");
            return;
        }
        this.afterFade = afterFade;
        animator.SetTrigger("fadeOut");
    }

    private void FadeOutComplete() {
        EventManager.TriggerEvent(EventType.SCENE_FADED_OUT);
        afterFade.Invoke();
        afterFade = null;
    }

    private void FadeInComplete() {
        EventManager.TriggerEvent(EventType.SCENE_FADED_IN);
    }
}
