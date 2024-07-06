using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartCoroutine(StartCinematic());
        }
    }

    IEnumerator StartCinematic()
    {
        SpriteRenderer blackScreen = GameObject.Find("blackScreen").GetComponent<SpriteRenderer>();
        while(blackScreen.color.a <= 1)
        {
            // Debug.Log(1);
            blackScreen.color = new Color(0,0,0,blackScreen.color.a + 0.01f);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(1);

        for(int i = 1; i < 7; i++)
        {
            TextMeshProUGUI text = GameObject.Find("textTutorial_"+i).GetComponent<TextMeshProUGUI>();
            while(text.color.a <= 1)
            {
                // Debug.Log(1);
                text.color = new Color(1,1,1,text.color.a + 0.025f);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(1);

        SpriteRenderer blackScreen2 = GameObject.Find("blackScreen2").GetComponent<SpriteRenderer>();
        while(blackScreen2.color.a <= 1)
        {
            // Debug.Log(1);
            blackScreen2.color = new Color(0,0,0,blackScreen2.color.a + 0.01f);
            yield return new WaitForFixedUpdate();
        }

        // for(int i = 1; i < 7; i++)
        // {
        //     TextMeshProUGUI text = GameObject.Find("textTutorial_"+i).GetComponent<TextMeshProUGUI>();
        //     text.enabled = false;
        //     yield return new WaitForFixedUpdate();
        // }

        SpriteRenderer cutScene1 = GameObject.Find("cutScene_1").GetComponent<SpriteRenderer>();
        cutScene1.color = new Color(1,1,1,1);

        yield return new WaitForSeconds(1);

        while(blackScreen2.color.a >= 0)
        {
            // Debug.Log(1);
            blackScreen2.color = new Color(0,0,0,blackScreen2.color.a - 0.01f);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }
}
