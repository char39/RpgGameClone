using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Player player;

    public float sensitivity = 100f;
    public Transform playerBody;

    void Start()
    {
        playerBody = transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!GameManger.G_instance.gameover)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
