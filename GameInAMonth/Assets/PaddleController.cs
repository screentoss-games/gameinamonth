using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	float m_xDir;
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		m_xDir = Input.GetAxis("Horizontal");
		Vector3 pos = transform.position;

		transform.position = new Vector3(pos.x + m_xDir, pos.y, pos.z);
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ball") {
			Debug.Log("HERE BE DRAGONS");
			BallController controller = collision.gameObject.GetComponent<BallController>();
			controller.m_direction = new Vector3(controller.m_direction.x + m_xDir, controller.m_direction.y, 0);
		}
	}
}