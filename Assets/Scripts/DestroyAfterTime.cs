using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    private void Awake()
    {
        Invoke(nameof(Kill), 4f);
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}