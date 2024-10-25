using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rifle : MonoBehaviourPunCallbacks
{
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit raycastHit;
    [SerializeField] Camera remoteCamera;
    [SerializeField] LayerMask layerMask;
    void Start()
    {
        
    }

    void Update()
    {
        if(photonView.IsMine == false) { return; }
        if(Input.GetMouseButtonDown(0))
        {
            ray = remoteCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out raycastHit,Mathf.Infinity,layerMask))
            {
                PhotonView photonView = raycastHit.collider.GetComponent<PhotonView>();

                if (photonView.IsMine)
                {
                    photonView.GetComponent<Rake>().Die();
                }
            }
        }
    }
}
