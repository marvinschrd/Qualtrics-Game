using System.Collections;
using System.Collections.Generic;
using HybridWebSocket;
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

    [SerializeField] private TMP_InputField ID;
    private float timePlayed = 0f;

    bool isInitialized = false;
    private float initializeWaitTime = 1.0f;
    public struct PlayerData
    {
       public string PlayerID;
       public int playerScore;
       public int objectMissed;
       public int wrongObjectCatched;
       public string timePlayed;
    }
    PlayerData playerData;
    // Start is called before the first frame update

    enum State
    {
        MAINMENU,
        PLAYING,
        INITIALIZESOCKET,
        SENDDATA,
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
                Time.timeScale = 0f;
                break;
            case State.PLAYING:
                menuPanel.SetActive(false);
                timePlayed += Time.deltaTime;
                playerData.PlayerID = ID.text;
                //Debug.Log("text = " +ID.text);
                Time.timeScale = 1f;
                break;
            case State.INITIALIZESOCKET:
                playerData.timePlayed = timePlayed.ToString() + " secondes";
                if (!isInitialized)
                {
                    socket.Initialize();  
                }
                    Debug.Log("initilized");
                isInitialized = true;
                initializeWaitTime -= Time.deltaTime;
                if (initializeWaitTime <= 0)
                {
                    state = State.SENDDATA;
                }
                break;
            case  State.SENDDATA:
                Time.timeScale = 0f;
                SaveToJson();
                break;
            case State.END:
                Debug.Log("ended");
                break;
        }

        if (playerData.playerScore < 0)
        {
            playerData.playerScore = 0;
        }
        scoreText.text = playerData.playerScore.ToString();
        if (playerData.playerScore != 0)
        {
           // SaveToJson();
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
        Debug.Log("socket state = " + socket.GetSocketState());
        if (socket.GetSocketState() == WebSocketState.Open)
        {
            string data = JsonUtility.ToJson(playerData, true);
            socket.SendUserData(data);
            Debug.Log("sent");
            state = State.END;
        }
    }

    public void SetPlaying()
    {
        state = State.PLAYING;
    }

    // public void SetPause()
    // {
    //     state = State.PAUSED;
    // }
    
    
    public void SetEnd()
    {
        state = State.INITIALIZESOCKET;
    }
}
