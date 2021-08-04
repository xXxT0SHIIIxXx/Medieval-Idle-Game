using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject playerManager;

    //Changes Screens from Start Screen to Gameplay Screen
    public void StartRun()
    {
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        playerManager.GetComponent<PlayerStats>().Initalize();
    }
    // Start is called before the first frame update
    public void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
