using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    int[,] stageData = new int[,]
    {
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
    };

    [SerializeField]
    GameObject block, block_flow;

    [SerializeField]
    Vector2 offset;

    void Start()
    {
        CreateStage();
    }

    void CreateStage()
    {
        for (int h = 0; h < stageData.GetLength(0); ++h)
        {
            for (int w = 0; w < stageData.GetLength(1); ++w)
            {
                if (stageData[h, w] == 1)
                {
                    Instantiate(block, new Vector2((w - offset.x) * 2, (-h + offset.y) * 2), Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {

    }
}
