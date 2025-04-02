using UnityEngine;

public class DontDestroyMenu : MonoBehaviour
{
    private void Awake()
    {
        if (Object.FindObjectsByType<DontDestroyMenu>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
