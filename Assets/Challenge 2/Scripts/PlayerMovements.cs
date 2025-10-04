using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 20f;
    public float zRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ƶ����
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // �����ƶ���Χ
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, -zRange, zRange);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
