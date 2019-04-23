using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Detta script byter mellan scener. Använd följande funktioner:
//LoadStartScene
//LoadIntro
//LoadOverworld
//LoadOfficer
//LoadBunker
//LoadFinal
//LoadGameOver
//QuitGame

public class LevelChanger : MonoBehaviour {

    public Animator animator;

    private int levelToLoad;


    //Josefs kod nedan

    public string sceneToLoad;
    //public Vector2 playerPosition;
    //public VectorValue playerStorage;

    [SerializeField] float delayInSeconds = 0f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            animator.SetTrigger("Fade_Out");
        }
    }

    //Josefs kod ovan


    // Update is called once per frame

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade_Out");
    }
    
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("Fade_Out");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        animator.SetTrigger("Fade_Out");
    }

    public void LoadIntro()
        {
            SceneManager.LoadScene(1);
            animator.SetTrigger("Fade_Out");   
        }

    public void LoadOverworld()
    {
        SceneManager.LoadScene(2);
        if (FindObjectOfType<GameSession>())
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        animator.SetTrigger("Fade_Out");
    }

    public void LoadOfficer()
    {
        SceneManager.LoadScene(3);
        animator.SetTrigger("Fade_Out");
    }

    public void LoadBunker()
    {
        SceneManager.LoadScene(6);
        animator.SetTrigger("Fade_Out");
    }

    public void LoadFinal()
    {
        SceneManager.LoadScene(4);
        animator.SetTrigger("Fade_Out");
    }

    //Pausat denna sålänge
    //public void LoadGameOver()
    
        //SceneManager.LoadScene(5);
        //animator.SetTrigger("Fade_Out");
    

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    //Josefs kod nedan

    /*public void LoadBunker()
    {
        StartCoroutine(BunkerLoad());
    }

    IEnumerator BunkerLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Bunker");
        animator.SetTrigger("Fade_Out");
    }*/

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
        animator.SetTrigger("Fade_Out");
    }

    //Josefs kod ovan


}
