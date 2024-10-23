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
        // nickName�� inputField�� �Է��� ���� �����մϴ�.
        // PhotonNetwork.NickName�� nickName ���� �����մϴ�.
        // NickName�� PlayerPrefs�� �����մϴ�.
        // ��Ȱ��ȭ�մϴ�.
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
