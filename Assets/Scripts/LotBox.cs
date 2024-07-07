using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LotBox : MonoBehaviour
{

    public GameManager gameManager;
    public DataManager dataManager;
    public Num numGood;
    public Num numBad;
    public List<Lot> lotsInBox;

    // Start is called before the first frame update
    void Start()
    {
        numGood = GameObject.Find("numGood").GetComponent<Num>();
        numBad = GameObject.Find("numBad").GetComponent<Num>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        lotsInBox = new List<Lot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Lot")
        {
            // Debug.Log("lot enter");
            Lot lot = other.GetComponent<Lot>();
            lotsInBox.Add(lot);
            if(lot.isGood == true)
            {
                // Debug.Log("Good lot");
                numGood.num += 1;
            }
            else
            {
                // Debug.Log("Bad lot");
                numBad.num += 1;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Lot")
        {
            // Debug.Log("lot out");
            Lot lot = other.GetComponent<Lot>();
            lotsInBox.Remove(lot);
            if(lot.isGood == true)
            {
                // Debug.Log("Good lot");
                numGood.num -= 1;
            }
            else
            {
                // Debug.Log("Bad lot");
                numBad.num -= 1;
            }
        }
    }

    public bool TrueLotDrawed()
    {
        List<int> lots = new List<int>();
        bool isGood;
        for(int i = 0; i < numGood.num; i++)
        {
            lots.Add(1);
        }

        for(int i = 0; i < numBad.num; i++)
        {
            lots.Add(0);
        }

        if(lots[Random.Range(0, lots.Count)] == 1)
        {
            isGood = true;
        }
        else
        isGood = false;

        foreach(Lot lot in lotsInBox)
        {
            if(isGood && lot.isGood)
            {
                StartCoroutine(LotAnimation(lot));
            }
            else if(!isGood && lot.isGood == false)
            {
                StartCoroutine(LotAnimation(lot));
            }
        }

        return isGood;
    }

    IEnumerator LotAnimation(Lot lot)
    {
        Debug.Log("Animation Start");
        lot.coll.isTrigger = true;
        lot.rb.bodyType = RigidbodyType2D.Kinematic;
        while(lot.transform.position!=transform.position)
        {
            // Debug.Log(1);
            lot.transform.position=Vector3.MoveTowards(lot.transform.position,transform.position, 4.5f*Time.deltaTime);
            yield return 0;
        }
        // yield return new WaitForSeconds(1f);
        while(lot.transform.position!=new Vector3(transform.position.x, transform.position.y + 5, 0))
        {
            // Debug.Log(1);
            lot.transform.position=Vector3.MoveTowards(lot.transform.position, new Vector3(transform.position.x, transform.position.y + 5, 0), 6f*Time.deltaTime);
            yield return 0;
        };
        lot.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        // yield return new WaitForSeconds(1f);
        while(lot.transform.position!=new Vector3(0,0,0))
        {
            // Debug.Log(1);
            lot.transform.position=Vector3.MoveTowards(lot.transform.position, new Vector3(0,0,0), 7.5f*Time.deltaTime);
            yield return 0;
        }
        
        GameObject.Find("buddha").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Props/buddha_" + dataManager.phase);
        GameObject.Find("buddha").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SFX/buddhaChange");
        GameObject.Find("buddha").GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1f);
        gameManager.Invoke("LoadCheckScene", 0f);
    }
}
