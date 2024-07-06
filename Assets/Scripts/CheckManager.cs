using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckManager : MonoBehaviour
{
    public ParameterPasser parameterPasser;
    // Start is called before the first frame update
    void Start()
    {
        parameterPasser = GameObject.Find("Parameter Passer").GetComponent<ParameterPasser>();
        if(parameterPasser.roundResult)
        {
            GameObject.Find("textSuccess").GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            GameObject.Find("textFailed").GetComponent<TextMeshProUGUI>().enabled = true;
        }

        Destroy(parameterPasser.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
