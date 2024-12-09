using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    //音ファイル
    [SerializeField] AudioClip[] seLists;
    [SerializeField] AudioClip[] bgmLists;

    //音の鳴らし方指定
    [SerializeField] AudioSource audioSorceSE;
    [SerializeField] AudioSource audioSorceBGM;

    public static int score;

    #region シングルトン
    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<GameManager>();
        }
        return Instance;
    }
    private void Awake()
    {
        if (this != GetInstance())
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    #region Work1
    /*========================================================*/
    // Work1
    public void Work1Title() //タイトル
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work1Title");
    }

    public void Work1Game() //メインゲーム
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work1Main");
    }
    #endregion

    #region Work2
    /*========================================================*/
    // Work2

    public void Work2Title() //タイトル
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work2Title");
    }

    public void Work2Game() //メインゲーム
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work2Main");
    }

    #endregion

    #region Work3
    /*========================================================*/
    // Work3

    public void Work3Title() //タイトル
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work3Title");
    }

    public void Work3Game() //メインゲーム
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work3Main");
    }

    public void Work3Result() //リザルト
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work3Result");
    }

    #endregion

    #region Work4
    /*========================================================*/
    // Work4

    public void Work4Title() //タイトル
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work4Title");
    }

    public void Work4Game() //メインゲーム
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work4Main");
    }

    public void Work4Result() //リザルト
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Work4Result");
    }

    #endregion

    public void EndGame() //Quit
    {
        /*
         * これはプリプロセッサコンパイルでビルド時には対応している方のみがコンパイルされる
        */
        #if UNITY_EDITOR //unity内でゲーム時
                UnityEditor.EditorApplication.isPlaying = false;
        #else //ビルドされたゲームの時
                    Application.Quit();
        #endif
    }


    #region SE・BGM操作

    public void PlaySound(int index) //SE再生
    {
        audioSorceSE.PlayOneShot(seLists[index]);
    }

    public void PlayBGM(int index) //BGM再生
    {
        audioSorceBGM.clip = bgmLists[index];
        audioSorceBGM.Play();
    }

    public void StopBGM() //BGM停止
    {
        audioSorceBGM.Stop();
    }
    #endregion
}
