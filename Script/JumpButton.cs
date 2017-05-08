using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour {

    public Button yourButton;
    private GameObject player;
    private Player playerScript;
    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        
        btn.onClick.AddListener(TaskOnClick);
    }

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    void TaskOnClick()
    {
        playerScript.Saltar();
        
    }
}
