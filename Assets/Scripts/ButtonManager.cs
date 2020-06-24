using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

	public void LoadToScene(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	public void StartGame() {
		Player.autoIncreaseSpeed = true;
		SceneManager.LoadScene ("Game");
	}

	public void SpeedMode() {
		Player.autoIncreaseSpeed = true;
		SceneManager.LoadScene ("Speed");
	}

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
