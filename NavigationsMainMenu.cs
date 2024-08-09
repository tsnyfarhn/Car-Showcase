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

    [Header("References")]
    public Button selectCar;
    public Button infoBtn;
    public Button searchBtn;
    public Button scanBtn;
    public Button closeBtn;
    public TMP_InputField searchField;

    public static List<DataCar> _cars = new List<DataCar>();

    private void Start()
    {
        infoBtn.onClick.AddListener(OnInfoBtn);
        closeBtn.onClick.AddListener(OnCloseBtn);
        searchBtn.onClick.AddListener(OnSearchBtn);
        scanBtn.onClick.AddListener(ScanBtn);
        searchField.onValueChanged.AddListener(OnSearchFieldChanged);

        cars = _cars;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            foreach (var car in cars)
            {
                car.obj.SetActive(true);
            }

            searchField.gameObject.SetActive(false);
        }
    }

    public void OnInfoBtn()
    {
        infoBtn.gameObject.SetActive(false);
        scanBtn.gameObject.SetActive(false);

        closeBtn.gameObject.SetActive(true);
    }

    public void OnCloseBtn()
    {
        closeBtn.gameObject.SetActive(false);

        infoBtn.gameObject.SetActive(true);
        scanBtn.gameObject.SetActive(true);
    }

    public void OnSearchBtn() 
    {
        searchField.gameObject.SetActive(true);
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

[System.Serializable]
public class DataCar
{
    public GameObject obj;
    public Sprite image;
    public string brandName;
    public string seriesName;
}