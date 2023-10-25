using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] buff;
    public GameObject[] bullet;
    public GameObject[] spawnPosition;

    [SerializeField] private float timerBuff;
    [SerializeField] private float timerBullet;


    private void Start()
    {
        spawnBuff();
    }

    public void startCountSpawnBuff()
    {
        Invoke("spawnBuff", timerBuff);
    }


    void spawnBuff()
    {
        int rate = Random.Range(0, (buff.Length * 3) - 1);
        int index = Mathf.Abs(rate / buff.Length);
        GameObject buffItem = buff[index];
        Debug.Log(index);
        buffItem.SetActive(true);
        buffItem.transform.position = new Vector3Int(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
