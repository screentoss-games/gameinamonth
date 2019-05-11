using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // Use this for initialization
    void Start() {
        EventManager.Subscribe(EventType.ALL_BLOCKS_DESTROYED, OnAllBlocksDestroyed);
    }

    private void OnAllBlocksDestroyed() {
        StartCoroutine(EndGame());
    }
    private IEnumerator EndGame() {
        yield return new WaitForSecondsRealtime(5);
        ScreenManager.Instance.ChangeScene(0);
    }
}
