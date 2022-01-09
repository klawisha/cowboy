using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : MonoBehaviour
{
    bool isHidden = true;
    [SerializeField]GameObject play_btn;
    [SerializeField]GameObject gameUI;
    [SerializeField]GameObject mainMenu;

    [SerializeField]GameObject playerPrefab;
    [SerializeField]GameObject playerStartPos;

    Vector3 mp;

    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onPlayerDeath += ShowMainMenu;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu()
    {
        Invoke("DelayMainMenuDisplay", Asteroid.destructionDelay*3);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        Instantiate(playerPrefab, playerStartPos.transform.position, playerPrefab.transform.rotation);
    }

    void DelayMainMenuDisplay()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void HidePanel()
    {
        isHidden = !isHidden;
        play_btn.SetActive(isHidden);

    }

    public void PlayGameBtn()
    {
        EventManager.StartGame();
    }

    void Start()
    {

       DelayMainMenuDisplay();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
