using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IReceiveHit
{
    // Start is called before the first frame update

    public bool isBreak;

    [SerializeField] private float HealthWall;

    public float currentHealth;


    public void Damage(float damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    void breakWall()
    {

    }


    void getDamage(float damage)
    {
        
    }

    private void OnEnable()
    {
        currentHealth = HealthWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
