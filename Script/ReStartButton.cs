using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReStartButton : MonoBehaviour {
    public Button yourButton;
    private GameObject gameControllerZ;
    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
        SceneManager.LoadScene("MainScene");
    }
}
