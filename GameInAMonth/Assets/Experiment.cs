using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : MonoBehaviour {

    public int width = 32;
    public int height = 32;
    public float cellWidth = 4f;
    public float cellHeight = 1f;
    private List<BlockController> activeBlocks;
    public List<BlockController> differentBlocks;

    void OnDrawGizmos() {
        Vector3 pos = transform.position;
        float halfWidth = (width * cellWidth) / 2.0f;
        float halfHeight = (height * cellHeight) / 2.0f;

        Gizmos.color = Color.green;
        for (int y = 0; y < height + 1; y++) {
            float newY = (pos.y - halfHeight) + y * cellHeight;
            Gizmos.DrawLine(new Vector3(pos.x - halfWidth, newY, 0.0f),
                            new Vector3(pos.x + halfWidth, newY, 0.0f));
        }
        for (int x = 0; x < width + 1; x++) {
            float newX = (pos.x - halfWidth) + x * cellWidth;
            Gizmos.DrawLine(new Vector3(newX, pos.y - halfHeight, 0.0f),
                            new Vector3(newX, pos.y + halfHeight, 0.0f));
        }
    }
}
