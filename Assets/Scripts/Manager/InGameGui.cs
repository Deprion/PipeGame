using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class InGameGui : MonoBehaviour {

    private AudioSource sound;
    public GameObject gameOn , gameOver;
    public Text score, best, ingameScore, pointText;
    public Color[] medalCols;
    public Image medal;
    public Button homeBtn, retryBtn;
    public string mainMenu;
    int jSafe = 0;

    private int NbTimePlayed; // number of times the game was played

	void Start ()
    {
        sound = GetComponent<AudioSource>();
        GameManager.instance.currentScore = 0;
        ingameScore.text = "" + GameManager.instance.currentScore;
        homeBtn.GetComponent<Button>().onClick.AddListener(() => { HomeBtn(); });    //home
        retryBtn.GetComponent<Button>().onClick.AddListener(() => { RetryBtn(); });    //retry
        jSafe = 0;
    }

    void Update ()
    {
        ingameScore.text = GameManager.instance.currentScore.ToString();

        if (GameManager.instance.isGameOver && jSafe == 0)
        {
            if (GameManager.instance.currentScore >= GameManager.instance.hiScore)
            {
                GameManager.instance.hiScore = GameManager.instance.currentScore;
                GameManager.instance.Save();

                YandexGame.NewLeaderboardScores("Main", GameManager.instance.hiScore);
            }

            score.text = GameManager.instance.currentScore.ToString();
            best.text = GameManager.instance.hiScore.ToString();
            MedalColor();
            gameOn.SetActive(false);
            gameOver.SetActive(true);

            if (GameManager.instance.currentScore >= 3)
            {
                int point = GameManager.instance.currentScore / 3;
                pointText.text = "Очки +" + point;
                GameManager.instance.points += point;
                GameManager.instance.Save();
            }
            else if (GameManager.instance.currentScore < 3)
            {
                pointText.gameObject.SetActive(false);
            }
        }

        if (GameManager.instance.isGameOver && jSafe == 0)
        {
            NbTimePlayed = PlayerPrefs.GetInt("NbTimePlayed") + 1;
            PlayerPrefs.SetInt("NbTimePlayed", NbTimePlayed);
            jSafe = 1;
        }

    }

    void HomeBtn()
    {
        sound.Play();
        GameManager.instance.isGameOver = false;
        SceneManager.LoadScene(mainMenu);
        jSafe = 0;
    }

    void RetryBtn()
    {
        sound.Play();
        GameManager.instance.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        jSafe = 0;
    }
    void MedalColor()
    {
        if (GameManager.instance.currentScore >= 10)
        {
            medal.color = medalCols[0];
        }
        else if (GameManager.instance.currentScore >= 25)
        {
            medal.color = medalCols[1];
        }
        else if (GameManager.instance.currentScore >= 40)
        {
            medal.color = medalCols[2];
        }
        else if (GameManager.instance.currentScore >= 60)
        {
            medal.color = medalCols[3];
        }
        else if (GameManager.instance.currentScore >= 80)
        {
            medal.color = medalCols[4];
        }
    }


}
