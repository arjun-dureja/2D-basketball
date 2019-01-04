using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

    public Animator animator;
    public Button play;

    // Use this for initialization
    void Start () {
        Button playBtn = play.GetComponent<Button>();
        playBtn.onClick.AddListener(TaskOnClick);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        animator.SetTrigger("fade");
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
