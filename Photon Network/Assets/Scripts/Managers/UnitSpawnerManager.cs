using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitSpawnerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnerPosition;

    WaitForSeconds waitForSeconds = new WaitForSeconds(5);
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
    IEnumerator Create()
    {
        while(true)
        {
            PhotonNetwork.InstantiateRoomObject("Rake", spawnerPosition.position, Quaternion.identity);

            
            yield return waitForSeconds;
        }
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
}
