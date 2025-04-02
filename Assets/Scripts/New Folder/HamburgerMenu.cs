using UnityEngine;
using UnityEngine.SceneManagement;

public class HamburgerMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        Debug.Log("¡Botón presionado!");
        SceneManager.LoadScene("Menu"); 
}
}
