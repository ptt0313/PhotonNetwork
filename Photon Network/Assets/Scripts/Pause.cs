using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class Pause : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject pausePanel;
    public void Resume()
    {
        MouseManager.Instance.SetMouse(false);

        pausePanel.SetActive(false);
    }
    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
        }
    }
}
