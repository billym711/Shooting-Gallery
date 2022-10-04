using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeCreator : MonoBehaviour
{

    [SerializeField]
    protected Camera cam;
    
    protected List<Transform> cubeList = new List<Transform>();
    [SerializeField] 
    Transform cubePrefab;

    [SerializeField] 
    GameObject scoreLabel;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            Transform cubeInstance = (Instantiate(cubePrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity));

            cubeList.Add(cubeInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);

            RaycastHit rch;
            if (Physics.Raycast(ray, out rch))
            {
                cubeList.Remove(rch.transform);
                Destroy(rch.transform.gameObject);
                Transform cubeInstance = (Instantiate(cubePrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity));
                cubeList.Add(cubeInstance);
                score += 10;
                scoreLabel.GetComponent<TextMeshProUGUI>().text = "Score: " + score;

            }
        }
    }
}
