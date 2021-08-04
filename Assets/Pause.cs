using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject gameplayScreen;
    [SerializeField] GameObject pauseScreen;


    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        gameplayScreen.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            gameplayScreen.SetActive(false);
            pauseScreen.SetActive(true);
        }

       
    }
}
