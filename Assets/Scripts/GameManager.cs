using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject playingPanel;

    [SerializeField] TextMeshProUGUI scoreText;
    struct PlayerData
    {
       public int PlayerID;
       public int playerScore;
       public int objectMissed;
       public int wrongObjectCatched;
       public float timePlayed;
    }
    PlayerData playerData;
    // Start is called before the first frame update

    enum State
    {
        MAINMENU,
        PLAYING,
        PAUSED,
        END
    }

    private State state = State.MAINMENU;
    void Start()
    {
        playerData.playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.MAINMENU:
                break;
            case State.PLAYING:
                break;
            case State.PAUSED:
                break;
            case State.END:
                break;
        }

        scoreText.text = playerData.playerScore.ToString();
    }

    public void AddScore(int point)
    {
        playerData.playerScore += point;
    }
    
}
