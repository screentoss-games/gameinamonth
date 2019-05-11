using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour {

    public ParticleSystem confettiRain;
    private ParticleSystem confettiCannon;

    // Use this for initialization
    void Start() {
        confettiCannon = GetComponent<ParticleSystem>();
        EventManager.Subscribe(EventType.ALL_BLOCKS_DESTROYED, () => confettiCannon.Play());
    } 
    public void OnParticleSystemStopped() {
        confettiRain.Play();
    }
}
