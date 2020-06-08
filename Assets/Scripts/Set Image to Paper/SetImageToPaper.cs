using UnityEngine;

public class SetImageToPaper : MonoBehaviour
{
    [SerializeField] private Renderer paperRenderer = null;
    
    private WaitForSeconds wait = new WaitForSeconds(1f);

    private void Awake()
    {
        SetImage();
    }

    private void SetImage()
    {
        if (GetImageFromGallery.Instance.imageObtained == false)
        {
            throw new System.Exception("Image error");
        }

        paperRenderer.material.mainTexture = 
            GetImageFromGallery.Instance.imageFromGallery;
        
    }
}