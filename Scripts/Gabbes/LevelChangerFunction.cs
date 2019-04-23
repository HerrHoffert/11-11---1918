
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerFunction : MonoBehaviour {

    public Animator animator;

    public int levelToLoad;
	
    // Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            FadeToNextLevel();
        }
    
	}

    public void FadeToNextLevel ()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade_Out");
    }
    
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
