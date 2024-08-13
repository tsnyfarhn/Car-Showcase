using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigations3DMode : MonoBehaviour
{
    [Header("OBJECT")]
    public GameObject obj;

    [Header("BUTTON REFERENCES")]
    public Button backBtn;
    public Button menuBtn;
    public Button closeMenuBtn;
    public Button EngineBtn;
    public Button qualityBtn;
    public Button variantBtn;
    public Button cameraBtn;

    [Header("QUALITY BUTTON")]
    public Button highBtn;
    public Button mediumBtn;
    public Button lowBtn;

    [Header("VARIANT BUTTON")]
    public Button variant1Btn;
    public Button variant2Btn;

    [Header("CAMERA BUTTON")]
    public Button camera1Btn;
    public Button camera2Btn;
    public Button camera3Btn;

    [Header("PANEL REFERENCES")]
    public Transform panelMenu;
    public Transform panelQuality;
    public Transform panelVartiant;
    public Transform panelCamera;

    [Header("SOUND")]
    public AudioSource engineStart;
    public AudioSource engineIdle;

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackButton);
        menuBtn.onClick.AddListener(OnMenuButton);
        closeMenuBtn.onClick.AddListener(OnCloseMenuButton);
        qualityBtn.onClick.AddListener(OnQualityButton);
        variantBtn.onClick.AddListener(OnVariantButton);
        cameraBtn.onClick.AddListener(OnCameraButton);
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

    private void OnMenuButton()
    {
        menuBtn.gameObject.SetActive(false);

        closeMenuBtn.gameObject.SetActive(true);
        panelMenu.gameObject.SetActive(true);
    }

    private void OnCloseMenuButton()
    {
        closeMenuBtn.gameObject.SetActive(false);
        panelMenu.gameObject.SetActive(false);
        panelQuality.gameObject.SetActive(false);
        panelVartiant.gameObject.SetActive(false);
        panelCamera.gameObject.SetActive(false);

        menuBtn.gameObject.SetActive(true);
    }

    private void OnQualityButton()
    {
        if (!panelQuality.gameObject.activeInHierarchy) panelQuality.gameObject.SetActive(true);
        else if (panelQuality.gameObject.activeInHierarchy) panelQuality.gameObject.SetActive(false);
    }

    private void OnVariantButton()
    {
        if (!panelVartiant.gameObject.activeInHierarchy) panelVartiant.gameObject.SetActive(true);
        else if (panelVartiant.gameObject.activeInHierarchy) panelVartiant.gameObject.SetActive(false);
    }

    private void OnCameraButton()
    {
        if (!panelCamera.gameObject.activeInHierarchy) panelCamera.gameObject.SetActive(true);
        else if (panelCamera.gameObject.activeInHierarchy) panelCamera.gameObject.SetActive(false);
    }
}
