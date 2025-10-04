using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogSpawnCooldown = 0.5f; // Cooldown time for spawning dogs
    private float lastSpawnTime;// Time when the last dog was spawned

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 空格键发射小狗，有冷却时间
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastSpawnTime + dogSpawnCooldown)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastSpawnTime = Time.time;
            }
        }
    }
}
