using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    public GameObject partikel;

    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<IReceiveHit>() != null){
            IReceiveHit hit = other.GetComponent<IReceiveHit>();
            //partikel.SetActive(true);
            //partikel.transform.localPosition = Vector3.zero;
            partikel.SetActive(true);
            //.MainModule mainModule = partikel.main;
            //Destroy(partikel.gameObject, mainModule.duration);
            //Destroy(partikel, 0.1f);
            hit.Damage(damage);
            Destroy(gameObject, 0.1f);
            
        }
    }
}