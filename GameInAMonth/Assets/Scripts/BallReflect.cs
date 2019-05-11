using UnityEngine;

public class BallReflect : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            BallController ball = collision.gameObject.GetComponent<BallController>();
            Vector3 faceNormal = Vector3.zero;
            RaycastHit hitInfo;
            if (!ball.alreadyReflected && Physics.Raycast(ball.transform.position, ball.m_direction, out hitInfo)) {
                if (Vector3.Dot(ball.m_direction, hitInfo.normal) < 0) {
                    ball.m_direction = Vector3.Reflect(ball.m_direction, hitInfo.normal);
                    ball.alreadyReflected = true;
                }
            }
        }
    }
}