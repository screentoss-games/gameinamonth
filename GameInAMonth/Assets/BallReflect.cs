using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReflect : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ball") {
			BallController ball = collision.gameObject.GetComponent<BallController>();
			ball.m_direction = Vector3.Reflect(ball.m_direction, collision.contacts[0].normal);
		}
	}
}