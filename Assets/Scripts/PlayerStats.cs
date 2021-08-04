using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public float money;
    public float farms;
    public float wizardTowers;
    public float blacksmiths;
    public float buildings;

    //Starting Amounts
    public void Initalize()
    {
        money = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // if your money goes into the negatives then this stops you at $0
    void Update()
    {
        if (money < 0)
        {
            money = 0;
        }

        if (money >= 99999)
        {
            Application.Quit();
        }
    }
}
