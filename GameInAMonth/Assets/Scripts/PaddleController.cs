using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    // Use this for initialization
    float m_xDir;
    private BallController ballController;
    private bool holdingBall = true;
    //Wanna do movement as a spline that restricts movement
    public float MIN_X;
    public float MAX_X;
    void Start() {
        ballController = GetComponentInChildren<BallController>();
    }

    // Update is called once per frame
    void Update() {
        m_xDir = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + m_xDir, pos.y, pos.z);
        if (holdingBall && Input.GetKeyDown(KeyCode.Space)) {
            ballController.Fire();
            holdingBall = false;
        }
        float x = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            BallController controller = collision.gameObject.GetComponent<BallController>();
            Rigidbody ballRb = controller.GetComponent<Rigidbody>();
            ballRb.velocity = new Vector3(ballRb.velocity.x + m_xDir, ballRb.velocity.y, 0);

            controller.m_direction = new Vector3(controller.m_direction.x + m_xDir, controller.m_direction.y, 0);
        }
    }
}