using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float sensitivity = 100f; // ���콺 ����
    public Transform playerBody; // �÷��̾� ��ü�� �����ϱ� ���� ����
    PlayerHP playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
        playerBody = transform;
        Cursor.lockState = CursorLockMode.Locked; // Ŀ���� �ᰡ�� ������ �ʰ� ��
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManger.G_instance.gameover)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // ���콺 X�� �Է�

            // y�� ȸ���� ����
            playerBody.Rotate(Vector3.up * mouseX); // ��ü�� y������ ȸ��
        }
       
    }
}
