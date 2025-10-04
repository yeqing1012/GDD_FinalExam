using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // 狗与球的碰撞
        if (gameObject.CompareTag("Dog") && other.CompareTag("Ball"))
        {
            Destroy(other.gameObject); // 销毁球
            Destroy(gameObject); // 销毁狗
        }
        // 球与地面的碰撞
        else if (gameObject.CompareTag("Ball") && other.CompareTag("Ground"))
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
