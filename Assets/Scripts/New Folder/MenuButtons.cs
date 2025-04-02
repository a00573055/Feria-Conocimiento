using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject pausePanel; 

    public void PauseGame()
    {
        Debug.Log("Juego pausado");
        Time.timeScale = 0f;
        pausePanel.SetActive(true); 
    }

    public void ResumeGame()
    {
        Debug.Log("Juego reanudado");
        Time.timeScale = 1f;
        pausePanel.SetActive(false); 
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Map");
    }
}
