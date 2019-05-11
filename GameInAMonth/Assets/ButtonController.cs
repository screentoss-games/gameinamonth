using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	// Use this for initialization

    public void startGame() {
        ScreenManager.Instance.ChangeScene(1);
    }
}
