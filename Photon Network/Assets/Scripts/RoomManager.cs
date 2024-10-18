using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Unity.VisualScripting;

public class RoomManager : MonoBehaviourPunCallbacks
{
    //[SerializeField] Button roomCreateButton;
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;

    private Dictionary<string,RoomInfo> dictionary = new Dictionary<string,RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }
    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // �� ����

        // �� ������Ʈ

        // �� ����
        InstantiateRoom();
    }

    public void InstantiateRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            //1. room ������Ʈ �����մϴ�.
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));
            //2. room ������Ʈ�� ��ġ���� �����մϴ�.
            room.transform.SetParent(contentTransform);
            // 3. room ������Ʈ �ȿ� �ִ� Text �Ӽ��� �����մϴ�.
            room.GetComponent<Information>().SetData
                (
                    roomInfo.Name,
                    roomInfo.PlayerCount,
                    roomInfo.MaxPlayers
                );
        }
    }
    public void UpdateRoom()
    {

    }
    public void RemoveRoom()
    {

    }
}
