using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckManager : MonoBehaviour
{
    public ParameterPasser parameterPasser;
    public DataManager dataManager;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        parameterPasser = GameObject.Find("Parameter Passer").GetComponent<ParameterPasser>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

        if(parameterPasser.roundResult)
        {
            GameObject.Find("textSuccess").GetComponent<TextMeshProUGUI>().enabled = true;
            dataManager.score++;
        }
        else
        {
            dataManager.phase++;
            if(dataManager.phase >= 3)
            {
                isDead = true;
                GameObject.Find("textDead").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("pressEnterToContinue").GetComponent<TextMeshProUGUI>().text = "Press Enter to back to main menu";
            }
            else
            GameObject.Find("textFailed").GetComponent<TextMeshProUGUI>().enabled = true;
            dataManager.score++;
        }

        GameObject.Find("textPhase").GetComponent<TextMeshProUGUI>().text = "Phase: " + dataManager.phase;
        GameObject.Find("textScore").GetComponent<TextMeshProUGUI>().text = "Score: " + dataManager.score;

        Destroy(parameterPasser.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)&&isDead)
        {
            Destroy(dataManager.gameObject);
            SceneManager.LoadScene(0);
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
