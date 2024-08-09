using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadDatapacks : MonoBehaviour
{
    [Header("References")]
    public Transform panelTransform;
    public GameObject carList;

    void Start()
    {
        LoadImages();
    }

    public void LoadImages()
    {
        var imageDir = @"Datapack/Images";
        var formatFiles = ".png";

        var imageFiles = Directory.GetFiles(imageDir, "*.*").Where(file => formatFiles.Contains(Path.GetExtension(file))).ToArray();

        var bName = new List<string>();
        var sName = new List<string>();

        for (int j = 0; j < imageFiles.Length; j++)
        {
            var filePath = imageFiles[j];
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var nameIndex = fileName.IndexOf("_");
            if (nameIndex > 0)
            {
                bName.Add(fileName.Substring(0, nameIndex));
                sName.Add(fileName.Substring(nameIndex + 1));
            }

            if (File.Exists(filePath))
            {
                byte[] imageData = File.ReadAllBytes(filePath);

                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageData);

                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                var instance = Instantiate(carList, panelTransform);
                var carListReferences = instance.GetComponent<CarListReferences>();

                carListReferences.pictureCar.sprite = newSprite;
                carListReferences.brandName.text = bName[j];
                carListReferences.seriesName.text = sName[j];

                carListReferences.pictureCar.gameObject.SetActive(true);
                carListReferences.pictureCar.type = Image.Type.Filled;
                carListReferences.pictureCar.preserveAspect = true;

                var tes = new DataCar()
                {
                    obj = instance.gameObject,
                    image = newSprite,
                    brandName = bName[j],
                    seriesName = sName[j]
                };

                NavigationsMainMenu._cars.Add(tes);
            }
            else
            {
                Debug.LogError("Image file not found at path: " + filePath);
            }
        }
    }
}
