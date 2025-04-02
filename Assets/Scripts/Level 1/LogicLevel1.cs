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
    Preguntas p;
    //this does belong in this part
    public TextMeshPro holderPregunta;
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
        if (questionCount == 5)
            return;
        questionPointer = randomQuestions[questionCount];

        holderPregunta.text = p.preguntas[questionPointer];

        string[] respuestas = new string[5];
        int indexRespuesta = p.posicionRespuetas[questionPointer];
        for (int i = 0; i < 5; i++) {
            respuestas[i] = p.respuestas[indexRespuesta];
            indexRespuesta++;
        }

        questionCount++;

        chicken.SpawnChickens(respuestas);
    }

    void Selector()
    {

    }

    void Start()
    {
        //this should be done globally
        p = JsonUtility.FromJson<Preguntas>(json);
        //this do goes here
        chicken = FindAnyObjectByType<ChickenSpawner>();
        randomQuestions = GetRandomQuestions();
        ShowQuestion();
    }

    void Update()
    {
        if (vidas < 0)
        {
            Debug.Log("Fin del juego");
        }

    }
}
