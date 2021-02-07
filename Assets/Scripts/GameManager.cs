using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject playingPanel;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] private GameObject prefabCross;
    [SerializeField] private GameObject prefabCheckMark;
    
    private ScreenShaker shaker;
    private WebSocketDemo socket;
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
        shaker = FindObjectOfType<ScreenShaker>();
        socket = FindObjectOfType<WebSocketDemo>();
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
        if (playerData.playerScore != 0)
        {
            SaveToJson();
        }
    }

    public void AddScore(int point)
    {
        playerData.playerScore += point;
        GameObject checkMark = Instantiate(prefabCheckMark, new Vector3(0, 0, 0), quaternion.identity);
        Destroy(checkMark,1);
    }

    public void SubScore(int point)
    {
        playerData.playerScore -= point;
        GameObject cross = Instantiate(prefabCross, new Vector3(0, 0, 0), quaternion.identity);
        shaker.TriggerShake(0.8f);
        Destroy(cross,1);
    }

    public void SaveToJson()
    {
        string data = JsonUtility.ToJson(playerData, true);
        socket.SendUserData(data);
    }
}
