using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject chickenPrefab;
    private List<GameObject> spawnedChickens = new List<GameObject>();
    private List<GameObject> spawnedTexts = new List<GameObject>();

    
    Vector3[] ChickenPos() {
        Vector3[] positions = new Vector3[5];
    
        for (int i = 0; i < 5; i++) {
            bool positionValid;            
            do {
                positionValid = true;
                Vector3 newPos = new Vector3(Random.Range(-2.25f, 2.25f), 0.16f, Random.Range(1.3f, 3.3f));
                
                for (int j = 0; j < i; j++) 
                    if (Vector3.Distance(newPos, positions[j]) < 0.8f) {
                        positionValid = false;
                        break;
                    }
                
                if (positionValid) 
                    positions[i] = newPos;
                
            } while (!positionValid);
        }
    
        return positions;
    }

    public void SpawnChickens(string[] ans) {
        GameObject c;
        Vector3[] pos = ChickenPos();
        for (int i = 0; i < 5; i++)
        {
            c = Instantiate(chickenPrefab);
            c.transform.position = pos[i];
            c.transform.localScale = new Vector3(2,2,2);
            spawnedChickens.Add(c);
            TextMesh tm = c.AddComponent<TextMesh>();
            tm.text = ans[i];
            tm.GetComponent<Renderer>().enabled = false;

            GameObject textObject = new GameObject();
            spawnedTexts.Add(textObject);
            textObject.transform.position = c.transform.position;
            TextMesh textMesh = textObject.AddComponent<TextMesh>();
            textMesh.text = ans[i];
            textMesh.characterSize = 0.1f;
            textMesh.fontSize = 40;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;
            textMesh.transform.Rotate(0,180,0);
        }     
    }

    public void CleanupChickens()
    {
        foreach (GameObject chicken in spawnedChickens)
        {
            Destroy(chicken);
        }
        spawnedChickens.Clear();
        
        foreach (GameObject text in spawnedTexts)
        {
            Destroy(text);
        }
        spawnedTexts.Clear();
    }
}
