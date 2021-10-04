using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // start game 버튼 클릭 시 scene 두개 합치기
    public void OnStartGameBtnClick()
    {
        SceneManager.LoadScene("Level01");
        SceneManager.LoadScene("Play", LoadSceneMode.Additive);  // 기존에 열려있던 scene 닫지 않고 추가
    }
}
