using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManager : MonoBehaviour
{
    [Header("Spawn Paper")]
    [SerializeField] private PlaneFinderBehaviour planeFinder = null;
    [SerializeField] private GameObject paperPrefab = null;
    [SerializeField] private float forceMagnitude = 10f;

    private ScoreManager scoreManager = null;
    private Camera cam = null;
    private bool isGameStarted = false;

    private void Awake()
    {
        scoreManager = this.GetComponent<ScoreManager>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (!isGameStarted) return;

        if (Input.touches.Length <= 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            GameObject paper = Instantiate(paperPrefab,
                cam.transform.position,
                Quaternion.identity);

            Vector3 forceDir = cam.transform.forward;

            paper.GetComponent<Rigidbody>().AddForce(forceMagnitude * forceDir);
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void FindPlane(Vector2 pos)
    {
        if (isGameStarted) return;
        planeFinder.PerformHitTest(pos);
    }

    public void Score()
    {
        
    }

    public void UI_ResetScene()
    {
        SceneManager.LoadScene(1);
    }

    public void UI_PickNewImage()
    {
        SceneManager.LoadScene(0);
    }
    
    public void UI_QuitGame()
    {
        int currentHigh = PlayerPrefs.GetInt("HighScore");
        if (scoreManager.Score > currentHigh)
        {
            PlayerPrefs.SetInt("HighScore", scoreManager.Score);
            PlayerPrefs.Save();
        }
        Application.Quit();
    }
}