using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneAfterImageRetrieved : MonoBehaviour
{
    WaitForSeconds stall = new WaitForSeconds(1f);
    private int checker = 0;

    private void Awake()
    {
        GetImageFromGallery.Instance.GetImage();
        StartCoroutine(StartARScene());
    }
    
    private IEnumerator StartARScene()
    {
        while (GetImageFromGallery.Instance.imageObtained == false)
        {
            if (checker > 120f)
            {
                throw new System.Exception("Took too long");
            }
            checker++;
            yield return stall;
        }
        SceneManager.LoadScene(1);
    }
}