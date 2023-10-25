using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IReceiveHit
{
    // Start is called before the first frame update

    [SerializeField] private float HealthTower;

    public GameObject gameOver;
    public float currentHealth;
    public GameObject particel;

    public void Damage(float damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameOver();
            gameObject.SetActive(false);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        gameOver = GameObject.Find("GameOver").transform.GetChild(0).gameObject;
        gameOver.SetActive(true);
    }
    
    private void OnEnable()
    {
        currentHealth = HealthTower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
