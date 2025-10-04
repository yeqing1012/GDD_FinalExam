using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = 30;
    private float rightLimit = -30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // 销毁超出左侧边界的对象
        if (transform.position.x < rightLimit)
        {
            Destroy(gameObject);
        }
        // 销毁超出右侧边界的对象
        else if (transform.position.x > leftLimit)
        {
            Destroy(gameObject);
        }
        // 销毁超出底部边界的球
        else if (transform.position.y < bottomLimit)
        {
            if (gameObject.CompareTag("Ball")) // 只有球落地才销毁
            {
                Debug.Log("Game Over");
            }
            Destroy(gameObject);
        }
    }
}
