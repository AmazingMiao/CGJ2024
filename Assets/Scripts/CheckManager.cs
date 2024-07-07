using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CheckManager : MonoBehaviour
{
    public ParameterPasser parameterPasser;
    public DataManager dataManager;
    public VideoPlayer videoPlayer;
    public bool isDead;
    // Start is called before the first frame update

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += SwitchScene;
    }

    void Start()
    {
        parameterPasser = GameObject.Find("Parameter Passer").GetComponent<ParameterPasser>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

        if(parameterPasser.roundResult)
        {
            // GameObject.Find("textSuccess").GetComponent<TextMeshProUGUI>().enabled = true;
            videoPlayer.clip = Resources.Load<VideoClip>("Video/success");
            videoPlayer.Play();
            dataManager.score++;
        }
        else if(dataManager.phase >= 3)
        {
            isDead = true;
            // GameObject.Find("textDead").GetComponent<TextMeshProUGUI>().enabled = true;
            // GameObject.Find("pressEnterToContinue").GetComponent<TextMeshProUGUI>().text = "Press Enter to back to main menu";
            // GameObject.Find("textSuccess").GetComponent<TextMeshProUGUI>().enabled = true;
            videoPlayer.clip = Resources.Load<VideoClip>("Video/failed");
            // if(Resources.Load<VideoClip>("Video/failed") == null)
            // Debug.Log("cant load");
            // else
            // Debug.Log("load");
            // videoPlayer.clip = Resources.Load<VideoClip>("Video/failed");

            videoPlayer.Play();
        }
        else
        {
            dataManager.score++;
            videoPlayer.clip = Resources.Load<VideoClip>("Video/fail"+dataManager.phase);
            videoPlayer.Play();
        }
        

            // GameObject.Find("textFailed").GetComponent<TextMeshProUGUI>().enabled = true;
            //dataManager.phase++;
        }

        // GameObject.Find("textPhase").GetComponent<TextMeshProUGUI>().text = "Phase: " + dataManager.phase;
        // GameObject.Find("textScore").GetComponent<TextMeshProUGUI>().text = "Score: " + dataManager.score;

        
    

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Return)&&isDead)
        // {
        //     Destroy(dataManager.gameObject);
        //     SceneManager.LoadScene(0);
        // }
        // else if(Input.GetKeyDown(KeyCode.Return))
        // {
        //     SceneManager.LoadScene("Gameplay");
        // }
    }

    void SwitchScene(VideoPlayer video)
    {
        if(isDead)
        {
            Destroy(dataManager.gameObject);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
