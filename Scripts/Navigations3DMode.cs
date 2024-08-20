using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

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

    [Header("QUALITY REFFERENCES")]
    public Button highBtn;
    public Button mediumBtn;
    public Button lowBtn;

    [Header("VARIANT REFFERENCES")]
    public Button variant1Btn;
    public Button variant2Btn;
    public Material defaultVariant;
    public Material raceVariant;

    [Header("CAMERA REFFERENCES")]
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
    //public GameObject fumes;
    public List<ParticleSystem> fumes = new List<ParticleSystem>();

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackButton);
        menuBtn.onClick.AddListener(OnMenuButton);
        closeMenuBtn.onClick.AddListener(OnCloseMenuButton);
        qualityBtn.onClick.AddListener(OnQualityButton);
        variantBtn.onClick.AddListener(OnVariantButton);
        cameraBtn.onClick.AddListener(OnCameraButton);
        camera1Btn.onClick.AddListener(OnChangeCamera1);
        camera2Btn.onClick.AddListener(OnChangeCamera2);
        camera3Btn.onClick.AddListener(OnChangeCamera3);
        variant2Btn.onClick.AddListener(OnChangeVariant2);
        variant1Btn.onClick.AddListener(OnChangeVariant1);
        highBtn.onClick.AddListener(HighQuality);
        mediumBtn.onClick.AddListener(MediumQuality);
        lowBtn.onClick.AddListener(LowQuality);
    }

    void Update()
    {
        EngineBtn.onClick.AddListener(EngineTest);
    }

    public void EngineTest()
    {
        if (engineStart.isPlaying || engineIdle.isPlaying) return;

        engineStart.Play();
        Invoke("StartFumes", 1.4f);

        Invoke("EngineIdle", 2.7f);
    }

    void EngineIdle()
    {
        engineIdle.loop = true;
        engineIdle.Play();
    }

    private void StartFumes()
    {
        foreach (var fume in fumes)
        {
            fume.Play(true);
        }
    }

    private void OnBackButton()
    {
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
        if (!panelQuality.gameObject.activeInHierarchy)
        {
            panelQuality.gameObject.SetActive(true);

            panelCamera.gameObject.SetActive(false);
            panelVartiant.gameObject.SetActive(false);
        }
        else if (panelQuality.gameObject.activeInHierarchy) panelQuality.gameObject.SetActive(false);
    }

    private void HighQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

    private void MediumQuality()
    {
        QualitySettings.SetQualityLevel(1);
    }

    private void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }

    private void OnVariantButton()
    {
        if (!panelVartiant.gameObject.activeInHierarchy)
        {
            panelVartiant.gameObject.SetActive(true);

            panelQuality.gameObject.SetActive(false);
            panelCamera.gameObject.SetActive(false);
        }
        else if (panelVartiant.gameObject.activeInHierarchy) panelVartiant.gameObject.SetActive(false);
    }

    private void OnCameraButton()
    {
        if (!panelCamera.gameObject.activeInHierarchy) 
        {
            panelCamera.gameObject.SetActive(true);

            panelQuality.gameObject.SetActive(false);
            panelVartiant.gameObject.SetActive(false);
        } 
        else if (panelCamera.gameObject.activeInHierarchy) panelCamera.gameObject.SetActive(false);
    }

    private void OnChangeCamera1()
    {
        CameraMovement._tireCam.gameObject.SetActive(false);
        CameraMovement._frontCam.gameObject.SetActive(false);

        CameraMovement._mainCam.gameObject.SetActive(true);
        CameraMovement.isMainCam = true;
    }

    private void OnChangeCamera2()
    {
        CameraMovement._mainCam.gameObject.SetActive(false);
        CameraMovement._frontCam.gameObject.SetActive(false);

        CameraMovement._tireCam.gameObject.SetActive(true);
        CameraMovement.isMainCam = false;
    }

    private void OnChangeCamera3()
    {
        CameraMovement._mainCam.gameObject.SetActive(false);
        CameraMovement._tireCam.gameObject.SetActive(false);

        CameraMovement._frontCam.gameObject.SetActive(true);
        CameraMovement.isMainCam = false;
    }

    private void OnChangeVariant1()
    {
        var mat = CameraMovement._obj.transform.Find("sport_car_1_body").gameObject.GetComponent<MeshRenderer>();
        mat.materials[2].mainTexture = raceVariant.mainTexture;
    }

    private void OnChangeVariant2()
    {
        var mat = CameraMovement._obj.transform.Find("sport_car_1_body").gameObject.GetComponent<MeshRenderer>();
        mat.materials[2].mainTexture = defaultVariant.mainTexture;
    }
}
