using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarListReferences : MonoBehaviour
{
    [Header("References")]
    public Image pictureCar;
    public TMP_Text brandName;
    public TMP_Text seriesName;
    public Button selectBtn;

    private void Start()
    {
        selectBtn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene("Detail Scene", LoadSceneMode.Single);
    }
}
