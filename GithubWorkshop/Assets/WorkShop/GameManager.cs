using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    //音ファイル
    [SerializeField] AudioClip[] seLists;
    [SerializeField] AudioClip[] bgmLists;

    //音の鳴らし方指定
    [Header("SEのAudioSorce")]
    [SerializeField] AudioSource audioSorceSE;
    [Header("SEのAudioSorce")]
    [SerializeField] AudioSource audioSorceBGM;

    [Header("スライダー")]
    public Slider seSlider;
    public Slider bgmSlider;

    public static int score;
    public static bool isClear;

    float seVolume;
    float bgmVolume;

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

    void Start()
    {
        if(seSlider != null && bgmSlider != null)
        {
            seSlider.onValueChanged.AddListener(delegate { OnSEVolumeChange(); });
            bgmSlider.onValueChanged.AddListener(delegate { OnBGMVolumeChange(); });
        }
        PlayBGM(0);
    }

    private void Update()
    {
        if (!Work4Start.isHome)
        {
            if (seSlider == null && bgmSlider == null)
            {
                seSlider = GameObject.Find("Canvas/Setting/SE/Slider").GetComponent<Slider>();
                bgmSlider = GameObject.Find("Canvas/Setting/BGM/Slider").GetComponent<Slider>();
                seSlider.onValueChanged.AddListener(delegate { OnSEVolumeChange(); });
                bgmSlider.onValueChanged.AddListener(delegate { OnBGMVolumeChange(); });
            }

            seSlider.value = SEVolume;
            bgmSlider.value = BGMVolume;
        }
    }

    public void Init()
    {
        score = 0;
        isClear = false;
    }


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


    #region Custom
    /*========================================================*/
    // Work4

    public void CustomTitle() //タイトル
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void CustomGame() //メインゲーム
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void CustomResult() //リザルト
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }

    #endregion


    public void EndGame() //Quit
    {
        /*
         * これはプリプロセッサでビルド時には対応している方のみがコンパイルされる
        */
        #if UNITY_EDITOR //unity内でゲーム時
                UnityEditor.EditorApplication.isPlaying = false;
        #else //ビルドされたゲームの時
                    Application.Quit();
        #endif
    }


    #region SE・BGM操作

    // BGMの値が変更されたときの処理
    public void OnBGMVolumeChange()
    {
        //bgmVolume = bgmSlider.value;
        audioSorceBGM.volume = bgmSlider.value; // AudioSourceに適用
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume); // 保存
        PlayerPrefs.Save();
    }

    // SEの値が変更されたときの処理
    public void OnSEVolumeChange()
    {
        //seVolume = seSlider.value;
        audioSorceSE.volume = seSlider.value; // AudioSourceに適用
        PlayerPrefs.SetFloat("SEVolume", seVolume); // 保存
        PlayerPrefs.Save();
    }

    public float BGMVolume //BGM�{�����[��
    {
        get { return audioSorceBGM.volume; }
        set { audioSorceBGM.volume = value; }
    }

    public float SEVolume //SE�{�����[��
    {
        get { return audioSorceSE.volume; }
        set { audioSorceSE.volume = value; }
    }

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
