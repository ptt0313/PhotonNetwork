using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Canvas lobbyCanvas;
    [SerializeField] Canvas roomCanvas;
    [SerializeField] Dropdown dropdown;
    [SerializeField] GameObject nickNamePanel;
    private void Awake()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        Debug.Log(PhotonNetwork.NickName);

        if(string.IsNullOrEmpty(PlayerPrefs.GetString("NickName")))
        {
            nickNamePanel.SetActive(true);
        }
        if(PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        // ������ �����ϴ� �Լ�
        PhotonNetwork.ConnectUsingSettings();

        lobbyCanvas.gameObject.SetActive(false);
    }
    public override void OnJoinedLobby()
    {
        roomCanvas.gameObject.SetActive(true);
    }
    public override void OnConnectedToMaster()
    {
        // JoinLobby : Ư�� �κ� �����Ͽ� �����ϴ� �Լ�
        PhotonNetwork.JoinLobby
        (
         new TypedLobby(dropdown.options[dropdown.value].text, LobbyType.Default)   
            
        );
    }
}
