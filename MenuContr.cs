using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContr : MonoBehaviour
{
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            PlayerPrefs.SetString("nameLevel1", sceneName);

            SceneManager.LoadScene("Main menu");
        } else if(Input.GetKeyDown("v")) {
            SceneManager.LoadScene("StartPoint");
        }
    }
    public void GameScene()
    {
        SceneManager.LoadScene("StartPoint");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("nameLevel1"));
    }
    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Level2(){
        SceneManager.LoadScene("Game2");
    }
}
