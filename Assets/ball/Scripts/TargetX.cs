using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManagerX gameManagerX;
    public int pointValue;
    public GameObject explosionFx;

    public float timeOnScreen = 1.0f;

    private float minValueX = -3.75f;
    private float minValueY = -3.75f;
    private float spaceBetweenSquares = 2.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition(); 
        StartCoroutine(RemoveObjectRoutine()); // 时间到自动触发移动
    }

    // 点击才触发
    private void OnMouseDown()
    {
        if (gameManagerX.isGameActive)
        {
            // 更新分数
            gameManagerX.UpdateScore(pointValue);

            // 生成爆炸特效
            if (explosionFx != null)
                Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);

            // 销毁目标
            Destroy(gameObject);
        }
    }

    // 随机生成位置
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // 碰到 Sensor 触发游戏结束（非 Bad 目标）
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            if (gameManagerX != null)
                gameManagerX.GameOver(false);
        }

        // 不管是否 Bad，触碰后销毁
        Destroy(gameObject);
    }

    // 时间到自动移动目标到前面（让它碰到 Sensor）
    IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        if (gameManagerX != null && gameManagerX.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }
    }
}
