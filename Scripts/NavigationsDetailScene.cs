using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationsDetailScene : MonoBehaviour
{
    [Header("Button")]
    public Button backBtn;
    public Button modeBtn;

    [Header("Image")]
    public Image descriptionImg;
    public Image picturCarImg;

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackButton);
        modeBtn.onClick.AddListener(On3DModeButton);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("Menu Scene", LoadSceneMode.Single);
    }   

    public void On3DModeButton()
    {
        SceneManager.LoadScene("3D Mode Scene", LoadSceneMode.Single);
    }
}
