using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	Rigidbody m_rigidBody;
	public Vector3 m_direction = new Vector3(0, 1, 0);
	public float BallSpeed;
	// Use this for initialization
	void Start() {
		m_rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 pos = m_rigidBody.position;
		m_rigidBody.velocity = m_direction.normalized * BallSpeed;
		// Vector3 posDelta = (new Vector3(m_direction.x, m_direction.y, 0).normalized * BallSpeed * Time.deltaTime);
	}
}