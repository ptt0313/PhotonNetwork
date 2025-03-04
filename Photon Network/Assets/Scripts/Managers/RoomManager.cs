using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;

    private Dictionary<string,GameObject> dictionary = new Dictionary<string,GameObject>();

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
        GameObject temporaryRoom;

        foreach(RoomInfo room in roomList)
        {
            // 룸이 삭제된 경우
            if(room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out temporaryRoom);
                Destroy(temporaryRoom);
                dictionary.Remove(room.Name);
            }
            // 룸이 업데이트된 경우
            else
            {
                // 룸이 처음 생성되는 경우
                if(dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject roomObject = Instantiate(Resources.Load<GameObject>("Room"), contentTransform);

                    roomObject.GetComponent<Information>().SetData(room.Name,room.PlayerCount,room.MaxPlayers);

                    dictionary.Add(room.Name, roomObject);
                }
                // 룸의 정보가 변경된 경우
                else
                {
                    dictionary.TryGetValue(room.Name, out temporaryRoom);

                    temporaryRoom.GetComponent<Information>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);
                }
            }
        }
    }

}
