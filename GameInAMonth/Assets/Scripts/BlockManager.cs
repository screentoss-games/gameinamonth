using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public int width = 10;
    public int height = 5;
    private List<BlockController> activeBlocks = new List<BlockController>();
    // Use this for initialization
    void Start() {
        //read a file format which will instantiate and setupblocks in correct pattern
        //Fetch/Instantiate a block, set it up according to specifications
        init();
    }

    private void init() {
        int blockHeight = 1;
        int blockWidth = blockHeight * 4;
        float halfWidth = width / 2.0f;
        float halfHeight = height / 2.0f;

        Vector3 middle = this.transform.position;

        for (int i = 0; i < width * height; i++) {
            GameObject block = ObjectPooler.instance.getPoolObject("Block");

            int x = i % (int)width;
            int y = i / (int)width;

            float newX = (-halfWidth * blockWidth) + (blockWidth * x) + (blockWidth / 2.0f);
            float newY = (-halfHeight * blockHeight) + (blockHeight * y) + (blockHeight / 2.0f);
            Vector3 pos = new Vector3(middle.x + newX, middle.y + newY, 0);
            block.transform.position = pos;
            BlockController controller = block.GetComponent<BlockController>();
            controller.OnBlockDestroyed.AddListener(RemoveBlockAndCheckWin);
            activeBlocks.Add(block.GetComponent<BlockController>());
        }
    }

    private void RemoveBlockAndCheckWin(BlockController block) {
        activeBlocks.Remove(block);
        if(activeBlocks.Count == 0) {
            EventManager.TriggerEvent(EventType.ALL_BLOCKS_DESTROYED);
        }
    }
}