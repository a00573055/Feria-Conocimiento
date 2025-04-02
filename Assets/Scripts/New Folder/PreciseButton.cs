using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PreciseButton : MonoBehaviour
{
    private void Awake()
    {
        Image img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.5f; 
    }
}
