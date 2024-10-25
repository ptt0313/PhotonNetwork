using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;
public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;
    [SerializeField] ScrollRect scrollRect;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if(inputField.text.Length <= 0) return;
            
            // inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.

            string talk = photonView.Owner.NickName + " : " + inputField.text;

            // RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk �Լ��� �����ϴ� ����� �մϴ�.
            photonView.RPC("Talk", RpcTarget.All, talk);

            // inputField�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
            inputField.text = "";

        }
    }
    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text ���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - Content�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTransform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();

        scrollRect.verticalNormalizedPosition = 0.0f;

    }
}
