using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

//PARA ACCEDER A LA INFO LLAMAR COMO GlobalInfo.Instance.[jugador, sesion, respuestasJugador].[propiedad]
public class Sesion 
{
    public int juegosCompletados = 0;
    public int monedaGanadas = 0;
}

public class RespuestaJugador
{
    public int nivel;
    public int correctas;
    
}

public class Jugador
{
    public int idJugador;
    public string numeroLista;
    public string Grupo;
    public string Genero;
}

public class GlobalInfo : MonoBehaviour
{
    public static GlobalInfo Instance { get; private set; }
    public Jugador jugador = new Jugador();
    public Sesion sesion = new Sesion();
    public List<RespuestaJugador> respuestasJugador = new List<RespuestaJugador>();
    
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
