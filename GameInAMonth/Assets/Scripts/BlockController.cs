﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockController : MonoBehaviour {

    public BlockDestroyedEvent OnBlockDestroyed = new BlockDestroyedEvent();

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() {

    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ball") {
            OnBlockDestroyed.Invoke(this);
            gameObject.SetActive(false);
        }
    }
    private void OnDisable() {
        OnBlockDestroyed.RemoveAllListeners();
    }
}