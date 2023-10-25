using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_InputField textField;

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(textField.text);

    }

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(textField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
