using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSystem : MonoBehaviour
{
    public void GameSceneCtrl(){
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }
}
