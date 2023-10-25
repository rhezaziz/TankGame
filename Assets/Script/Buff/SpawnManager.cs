using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject[] buff;
    public GameObject[] bullet;
    public List<Vector3> spawnPosition;
    public List<Vector3> spawnObject;


    [SerializeField] private float timerBuff;
    [SerializeField] private float timerBullet;

    private void Awake()
    {
        instance = this;

        spawnPosition = new List<Vector3>();
        spawnObject = new List<Vector3>();
    }

    private void Start()
    {
        startCountSpawnBuff();
        startCountSpawnBullet();
    }

    public void startCountSpawnBuff()
    {
        Invoke("spawnBuff", timerBuff);
    }

    public void startCountSpawnBullet()
    {
        Invoke("spawnBullet", timerBullet);
    }
    Vector3 check(Vector3 temp)
    {
        Vector3 pos = Vector3.zero;
        while(!spawnObject.Contains(temp) && spawnObject.Count != 0)
        {
            temp = spawnPosition[Random.Range(0, spawnPosition.Count - 1)];
        }

        pos = temp;
        spawnObject.Add(pos);
        return pos;
    }

    void spawnBullet()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            if (!bullet[i].activeInHierarchy)
            {
                bullet[i].SetActive(true);
                int RandonIndex = Random.Range(0, spawnPosition.Count - 1);
                Debug.Log("Bullet "+RandonIndex);

                bullet[i].transform.position = spawnPosition[RandonIndex];
            }
        }
    }
    void spawnBuff()
    {
        int rate = Random.Range(0, (buff.Length * 3) - 1);
        int index = Mathf.Abs(rate / buff.Length);
        GameObject buffItem = buff[index];
        Debug.Log(index);
        buffItem.SetActive(true);
        int RandonIndex = Random.Range(0, spawnPosition.Count - 1);
        Debug.Log("Buff "+RandonIndex);
        buffItem.transform.position = spawnPosition[RandonIndex];
    }
}
