using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;

    public float columnMin = -2.9f;
    public float columnMax = 1.4f;
    private float spawnXPosition = 10f;

    private Vector2 objectPoolPosition=new Vector2 (-14,0);
    private GameObject[] columns;

    private float timeSinceLastSpawned;
    public float spawnRate;

    private int currentColumn;


    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
        SpawnColumn();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameController.instance.gameover==false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            //aqi se daran los valores maximos y
            //minimos en (y) para que las columnas
            //spawneen, y la distancia en x que queremos
            //para que la columna spawnee, obviamente
            //fuera de la camara, para que el jugador no
            //vea la aparicion de la columna

            // aqui se llama al metodo SpawnColumn
            SpawnColumn();
        }
    }

    private void SpawnColumn()
    {
        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
        }
    }
}
