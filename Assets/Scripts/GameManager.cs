using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MAX_TIME;
    private int timeLeft;
    public static GameManager instance;
    private CameraManager cameraManager;
    private PlayerControlls player;
    private UIManager ui;
    private int actualLevel = 0;
    private Weapons actualWeapon = Weapons.DAGGER;
    private bool textsNotLinked = true;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            timeLeft = MAX_TIME;
        }
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (textsNotLinked && IsLevelScene())
        {
            textsNotLinked = false;

            player = FindObjectOfType<PlayerControlls>();
            cameraManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>();
            ui = FindObjectOfType<UIManager>();
            if (ui != null)
            {
                ui.UpdateTimeLeft(timeLeft);
                ui.UpdateWeapon(actualWeapon);
            }
        }
    }

    public void Pause(bool paused)
    {
        ui.Pause(paused);
    }

    private bool IsLevelScene()
    {
        if (SceneManager.GetActiveScene().name == "Title" || SceneManager.GetActiveScene().name == "End")
            return false;
        return true;
    }

    public void RemoveTime(int decrementTime)
    {
        timeLeft -= decrementTime;
        if (ui != null) ui.UpdateTimeLeft(timeLeft);
        if (timeLeft <= 0)
        {
            StartLevel(0f, 5);
        }
    }

    public Weapons GetWeapon()
    {
        return actualWeapon;
    }

    public void UpdateWeapon(Weapons weaponType)
    {
        actualWeapon = weaponType;
        if (ui != null) ui.UpdateWeapon(actualWeapon);
    }

    public void RemoveTime(int decrementTime, bool rumble)
    {
        if (rumble)
        {
            player.Damage();
            cameraManager.Shake(0.1f, 0.2f);
        }
        timeLeft -= decrementTime;
        if (ui != null) ui.UpdateTimeLeft(timeLeft);
        if (timeLeft <= 0)
        {
            StartLevel(0.5f, 5);
        }
    }

    public void StartLevel(float delay, int level)
    {
        StartCoroutine(StartLevelDelay(delay, level));
    }

    private IEnumerator StartLevelDelay(float delay, int level)
    {
        yield return new WaitForSeconds(delay);

        if (level == 1)
            SceneManager.LoadScene("FirstLevel");
        else if (level == 2)
            SceneManager.LoadScene("SecondLevel");
        else if (level == 3)
            SceneManager.LoadScene("FinalLevel");
        else if (level == 4)
            SceneManager.LoadScene("End");
        else if (level == 5)
        {
            actualWeapon = Weapons.DAGGER;
            actualLevel = 0;
            timeLeft = MAX_TIME;
            SceneManager.LoadScene("GameOver");
        }
        else
            SceneManager.LoadScene("Title");

        textsNotLinked = true;
    }

    public int GetActualLevel()
    {
        return actualLevel;
    }

    public int GetNextLevel()
    {
        actualLevel++;
        if (actualLevel >= 5)
            actualLevel = 0;

        return actualLevel;
    }
}
