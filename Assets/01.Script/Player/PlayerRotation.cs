using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float sensitivity = 100f; // 마우스 감도
    public Transform playerBody; // 플레이어 본체를 참조하기 위한 변수
    PlayerHP playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
        playerBody = transform;
        Cursor.lockState = CursorLockMode.Locked; // 커서를 잠가서 보이지 않게 함
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManger.G_instance.gameover)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // 마우스 X축 입력

            // y축 회전만 적용
            playerBody.Rotate(Vector3.up * mouseX); // 본체를 y축으로 회전
        }
       
    }
}
