using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2;
    public int enemyCount = 20;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemy2, transform.position, Quaternion.identity);
        }

    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject enemyPrefab;
//    public int enemyMax;
//    // Start is called before the first frame update
//    void Start()
//    {
//        for (int i = 0; i < enemyMax; i++)
//        {
//            GameObject enemy = Instantiate(enemyPrefab);
//        }
//    }
//}
