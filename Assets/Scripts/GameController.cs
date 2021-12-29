using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public bool gameover;
    public float scrollSpeed=-1.5f;
    //esta es una variable para el single too
    public static GameController instance;

    private int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else if(GameController.instance!=this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Clase GameController instanciada por segunda vez, esto no deberia pasar");
        }
        
    }

    public void BirdScore()
    {
        if (gameover == true)
        {
            return;
        }
        SoundSystem.instance.PlayCoin();
        score++;
        scoreText.text=("Score: " + score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
     * este código ya no es necesario ya que
     * ahora queremos que en vez de solicitar el game
     * over true, preguntaremos si el texto de toca para 
     * reiniciar esta activado, lo pondremos en otro script
    void Update()
    {
        if (gameover == true&& Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
    */
    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameover = true;

    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
