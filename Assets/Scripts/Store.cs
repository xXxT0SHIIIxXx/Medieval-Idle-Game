using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject playerManager;
    public GameObject UIManager;
    [Header("Farms")]
    public float farmsCost = 500;
    public float farmsGain = 10;
    public float farmsDelay = 1f;
    public float farmstimer;

    [Header("BlackSmiths")]
    public float bsCost = 1500;
   public float bsGain = 50;
  public float bsDelay = 4f;
    public float bsTimer;

    [Header("Scav")]
    public float scavTimer;
   public float scavGain;
   public float scavDelay = 5f;
    public bool scaving;

    [Header("Wizard Towers")]
    public float wtCost = 5000;
    public float wtGain = 150;
    public float wtDelay = 10f;
    public float wtTimer;

    [Header("Merchant")]
    [SerializeField] GameObject bscostText;
    [SerializeField] GameObject wtcostText;
    [SerializeField] GameObject farmcostText;
    [SerializeField] GameObject bsAmtText;
    [SerializeField] GameObject wtAmtText;
    [SerializeField] GameObject farmAmtText;
    [SerializeField] GameObject merch_wtBtn;
    [SerializeField] GameObject merch_farmBtn;
    [SerializeField] GameObject merch_bsBtn;
    [SerializeField] public GameObject merchScreen;
    float farmAmt;
    float bsAmt;
    float wtAmt;
    float merch_farmcost;
    float merch_wtcost;
    float merch_bscost;
    public bool buying;


    

    //Scavage Functions
    public void Scavage()
    {
        scaving = true;
    }
    //Farm Buying Functionality
    public void Farmbuy()
    {
        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - farmsCost;
        playerManager.GetComponent<PlayerStats>().farms = playerManager.GetComponent<PlayerStats>().farms + 1;
        farmsGain = playerManager.GetComponent<PlayerStats>().farms * 10;
        farmsCost = playerManager.GetComponent<PlayerStats>().farms * 100 + farmsCost;
    }

    //BlackSmith Buying Functionality
    public void BlackSmithBuy()
    {

        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - bsCost;
        playerManager.GetComponent<PlayerStats>().blacksmiths = playerManager.GetComponent<PlayerStats>().blacksmiths + 1;
        bsGain = playerManager.GetComponent<PlayerStats>().blacksmiths * 50;
        bsCost = playerManager.GetComponent<PlayerStats>().blacksmiths * 150 + bsCost;
    }

    public void Towerbuy()
    {
        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - wtCost;
        playerManager.GetComponent<PlayerStats>().wizardTowers = playerManager.GetComponent<PlayerStats>().wizardTowers + 1;
        wtGain = playerManager.GetComponent<PlayerStats>().wizardTowers * 100;
        wtCost = playerManager.GetComponent<PlayerStats>().wizardTowers * 250 + wtCost;
    }

    //Calls Merchant Inventory function and pops up the screen
    public void Merchant()
    {
        MerchantInventory();
        merchScreen.SetActive(true);
        buying = false;
    }

    //Sets Merchant Inventory
    public void MerchantInventory()
    {
        //Sets Amount of Buildings Merchant holds
        farmAmt = Random.Range(0, 5);
        bsAmt = Random.Range(0, 5);
        wtAmt = Random.Range(0, 5);

        //Sets Amount to strings for the text
        farmAmtText.GetComponent<UnityEngine.UI.Text>().text = farmAmt.ToString();
        bsAmtText.GetComponent<UnityEngine.UI.Text>().text = bsAmt.ToString();
        wtAmtText.GetComponent<UnityEngine.UI.Text>().text = wtAmt.ToString();

        // If amount is greater than 0 then set discount
        if (farmAmt > 0)
        {
            merch_farmcost = farmAmt * farmsCost - Random.Range(0, 100);
        }

        if (bsAmt > 0)
        {
            merch_bscost = bsAmt * bsCost - Random.Range(0, 500);
        }

        if (wtAmt > 0)
        {
            merch_wtcost = wtAmt * wtCost - Random.Range(0, 1000);
        }

        //Sets Building Cost based off Amount held
        farmcostText.GetComponent<UnityEngine.UI.Text>().text = merch_farmcost.ToString();
        bscostText.GetComponent<UnityEngine.UI.Text>().text = merch_bscost.ToString();
        wtcostText.GetComponent<UnityEngine.UI.Text>().text = merch_wtcost.ToString();

    }

    //Merchant Farms Selling
    public void MerchantFarms()
    {
        playerManager.GetComponent<PlayerStats>().farms = playerManager.GetComponent<PlayerStats>().farms + farmAmt;
        farmAmt = 0;
        farmAmtText.GetComponent<UnityEngine.UI.Text>().text = farmAmt.ToString();
        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - merch_farmcost;
        merch_farmcost = 0;
        farmcostText.GetComponent<UnityEngine.UI.Text>().text = merch_farmcost.ToString();
        merch_farmBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;


    }

    //Merchant Smithy Selling
    public void MerchantSmithy()
    {
        playerManager.GetComponent<PlayerStats>().blacksmiths = playerManager.GetComponent<PlayerStats>().blacksmiths + bsAmt;
        bsAmt = 0;
        bsAmtText.GetComponent<UnityEngine.UI.Text>().text = bsAmt.ToString();
        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - merch_bscost;
        merch_bscost = 0;
        bscostText.GetComponent<UnityEngine.UI.Text>().text = merch_bscost.ToString();
        merch_bsBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;


    }

    //Merchant Tower Selling
    public void MerchantTowers()
    {
        playerManager.GetComponent<PlayerStats>().wizardTowers = playerManager.GetComponent<PlayerStats>().wizardTowers + wtAmt;
        wtAmt = 0;
        wtAmtText.GetComponent<UnityEngine.UI.Text>().text = wtAmt.ToString();
        playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money - merch_wtcost;
        merch_wtcost = 0;
        wtcostText.GetComponent<UnityEngine.UI.Text>().text = merch_wtcost.ToString();
        merch_wtBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }

    // Exits Merchant Screen once X is hit
    public void MerchantExit()
    {
        merchScreen.SetActive(false);
        buying = false;
        UIManager.GetComponent<UIManager>().merchTimer = 0;
        UIManager.GetComponent<UIManager>().merch_leaveTimer = 0;
        
        


    }

    //Sets the Merch Screen False
    private void Start()
    {
        merchScreen.SetActive(false);
    }

    //Sets Delay for Money gain based off farm amount
    private void Update()
    {
        //Start Farm timer to payout
        if (playerManager.GetComponent<PlayerStats>().farms > 0)
        {
            farmstimer += Time.deltaTime;
        }
        //Reset Farm timer after it hits delay
        if (farmstimer > farmsDelay)
        {
            playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money + farmsGain;
            farmstimer = 0;
        }
        //Start Smithy timer to payout
        if (playerManager.GetComponent<PlayerStats>().blacksmiths > 0)
        {
            bsTimer += Time.deltaTime;
        }
        //Reset Smithy timer after it hits delay
        if (bsTimer > bsDelay)
        {
            playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money + bsGain;
            bsTimer = 0;
        }
        //Start Scav timer to payout
        if (scaving == true)
        {
            scavTimer += Time.deltaTime;
        }
        //Reset Scav timer after it hits delay
        if (scavTimer > scavDelay)
        {
            playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money + 100;
            scavTimer = 0;
            scaving = false;
        }

        //Start Tower timer to payout
        if (playerManager.GetComponent<PlayerStats>().wizardTowers > 0)
        {
            wtTimer += Time.deltaTime;
        }
        //Reset Tower timer after it hits delay
        if (wtTimer > wtDelay)
        {
            playerManager.GetComponent<PlayerStats>().money = playerManager.GetComponent<PlayerStats>().money + wtGain;
            wtTimer = 0;
        }

        //Merchant Button Interactions based off Current money amount
        if (playerManager.GetComponent<PlayerStats>().money < merch_wtcost)
        {
            merch_wtBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            merch_wtBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }

        if (playerManager.GetComponent<PlayerStats>().money < merch_farmcost)
        {
            merch_farmBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            merch_farmBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }

        if (playerManager.GetComponent<PlayerStats>().money < merch_bscost)
        {
            merch_bsBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            merch_bsBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
}
