using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public AudioSource engineGas;

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
}
