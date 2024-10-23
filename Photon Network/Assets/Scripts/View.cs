using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class View : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickName;
    private void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }
    void Update()
    {
        nickName.gameObject.transform.rotation = Camera.main.transform.rotation;
    }
}
