using UnityEngine;
using System.Collections.Generic;
using TMPro;
[RequireComponent(typeof(MeshCollider))]

public class Preguntas
{
    public string[] preguntas;
    public string[] respuestas;
    public int[] posicionRespuetas;
    public string[] retro;
}

public class LogicLevel1 : MonoBehaviour
{
    //This should be done globally
    string json = "{ \"preguntas\": [\"25x5\", \"76x6\", \"34x2\", \"66x5\", \"81x7\", \"35x9\", \"28x8\", \"93x3\", \"44x8\", \"35x6\", \"72x3\", \"62x2\", \"80x9\", \"29x5\", \"56x4\"], \"respuestas\": [\"125\", \"130\", \"140\", \"120\", \"135\", \"456\", \"460\", \"470\", \"450\", \"480\", \"68\", \"66\", \"72\", \"64\", \"70\", \"330\", \"325\", \"335\", \"340\", \"320\", \"567\", \"570\", \"560\", \"550\", \"580\", \"315\", \"320\", \"310\", \"305\", \"325\", \"224\", \"220\", \"230\", \"240\", \"210\", \"279\", \"280\", \"275\", \"270\", \"285\", \"352\", \"360\", \"340\", \"345\", \"355\", \"210\", \"215\", \"205\", \"200\", \"220\", \"216\", \"220\", \"210\", \"230\", \"225\", \"124\", \"120\", \"130\", \"128\", \"126\", \"720\", \"725\", \"715\", \"710\", \"730\", \"145\", \"150\", \"140\", \"135\", \"155\", \"224\", \"220\", \"230\", \"240\", \"210\"], \"posicionRespuetas\": [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70], \"retro\": [\"Sigue Practicando\", \"Buen Intento\", \"Casi lo logras\", \"Intentalo otra vez\", \"Sigue así!\"] }";
    //this does belong in this part
    Preguntas p;
    bool listo = false;
    public TextMeshPro holderPregunta;
    public TextMeshPro retroalimentacion;
    ChickenSpawner chicken;
    int aciertos = 0;
    int vidas = 3;
    List<int> randomQuestions;
    int questionPointer = 0;
    int questionCount = 0;
    
    List<int> GetRandomQuestions()
    {
        int i = 0;
        List<int> randomQuestions = new List<int>();
        while (i < 5)
        {
            int question = Random.Range(0,14);
            if (!randomQuestions.Contains(question))
            {
                randomQuestions.Add(question);
                i++;
            }
        }
        return randomQuestions;
    }

    void ShowQuestion()
    {
        if (questionCount > 5)
            return;
        questionPointer = randomQuestions[questionCount];

        holderPregunta.text = p.preguntas[questionPointer];

        string[] respuestas = new string[5];
        int indexRespuesta = p.posicionRespuetas[questionPointer];
        for (int i = 0; i < 5; i++) {
            respuestas[i] = p.respuestas[indexRespuesta];
            indexRespuesta++;
        }

        chicken.SpawnChickens(respuestas);
    }

    void Selector()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 2f);
            RaycastHit hit;
            Debug.Log("MouseInputWasDetected");
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log(clickedObject);
                TextMesh tm = clickedObject.GetComponent<TextMesh>();
                if (tm != null)
                {
                    string respuesta = tm.text;
                    string respuestaCorrecta = p.respuestas[p.posicionRespuetas[questionPointer]];
                    if (respuesta == respuestaCorrecta)
                    {
                        aciertos++;
                        Debug.Log("Respuesta Correcta");
                        chicken.CleanupChickens();
                        questionCount++;
                        Debug.Log("added to question count now = " + questionCount); // <--
                        if (questionCount < 5)
                            ShowQuestion();
                        retroalimentacion.text = "¡Correcto!";
                    } else {
                        vidas--;
                        if (vidas == 0) chicken.CleanupChickens();
                        Debug.Log("Respuesta Incorrecta");
                        retroalimentacion.text = p.retro[questionCount];
                    }
                }
            }
        }
    }

    public void iniciar()
    {
        listo = true;
        ShowQuestion();
    }

    void Start()
    {
        p = JsonUtility.FromJson<Preguntas>(json);
        chicken = FindAnyObjectByType<ChickenSpawner>();
        randomQuestions = GetRandomQuestions();
    }

    void Update()
    {
        //Debug.Log("vidas " + vidas);
        //Debug.Log("pointer " + questionCount);
        //ebug.Log("rady " + listo);
        if (vidas > 0 && questionCount < 5 && listo)
        {
            Selector();
        }
        

    }
}
