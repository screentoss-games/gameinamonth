using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fade : MonoBehaviour {

    private UnityAction afterFade;
    private Animator animator;

    private static Fade instance;
    public static Fade Instance {
        get {
            return instance;
        }
    }
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            animator = GetComponent<Animator>();
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }
    public void FadeOut(UnityAction afterFade) {
        this.afterFade = afterFade;
        animator.SetTrigger("fadeOut");
    }

    private void FadeOutComplete() {
        if (afterFade != null) {
            afterFade.Invoke();
            afterFade = null;
        }
        EventManager.TriggerEvent(EventType.SCENE_FADED_OUT);
    }

    private void FadeInComplete() {
        EventManager.TriggerEvent(EventType.SCENE_FADED_IN);
    }
}
