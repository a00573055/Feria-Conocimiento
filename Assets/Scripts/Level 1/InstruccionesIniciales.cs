using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel;  
    public TextMeshProUGUI instrucciones;  
    public Button boton;
    LogicLevel1 logica;

    void Start()
    {
        
        instrucciones.text = "Selecciona el resultado de la multiplicación que se muestra en el tablero. ¡Buena suerte!";
        panel.SetActive(true);
        logica = FindAnyObjectByType<LogicLevel1>();
        boton.onClick.AddListener(EsconderInstrucciones);
    }

    void EsconderInstrucciones()
    {
        panel.SetActive(false);
        logica.iniciar();
    }
}
