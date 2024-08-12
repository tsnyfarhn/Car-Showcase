using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NavigationsMainMenu : MonoBehaviour
{
    [Header("List Cars")]
    public List<DataCar> cars = new List<DataCar>();

    [Header("Button")]
    public Button infoBtn;
    public Button searchBtn;
    public Button scanBtn;
    public Button closeInfoBtn;
    public Button closeSearchBtn;

    [Header("Input Field")]
    public TMP_InputField searchField;

    [Header("Image")]
    public Image aboutImg;

    [Header("List View")]
    public ScrollRect scroll;

    [Header("References")]
    public Transform panelTransform;
    public GameObject carList;

    private void Awake()
    {
        cars = LoadDatapacks.LoadImages(carList, panelTransform);
    }

    private void Start()
    {
        infoBtn.onClick.AddListener(OnInfoBtn);
        closeInfoBtn.onClick.AddListener(OnCloseInfoBtn);
        closeSearchBtn.onClick.AddListener(OnCloseSearchBtn);
        searchBtn.onClick.AddListener(OnSearchBtn);
        scanBtn.onClick.AddListener(ScanBtn);
        searchField.onValueChanged.AddListener(OnSearchFieldChanged);
    }

    public void OnInfoBtn()
    {
        infoBtn.gameObject.SetActive(false);
        scanBtn.gameObject.SetActive(false);
        searchBtn.gameObject.SetActive(false);
        searchField.gameObject.SetActive(false);
        closeSearchBtn.gameObject.SetActive(false);

        aboutImg.gameObject.SetActive(true);
        closeInfoBtn.gameObject.SetActive(true);

        foreach (var car in cars)
        {
            car.obj.SetActive(false);
        }
    }

    public void OnCloseInfoBtn()
    {
        closeInfoBtn.gameObject.SetActive(false);
        aboutImg.gameObject.SetActive(false);

        infoBtn.gameObject.SetActive(true);
        scanBtn.gameObject.SetActive(true);
        searchBtn.gameObject.SetActive(true);

        foreach (var car in cars)
        {
            car.obj.SetActive(true);
        }
    }

    public void OnCloseSearchBtn()
    {
        closeSearchBtn.gameObject.SetActive(false);
        searchField.gameObject.SetActive(false);

        searchBtn.gameObject.SetActive(true);

        foreach (var car in cars)
        {
            car.obj.SetActive(true);
        }

        var tes = scroll.viewport;
        tes.sizeDelta = new Vector2(1080f, 1293.8f);

        var tos = scroll.content.GetComponent<LayoutGroup>();
        tos.padding.top = 68;
    }

    public void OnSearchBtn() 
    {
        searchBtn.gameObject.SetActive(false);

        searchField.gameObject.SetActive(true);
        closeSearchBtn.gameObject.SetActive(true);

        var tes = scroll.viewport;
        tes.sizeDelta = new Vector2(1080f, 1093.8f);

        var tos = scroll.content.GetComponent<LayoutGroup>();
        tos.padding.top = -85;
    }
    public void ScanBtn() { Debug.Log("Ini Scan Button"); }

    public void OnSearchFieldChanged(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            foreach (var car in cars)
            {
                car.obj.SetActive(true);
            }
            return;
        }

        foreach (var car in cars)
        {
            if (car.brandName.ToLower().Contains(searchText.ToLower()) || car.seriesName.ToLower().Contains(searchText.ToLower()))
            {
                car.obj.SetActive(true);
            }
            else
            {
                car.obj.SetActive(false);
            }
        }
    }
}