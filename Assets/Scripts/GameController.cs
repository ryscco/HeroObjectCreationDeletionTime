using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int maxPlanes = 10;
    private int numberOfPlanes = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if (numberOfPlanes < maxPlanes)
        {
            // CameraSupport s = Camera.main.GetComponent<CameraSupport>();

            GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            Vector3 pos;
            // pos.x = camSupp.GetWorldBound().min.x + Random.value * (camSupp.GetWorldBound().size.x * 90);
            // pos.y = camSupp.GetWorldBound().min.y + Random.value * (camSupp.GetWorldBound().size.y * 90);
            pos.z = 0;
            // enemy.transform.localPosition = pos;
            ++numberOfPlanes;
        }
    }

    public void EnemyDestroyed()
    {
        --numberOfPlanes;
    }
}