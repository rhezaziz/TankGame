using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;

    public GameObject partikel;


    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<IReceiveHit>() != null){
            IReceiveHit hit = other.GetComponent<IReceiveHit>();
            partikel.SetActive(true);
            partikel.transform.localTransform = Vector3.zero;
            hit.Damage(damage);
        }
    }
}