using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State introState;
    [SerializeField] State deathState;
    [SerializeField] State startState;
    [SerializeField] State room6KeyGet;
    [SerializeField] State miniBossKeyGet;
    [SerializeField] State room2;
    [SerializeField] State room2L;
    [SerializeField] State room2T;
    [SerializeField] State room1;
    [SerializeField] State room1T;

        
    State state;

    bool hasGoldKey = false;
    bool hasSilverKey = false;


    // Start is called before the first frame update
    void Start()
    {
        hasGoldKey = false;
        hasSilverKey = false;
        state = introState;
        textComponent.text = state.GetStateStory();
    }
    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState() {
        //State[] nextStates....
        var nextStates = state.GetNextStates();
        //Still has array out of bounds error but plays still. 
        if ((state == deathState) && Input.GetKeyDown(KeyCode.Y))
        {
            state = startState;
        }
        else if ((state == deathState) && Input.GetKeyDown(KeyCode.N))
        {
            state = introState;
        }
        else if ((state == room6KeyGet) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            hasSilverKey = true;
            state = nextStates[3];
        }
        else if ((state == miniBossKeyGet) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            hasGoldKey = true;
            state = nextStates[0];
        }
        else if ((state == room2) && (hasSilverKey == false) && Input.GetKeyDown(KeyCode.RightArrow))
        {
                state = nextStates[4];
        }
        else if ((state == room2L) && (hasSilverKey == false) && Input.GetKeyDown(KeyCode.UpArrow))
        {
                state = nextStates[4];
        }
        else if ((state == room2T) && (hasSilverKey == false) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
                state = nextStates[4];
        }
        else if ((state == room1) && (hasGoldKey == false) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            state = nextStates[1];
        }
        else if ((state == room1T) && (hasGoldKey == false) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            state = nextStates[2];
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                state = nextStates[0];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state = nextStates[1];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state = nextStates[2];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                state = nextStates[3];
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                state = introState;
            }
            else if ((state == deathState) && Input.GetKeyDown(KeyCode.Y))
            {
                state = introState;
            }
        }
       
        textComponent.text = state.GetStateStory();
    }
}
