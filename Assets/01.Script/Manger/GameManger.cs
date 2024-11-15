using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger G_instance;

    /// <summary>
    /// º¯¼ö
    /// </summary>
    public bool gameover = false;
    private void Awake()
    {
        if(G_instance == null)
        {
            G_instance = this;
        }
        else if(G_instance != null) 
        {
            Destroy(G_instance);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
