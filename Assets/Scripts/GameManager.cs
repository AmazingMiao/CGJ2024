using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LotBox lotBox;
    public RandomCharcterCreater randomCharcterCreater;
    public ParameterPasser parameterPasser;
    public DataManager dataManager;

    public bool roundResult;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        lotBox = GameObject.Find("LotBox").GetComponent<LotBox>();
        randomCharcterCreater = GameObject.Find("Character Generator").GetComponent<RandomCharcterCreater>();
        parameterPasser = GameObject.Find("Parameter Passer").GetComponent<ParameterPasser>();

        GameObject.Find("MusicSpeaker").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/" + dataManager.phase);
        GameObject.Find("MusicSpeaker").GetComponent<AudioSource>().Play();

        GameObject.Find("buddha").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Props/buddha_" + dataManager.phase);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Gameplay");
        }

        if(Input.GetKeyDown(KeyCode.Return) && (lotBox.numBad.GetComponent<Num>().num + lotBox.numGood.GetComponent<Num>().num) > 0)
        {
            Check();
        }
    }

    public void Check()
    {
        if(randomCharcterCreater.result == lotBox.TrueLotDrawed())
        {
            roundResult = true;
            parameterPasser.roundResult = true;
            Debug.Log("Success");
        }
        else
        {
            roundResult = false;
            parameterPasser.roundResult = false;
            dataManager.phase++;
            Debug.Log("Failed");
        }

        
    }

    public void LoadCheckScene()
    {
        SceneManager.LoadScene("Check");
    }
}