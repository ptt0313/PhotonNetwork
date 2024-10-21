using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
    }
    private void Start()
    {
        DisablecCamera();
    }
    void Update()
    {
        move.Movement();
        rotation.RotateY();
        rotation.RotateX();

    }
    public void DisablecCamera()
    {
         // 현재 플레이어가 나 자신이라면
         if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
         else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
