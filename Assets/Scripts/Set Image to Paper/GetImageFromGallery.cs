using System;
using UnityEngine;

public class GetImageFromGallery : Singleton<GetImageFromGallery>
{
    [HideInInspector] public bool imageObtained = false; 
    [HideInInspector] public Texture2D imageFromGallery = null;
    private const int MAX_SIZE = 512;
    
    #region Singleton Events

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    #endregion

    public void GetImage()
    {
        NativeGallery.Permission permission =
            NativeGallery.GetImageFromGallery((path) =>
            {
                if (path == null)
                {
                    return;
                }

                // Create Texture from selected image
                imageFromGallery = NativeGallery.LoadImageAtPath(path, MAX_SIZE);
                if (imageFromGallery == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                }

                imageObtained = true;
            }, "Select a PNG image", "image/png");
    }
}
