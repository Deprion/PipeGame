using System;
using UnityEngine;
using YG;
/// <summary>
/// This script helps in saving and loading data in device
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool isGameOver = false;
    public int currentScore;

    public bool isMusicOn
    {
        get {return YandexGame.savesData.isMusicOn;}
        set{YandexGame.savesData.isMusicOn = value;}
    }
    public int hiScore
    {
        get{return YandexGame.savesData.hiScore;}
        set{YandexGame.savesData.hiScore = value;}
    }
    public int points 
    {
        get{return YandexGame.savesData.points;}
        set{YandexGame.savesData.points = value;}
    }
    public int textureStyle 
    {
        get{return YandexGame.savesData.textureStyle;}
        set{YandexGame.savesData.textureStyle = value;}
    }
    public bool[] textureUnlocked 
    {
        get{return YandexGame.savesData.textureUnlocked;}
        set {YandexGame.savesData.textureUnlocked = value;}
    }

    void Awake()
    {
        MakeInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ScreenCapture.CaptureScreenshot(UnityEngine.Random.Range(0, 10000).ToString());
    }

    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //method to save data
    public void Save()
    {
        YandexGame.SaveProgress();
    }
}

[Serializable]
class GameData
{
    private bool isMusicOn;
    private int hiScore, points, textureStyle;
    private bool[] textureUnlocked;

    public void setIsMusicOn(bool isMusicOn)
    {
        this.isMusicOn = isMusicOn;
    }

    public bool getIsMusicOn()
    {
        return isMusicOn;
    }

    //high score 
    public void setHiScore(int hiScore)
    {
        this.hiScore = hiScore;
    }

    public int getHiScore()
    {
        return hiScore;
    }

    //points 
    public void setPoints(int points)
    {
        this.points = points;
    }

    public int getPoints()
    {
        return points;
    }

    //textureStyle 
    public void setTexture(int textureStyle)
    {
        this.textureStyle = textureStyle;
    }

    public int getTexture()
    {
        return textureStyle;
    }

    //texture unlocked
    public void setTextureUnlocked(bool[] textureUnlocked)
    {
        this.textureUnlocked = textureUnlocked;
    }

    public bool[] getTextureUnlocked()
    {
        return textureUnlocked;
    }
}