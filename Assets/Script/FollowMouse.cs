using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float rotateSpeed = 2f;
    public Transform Player;
    private Vector3 lookDir;


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - Player.transform.position;

        lookDir.y = 0f;

        Player.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.LookRotation(lookDir), rotateSpeed * Time.deltaTime);
    }
}
