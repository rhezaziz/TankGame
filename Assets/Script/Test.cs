using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool isTrue;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            coba();
        }
    }
    public void coba()
    {
        isTrue = true;

        StartCoroutine(tes());
    }

    IEnumerator tes(float timer = 5f)
    {
        while (timer >= 0 && isTrue)
        {
            yield return new WaitForSeconds(0.1f);

            timer -= 0.1f;
           // isTrue = false;
            //Debug.Log("Selesai");
            //StopCoroutine(tes());
        }
        isTrue = false;
        Debug.Log("selesai");
        StopCoroutine(tes());

    }
}
