using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalJuego : MonoBehaviour
{
    public GameObject interfazFinal;  
    public TextMeshProUGUI resultado;  
    public Button boton;
    public bool listo = false;
    LogicLevel1 logica;
    

    void Start()
    {
        logica = FindAnyObjectByType<LogicLevel1>();
        boton.onClick.AddListener(RegresarMenu);
    }

    void Update()
    {
        if (listo)
        {
            resultado.text = "Respondiste " + logica.GetAciertos() +  " preguntas correctamente. Vidas Restantes: " + logica.GetVidas();
        }
    }

    void RegresarMenu()
    {
        SceneManager.LoadScene("prueba");
    }
}
