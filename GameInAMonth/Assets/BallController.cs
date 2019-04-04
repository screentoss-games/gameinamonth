using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	Rigidbody m_rigidBody;
	Vector3 m_direction = new Vector3(1, 1, 1);
	public float BallSpeed = 1.0f;
	// Use this for initialization
	void Start() {
		m_rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 pos = m_rigidBody.position;
		Vector3 posDelta = (new Vector3(m_direction.x, m_direction.y, 0).normalized * BallSpeed * Time.deltaTime);
		m_rigidBody.MovePosition(new Vector3(pos.x + posDelta.x, pos.y + posDelta.y, 0));
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("HERE BE DRAGONS");
		if (collision.gameObject.tag == "Level") {
			m_direction = Vector3.Reflect(m_direction, collision.contacts[0].normal);
		}
	}
}