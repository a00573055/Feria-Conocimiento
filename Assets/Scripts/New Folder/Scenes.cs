using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
 
        private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            string tagDelNivel = this.tag;
            Debug.Log("Colisión detectada con: " + tagDelNivel);

            if (SceneExists(tagDelNivel))
            {
                Debug.Log("Escena encontrada. Cargando...");
                SceneManager.LoadScene(tagDelNivel);
            }
            else
            {
                Debug.LogWarning("No se encontró ninguna escena llamada: " + tagDelNivel);
            }
        }
    }


    private bool SceneExists(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
                return true;
        }
        return false;
    }
}
