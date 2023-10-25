using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IReceiveHit
{
    // Start is called before the first frame update

    [SerializeField] private float HealthTower;

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
