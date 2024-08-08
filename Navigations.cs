using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigations : MonoBehaviour
{
    public Button selectCar;

    public string name_scene;

    public void FixedUpdate()
    {
        //selectCar.onClick.AddListener(GoToDetailsScene);
    }

    public void DetailsScene()
    {
        StartCoroutine(GoToDetailsScene());
    }

    public IEnumerator GoToDetailsScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        var asyncLoad = SceneManager.LoadSceneAsync(name_scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        //SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(m_Scene));

        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
