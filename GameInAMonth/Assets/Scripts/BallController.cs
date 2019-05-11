using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody m_rigidBody;
    public Vector3 m_direction = new Vector3(0, 1, 0);
    public bool alreadyReflected = false;
    public float BallSpeed;
    // Use this for initialization
    void Start() {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    public void Fire() {
        this.transform.SetParent(null);
        m_rigidBody.isKinematic = false;
        m_rigidBody.AddForce(Vector3.up * BallSpeed);
    }
    // Update is called once per frame
    // void OnCollisionEnter(Collision collision) {
    // 	if (collision.gameObject.tag == "Level") {
    // 		// BallController ball = collision.gameObject.GetComponent<BallController>();
    // 		Vector3 faceNormal = Vector3.zero;
    // 		int normalCount = 0;
    // 		foreach (ContactPoint c in collision.contacts) {
    // 			if (c.normal != null) {
    // 				faceNormal += c.normal;
    // 				normalCount++;
    // 			}
    // 		}
    // 		faceNormal /= normalCount;
    // 		if (Vector3.Dot(m_direction, faceNormal) < 0) {
    // 			m_direction = Vector3.Reflect(m_direction, faceNormal.normalized);
    // 		}
    // 	}
    // }
}