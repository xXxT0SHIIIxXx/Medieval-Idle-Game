using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject moneytext;
    [SerializeField] GameObject playerManager;
    [SerializeField] GameObject marketplace;
    [SerializeField] GameObject farmBtn;
    [SerializeField] GameObject farmsCount;
    [SerializeField] GameObject farmsAmount;
    [SerializeField] GameObject bsBtn;
    [SerializeField] GameObject bsCount;
    [SerializeField] GameObject bsAmount;
    [SerializeField] GameObject scavBtn;
    [SerializeField] GameObject scavBar;
    [SerializeField] GameObject farmsBar;
    [SerializeField] GameObject bsBar;
    [SerializeField] GameObject bsNetText;
    [SerializeField] GameObject farmsNetText;
    [SerializeField] GameObject wtNetText;
    [SerializeField] GameObject wtBtn;
    [SerializeField] GameObject wtCount;
    [SerializeField] GameObject wtAmount;
    [SerializeField] GameObject wtBar;
    [SerializeField] GameObject merchantBtn;
    float farmsNet;
    float wtNet;
    float bsNet;
   public bool arrived;
    public float merchDelay = 20f;
    public float merchTimer;
    public float merch_leaveDelay = 20f;
    public float merch_leaveTimer;
    float netGains;
    float merchantArrive;


    // Start is called before the first frame update
    void Start()
    {
        merchantBtn.SetActive(false);
    }

    // Changes Text to current value
    void Update()
    {
        farmsCount.GetComponent<UnityEngine.UI.Text>().text = playerManager.GetComponent<PlayerStats>().farms.ToString();
        farmsAmount.GetComponent<UnityEngine.UI.Text>().text = marketplace.GetComponent<Store>().farmsCost.ToString();
    

        bsCount.GetComponent<UnityEngine.UI.Text>().text = playerManager.GetComponent<PlayerStats>().blacksmiths.ToString();
        bsAmount.GetComponent<UnityEngine.UI.Text>().text = marketplace.GetComponent<Store>().bsCost.ToString();

        wtCount.GetComponent<UnityEngine.UI.Text>().text = playerManager.GetComponent<PlayerStats>().wizardTowers.ToString();
        wtAmount.GetComponent<UnityEngine.UI.Text>().text = marketplace.GetComponent<Store>().wtCost.ToString();

        moneytext.GetComponent<UnityEngine.UI.Text>().text = playerManager.GetComponent<PlayerStats>().money.ToString();


        //Farm Button/bar Interactions
        if (playerManager.GetComponent<PlayerStats>().money < marketplace.GetComponent<Store>().farmsCost)
        {
            farmBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
            
        }
        else
        {
            farmBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
            
        }

        if (playerManager.GetComponent<PlayerStats>().farms > 0)
        {
            farmsBar.SetActive(true);
            farmsBar.GetComponent<UnityEngine.UI.Slider>().maxValue = marketplace.GetComponent<Store>().farmsDelay;
        }
        else
        {
            farmsBar.SetActive(false);
        }

        //Smithy Button/bar Interactions
        if (playerManager.GetComponent<PlayerStats>().money < marketplace.GetComponent<Store>().bsCost)
        {
            bsBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
            
        }
        else
        {
            bsBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
            
        }

        if (playerManager.GetComponent<PlayerStats>().blacksmiths > 0)
        {
            bsBar.SetActive(true);
            bsBar.GetComponent<UnityEngine.UI.Slider>().maxValue = marketplace.GetComponent<Store>().bsDelay;
        }
        else
        {
            bsBar.SetActive(false);
        }
        //Scav Button/bar Interactions
        if (marketplace.GetComponent<Store>().scaving == true)
        {
            scavBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;
            scavBar.SetActive(true);
            scavBar.GetComponent<UnityEngine.UI.Slider>().maxValue = marketplace.GetComponent<Store>().scavDelay;

        }
        else
        {
            scavBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;
           scavBar.SetActive(false);

        }

        //Wizard Tower Functionality

        if (playerManager.GetComponent<PlayerStats>().money < marketplace.GetComponent<Store>().wtCost)
        {
            wtBtn.GetComponent<UnityEngine.UI.Button>().interactable = false;

        }
        else
        {
            wtBtn.GetComponent<UnityEngine.UI.Button>().interactable = true;

        }

        if (playerManager.GetComponent<PlayerStats>().wizardTowers > 0)
        {
            wtBar.SetActive(true);
            wtBar.GetComponent<UnityEngine.UI.Slider>().maxValue = marketplace.GetComponent<Store>().wtDelay;
        }
        else
        {
            wtBar.SetActive(false);
        }

        //Net Gain functionality
        if (playerManager.GetComponent<PlayerStats>().buildings > 0)
        {

            netGains = marketplace.GetComponent<Store>().farmsGain + marketplace.GetComponent<Store>().bsGain;
        }
        else
        {
            netGains = 0;
        }

        //Bar Functions
        scavBar.GetComponent<UnityEngine.UI.Slider>().value = marketplace.GetComponent<Store>().scavTimer;
        bsBar.GetComponent<UnityEngine.UI.Slider>().value = marketplace.GetComponent<Store>().bsTimer;
        farmsBar.GetComponent<UnityEngine.UI.Slider>().value = marketplace.GetComponent<Store>().farmstimer;
        wtBar.GetComponent<UnityEngine.UI.Slider>().value = marketplace.GetComponent<Store>().wtTimer;

        //Net Functions
        bsNet = marketplace.GetComponent<Store>().bsGain;
        farmsNet = marketplace.GetComponent<Store>().farmsGain;
        wtNet = marketplace.GetComponent<Store>().wtGain;

        if(playerManager.GetComponent<PlayerStats>().farms > 0)
        {
            farmsNetText.GetComponent<UnityEngine.UI.Text>().text = farmsNet.ToString();
        }

        if (playerManager.GetComponent<PlayerStats>().blacksmiths > 0)
        {
            bsNetText.GetComponent<UnityEngine.UI.Text>().text = bsNet.ToString();
        }

        if (playerManager.GetComponent<PlayerStats>().wizardTowers > 0)
        {
            wtNetText.GetComponent<UnityEngine.UI.Text>().text = wtNet.ToString();
        }

        //Merchant Arrival Time

        if( playerManager.GetComponent<PlayerStats>().money >= 1000)
        {
            merchTimer += Time.deltaTime;
        }

        if (merchTimer > merchDelay)
        {
            merch_leaveTimer += Time.deltaTime;
            merchantBtn.SetActive(true);

        }
        else
        {
            merchantBtn.SetActive(false);

        }

        if (merch_leaveTimer > merch_leaveDelay && marketplace.GetComponent<Store>().buying == false)
        {
            merchantBtn.SetActive(false);
            merchTimer = 0;
            merch_leaveTimer = 0;
        }

    }
}
