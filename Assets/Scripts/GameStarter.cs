using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

    public Animator animator;
    public Button classic;
    public Button hardMode;
    public int mode;

    // Use this for initialization
    void Start () {
        Button playBtn = classic.GetComponent<Button>();
        playBtn.onClick.AddListener(classicBtnClick);
        Button hardBtn = hardMode.GetComponent<Button>();
        hardMode.onClick.AddListener(hardBtnClick);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void classicBtnClick()
    {
        mode = 0;
        animator.SetTrigger("fade");
    }
    void hardBtnClick()
    {
        mode = 2;
        animator.SetTrigger("fade");
    }
    void StartGame()
    {
        if (mode == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if(mode == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
