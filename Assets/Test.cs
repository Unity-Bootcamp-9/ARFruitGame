using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject blueberry;
    [SerializeField] GameObject strawberry;
    [SerializeField] int count = 1000; // 积己且 喉风海府 俺荐

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randombluePosition = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            Vector3 randomstrawPosition = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            Instantiate(blueberry, randombluePosition, Quaternion.identity);
            Instantiate(strawberry, randomstrawPosition, Quaternion.identity);
        }
    }
}
