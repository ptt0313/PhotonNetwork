using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;


    public void SetName()
    {
        // nickName에 inputField로 입력한 값을 저장합니다.
        // PhotonNetwork.NickName에 nickName 값을 저장합니다.
        // NickName을 PlayerPrefs에 저장합니다.
        // 비활성화합니다.
        nickName = inputField.text;

        PhotonNetwork.NickName = nickName;

        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);
        
        gameObject.SetActive(false);
    }
    void Update()
    {
        if(inputField.text.Length <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
