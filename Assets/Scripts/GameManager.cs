using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LotBox lotBox;
    public RandomCharcterCreater randomCharcterCreater;
    public ParameterPasser parameterPasser;

    public bool roundResult;

    // Start is called before the first frame update
    void Start()
    {
        lotBox = GameObject.Find("LotBox").GetComponent<LotBox>();
        randomCharcterCreater = GameObject.Find("Character Generator").GetComponent<RandomCharcterCreater>();
        parameterPasser = GameObject.Find("Parameter Passer").GetComponent<ParameterPasser>();
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
            SceneManager.LoadScene("Check");
        }
        else
        {
            roundResult = false;
            parameterPasser.roundResult = false;
            Debug.Log("Failed");
            SceneManager.LoadScene("Check");
        }
    }
}