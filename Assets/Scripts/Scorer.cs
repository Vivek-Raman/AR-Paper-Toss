using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Paper")) return;

        scoreManager.AddScore();
    }
}