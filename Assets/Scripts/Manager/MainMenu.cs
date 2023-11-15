using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string gamesPage = "";

    private AudioSource sound;

    public Text bestScore;
    [SerializeField]
    private Sprite[] soundBtnSprites; //1 for off and 0 for on
    public Button playBtn, rateBtn, soundBtn;
    public string gameScene;

    [SerializeField]
    private Animator slideButtonAnim;

    void Start()
    {
        bestScore.text = "Best" + "\n" + GameManager.instance.hiScore;
        sound = GetComponent<AudioSource>();
        playBtn.GetComponent<Button>().onClick.AddListener(() => { PlayBtn(); });
        rateBtn.GetComponent<Button>().onClick.AddListener(() => { RateBtn(); });

        soundBtn.GetComponent<Button>().onClick.AddListener(() => { SoundBtn(); });
        
        if (PlayerPrefs.GetInt("gameMuted") == 0)
        {
            soundBtn.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[0];
            AudioListener.volume = 1f;
        }
        else if (PlayerPrefs.GetInt("gameMuted") == 1)
        {
            soundBtn.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[1];
            AudioListener.volume = 0f;
        }
    }

    void PlayBtn()
    {
        sound.Play();
        SceneManager.LoadScene(gameScene);
    }

    void RateBtn()
    {
        sound.Play();

        //Application.OpenURL(ANDROIDURL);

        GameManager.instance.showRate = false;
        GameManager.instance.Save();
    }

    void SoundBtn()
    {
        sound.Play();

        if (GameManager.instance.isMusicOn)
        {
            soundBtn.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[1];
            GameManager.instance.isMusicOn = false;
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("gameMuted", 1);
            GameManager.instance.Save();
        }
        else
        {
            soundBtn.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[0];
            GameManager.instance.isMusicOn = true;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("gameMuted", 0);
            GameManager.instance.Save();

        }
    }
}