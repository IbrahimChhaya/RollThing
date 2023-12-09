using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject extendedPlatform;
    public GameObject extendedPlatform2;
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;

    // Start is called before the first frame update
    void Start()
    {
        
        //gameOver = false;
        extendedPlatform.SetActive(true);
        extendedPlatform2.SetActive(true);
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 10; i++)
        {
            SpawnPlatforms();
        }  
    }

    public void StartSpawing()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.instance.gameOver == true)
            CancelInvoke("SpawnPlatforms");
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnZ();
        }
        else
            SpawnX();
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}
