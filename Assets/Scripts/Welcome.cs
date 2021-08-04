using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameScreen;
    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        gameScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
