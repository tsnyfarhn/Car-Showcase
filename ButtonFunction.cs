using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    [Header("OBJECT")]
    public GameObject obj;

    [Header("REFERENCES")]
    public Button backBtn;
    public Button homeBtn;
    public Button EngineBtn;

    [Header("SOUND")]
    public AudioSource engineStart;
    public AudioSource engineIdle;

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackButton);
    }

    void Update()
    {
        EngineBtn.onClick.AddListener(EngineTest);
    }

    public void EngineTest()
    {
        if (engineStart.isPlaying || engineIdle.isPlaying) return;

        engineStart.Play();

        Invoke("EngineIdle", 2.7f);
    }

    void EngineIdle()
    {
        engineIdle.loop = true;
        engineIdle.Play();
    }

    private void OnBackButton()
    {
        Debug.Log("Balik ke scene sebelumnya");

        SceneManager.LoadScene("Detail Scene", LoadSceneMode.Single);
    }
}
