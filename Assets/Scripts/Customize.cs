using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Customize : MonoBehaviour
{
    public Button back;

    public Button nextBall;
    public Button previousBall;
    public Button purchaseBall;
    public Button selectBall;

    public Button nextNet;
    public Button previousNet;
    public Button purchaseNet;
    public Button selectNet;

    public Button nextFloor;
    public Button previousFloor;
    public Button purchaseFloor;
    public Button selectFloor;

    public Text coins;
    public Image ball;
    public Image net;
    public Image floor;
    public Sprite purchase;
    public Sprite selected;
    public int ballIndex = 0;
    public int netIndex = 0;
    public int floorIndex = 0;
    public int numSkins;
    public int purchasedBalls = 1;
    public int purchasedNets = 1;
    public int purchasedFloors = 1;

    public Sprite[] balls;
    public Sprite basketBall;
    public Sprite tennisBall;
    public Sprite soccerBall;
    public Sprite bowlingBall;
    public Sprite volleyBall;

    public Sprite[] nets;
    public Sprite netOne;
    public Sprite netTwo;
    public Sprite netThree;
    public Sprite netFour;
    public Sprite netFive;

    public Sprite[] floors;
    public Sprite floorOne;
    public Sprite floorTwo;
    public Sprite floorThree;
    public Sprite floorFour;
    public Sprite floorFive;

    public Color[] ballColor;
    public Material ballMaterial;
    public Color basketBallColor;
    public Color tennisBallColor;
    public Color soccerBallColor;
    public Color bowlingBallColor;
    public Color volleyBallColor;

    public bool[] purchasedBall;
    public bool basketBallPurchased;
    public bool tennisBallPurchased;
    public bool soccerBallPurchased;
    public bool bowlingBallPurchased;
    public bool volleyBallPurchased;

    public bool[] purchasedNet;
    public bool netOnePurchased;
    public bool netTwoPurchased;
    public bool netThreePurchased;
    public bool netFourPurchased;
    public bool netFivePurchased;

    public bool[] purchasedFloor;
    public bool floorOnePurchased;
    public bool floorTwoPurchased;
    public bool floorThreePurchased;
    public bool floorFourPurchased;
    public bool floorFivePurchased;

    public bool[] selectedBall;
    public bool basketBallSelected;
    public bool tennisBallSelected;
    public bool soccerBallSelected;
    public bool bowlingBallSelected;
    public bool volleyBallSelected;

    public bool[] selectedNet;
    public bool netOneSelected;
    public bool netTwoSelected;
    public bool netThreeSelected;
    public bool netFourSelected;
    public bool netFiveSelected;

    public bool[] selectedFloor;
    public bool floorOneSelected;
    public bool floorTwoSelected;
    public bool floorThreeSelected;
    public bool floorFourSelected;
    public bool floorFiveSelected;

    public Text insufficientCoins;
    public byte a = 0;
    public bool noCoins;

    public Button freeCoins;

    void Start()
    {
        freeCoins.gameObject.SetActive(false);

        numSkins = 5;

        balls = new Sprite[numSkins];
        balls[0] = basketBall;
        balls[1] = tennisBall;
        balls[2] = soccerBall;
        balls[3] = bowlingBall;
        balls[4] = volleyBall;

        nets = new Sprite[numSkins];
        nets[0] = netOne;
        nets[1] = netTwo;
        nets[2] = netThree;
        nets[3] = netFour;
        nets[4] = netFive;

        floors = new Sprite[numSkins];
        floors[0] = floorOne;
        floors[1] = floorTwo;
        floors[2] = floorThree;
        floors[3] = floorFour;
        floors[4] = floorFive;

        ballColor = new Color[numSkins];
        basketBallColor = new Color32(222, 101, 5, 255);
        tennisBallColor = new Color32(224, 254, 107, 255);
        soccerBallColor = new Color32(255, 255, 255, 255);
        bowlingBallColor = new Color32(12, 78, 154, 255);
        volleyBallColor = new Color32(234, 237, 221, 255);
        ballColor[0] = basketBallColor;
        ballColor[1] = tennisBallColor;
        ballColor[2] = soccerBallColor;
        ballColor[3] = bowlingBallColor;
        ballColor[4] = volleyBallColor;

        purchasedBall = new bool[numSkins];
        purchasedBall[0] = basketBallPurchased;
        purchasedBall[1] = tennisBallPurchased;
        purchasedBall[2] = soccerBallPurchased;
        purchasedBall[3] = bowlingBallPurchased;
        purchasedBall[4] = volleyBallPurchased;

        purchasedNet = new bool[numSkins];
        purchasedNet[0] = netOnePurchased;
        purchasedNet[1] = netTwoPurchased;
        purchasedNet[2] = netThreePurchased;
        purchasedNet[3] = netFourPurchased;
        purchasedNet[4] = netFivePurchased;

        purchasedFloor = new bool[numSkins];
        purchasedFloor[0] = floorOnePurchased;
        purchasedFloor[1] = floorTwoPurchased;
        purchasedFloor[2] = floorThreePurchased;
        purchasedFloor[3] = floorFourPurchased;
        purchasedFloor[4] = floorFivePurchased;

        selectedBall = new bool[numSkins];
        selectedBall[0] = basketBallSelected;
        selectedBall[1] = tennisBallSelected;
        selectedBall[2] = soccerBallSelected;
        selectedBall[3] = bowlingBallSelected;
        selectedBall[4] = volleyBallSelected;

        selectedNet = new bool[numSkins];
        selectedNet[0] = netOneSelected;
        selectedNet[1] = netTwoSelected;
        selectedNet[2] = netThreeSelected;
        selectedNet[3] = netFourSelected;
        selectedNet[4] = netFiveSelected;

        selectedFloor = new bool[numSkins];
        selectedFloor[0] = floorOneSelected;
        selectedFloor[1] = floorTwoSelected;
        selectedFloor[2] = floorThreeSelected;
        selectedFloor[3] = floorFourSelected;
        selectedFloor[4] = floorFiveSelected;

        ballIndex = PlayerPrefs.GetInt("CurrentBall");
        netIndex = PlayerPrefs.GetInt("CurrentNet");
        floorIndex = PlayerPrefs.GetInt("CurrentFloor");
        purchasedBall[ballIndex] = true;
        selectedBall[ballIndex] = true;
        purchasedNet[netIndex] = true;
        selectedNet[netIndex] = true;
        purchasedFloor[floorIndex] = true;
        selectedFloor[floorIndex] = true;
        purchasedBalls = PlayerPrefs.GetInt("BallAvailability");
        purchasedNets = PlayerPrefs.GetInt("NetAvailability");
        purchasedFloors = PlayerPrefs.GetInt("FloorAvailability");

        Button backBtn = back.GetComponent<Button>();
        back.onClick.AddListener(BackButtonClick);
        Button nextBallBtn = nextBall.GetComponent<Button>();
        nextBall.onClick.AddListener(NextBallButtonClick);
        Button previousBallBtn = previousBall.GetComponent<Button>();
        previousBall.onClick.AddListener(PreviousBallButtonClick);
        Button purchaseBallBtn = purchaseBall.GetComponent<Button>();
        purchaseBall.onClick.AddListener(PurchaseBallButtonClick);
        Button selectBallBtn = selectBall.GetComponent<Button>();
        selectBall.onClick.AddListener(SelectBallButtonClick);
        Button nextNetBtn = nextNet.GetComponent<Button>();
        nextNet.onClick.AddListener(NextNetButtonClick);
        Button previousNetBtn = previousNet.GetComponent<Button>();
        previousNet.onClick.AddListener(PreviousNetButtonClick);
        Button purchaseNetBtn = purchaseNet.GetComponent<Button>();
        purchaseNet.onClick.AddListener(PurchaseNetButtonClick);
        Button selectNetBtn = selectNet.GetComponent<Button>();
        selectNet.onClick.AddListener(SelectNetButtonClick);
        Button nextFloorBtn = nextFloor.GetComponent<Button>();
        nextFloor.onClick.AddListener(NextFloorButtonClick);
        Button previousFloorBtn = previousFloor.GetComponent<Button>();
        previousFloor.onClick.AddListener(PreviousFloorButtonClick);
        Button purchaseFloorBtn = purchaseFloor.GetComponent<Button>();
        purchaseFloor.onClick.AddListener(PurchaseFloorButtonClick);
        Button selectFloorBtn = selectFloor.GetComponent<Button>();
        selectFloor.onClick.AddListener(SelectFloorButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        if ((PlayerPrefs.GetInt("BallAvailability") & 1 << ballIndex) == 1 << ballIndex)
        {
            purchasedBall[ballIndex] = true;
        }
        if ((PlayerPrefs.GetInt("NetAvailability") & 1 << netIndex) == 1 << netIndex)
        {
            purchasedNet[netIndex] = true;
        }
        if ((PlayerPrefs.GetInt("FloorAvailability") & 1 << floorIndex) == 1 << floorIndex)
        {
            purchasedFloor[floorIndex] = true;
        }
        ball.sprite = balls[ballIndex];
        net.sprite = nets[netIndex];
        floor.sprite = floors[floorIndex];
        ballMaterial.color = ballColor[ballIndex];
        if (purchasedBall[ballIndex] == false)
        {
            selectBall.gameObject.SetActive(false);
            purchaseBall.gameObject.SetActive(true);
            purchaseBall.interactable = true;
            purchaseBall.image.sprite = purchase;

        }
        else
        {
            if (selectedBall[ballIndex] == true)
            {
                selectBall.gameObject.SetActive(false);
                purchaseBall.gameObject.SetActive(true);
                purchaseBall.image.sprite = selected;
                purchaseBall.interactable = false;
            }
            else
            {
                purchaseBall.interactable = true;
                purchaseBall.gameObject.SetActive(false);
                selectBall.gameObject.SetActive(true);
            }
        }

        if (purchasedNet[netIndex] == false)
        {
            selectNet.gameObject.SetActive(false);
            purchaseNet.gameObject.SetActive(true);
            purchaseNet.interactable = true;
            purchaseNet.image.sprite = purchase;

        }
        else
        {
            if (selectedNet[netIndex] == true)
            {
                selectNet.gameObject.SetActive(false);
                purchaseNet.gameObject.SetActive(true);
                purchaseNet.image.sprite = selected;
                purchaseNet.interactable = false;
            }
            else
            {
                purchaseNet.interactable = true;
                purchaseNet.gameObject.SetActive(false);
                selectNet.gameObject.SetActive(true);
            }
        }

        if (purchasedFloor[floorIndex] == false)
        {
            selectFloor.gameObject.SetActive(false);
            purchaseFloor.gameObject.SetActive(true);
            purchaseFloor.interactable = true;
            purchaseFloor.image.sprite = purchase;

        }
        else
        {
            if (selectedFloor[floorIndex] == true)
            {
                selectFloor.gameObject.SetActive(false);
                purchaseFloor.gameObject.SetActive(true);
                purchaseFloor.image.sprite = selected;
                purchaseFloor.interactable = false;
            }
            else
            {
                purchaseFloor.interactable = true;
                purchaseFloor.gameObject.SetActive(false);
                selectFloor.gameObject.SetActive(true);
            }
        }

        if (noCoins == true)
        {
            a += 15;
            insufficientCoins.color = new Color32(255, 0, 0, a);
        }

    }

    void BackButtonClick()
    {
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        SceneManager.LoadScene(0);

    }
    void NextBallButtonClick()
    {

        if (ballIndex < numSkins)
        {
            ballIndex++;
        }
        if (ballIndex > numSkins-1)
        {
            ballIndex = 0;
        }
    }
    void PreviousBallButtonClick()
    {
        if (ballIndex >= 0)
        {
            ballIndex--;
        }
        if(ballIndex < 0)
        {
            ballIndex = numSkins-1;
        }
    }

    void PurchaseBallButtonClick()
    {
        if(PlayerPrefs.GetInt("Coins") >= 20) { 
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            purchasedBall[ballIndex] = true;
            purchasedBalls += 1 << ballIndex;
            PlayerPrefs.SetInt("BallAvailability", purchasedBalls);
            selectBall.gameObject.SetActive(true);
            purchaseBall.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(InsufficentCoins("Insufficent Coins", 1.5f));

        }
    }

    void SelectBallButtonClick()
    {
        selectedBall[ballIndex] = true;
        PlayerPrefs.SetInt("CurrentBall", ballIndex);
        selectBall.gameObject.SetActive(false);
        purchaseBall.gameObject.SetActive(true);
        purchaseBall.image.sprite = selected;
        purchaseBall.interactable = false;
        for (int y = 0; y < ballIndex; y++)
        {
            selectedBall[y] = false;
        }
        for (int y = ballIndex+1; y > ballIndex; y++)
        {
            selectedBall[y] = false;
        }

    }

    void NextNetButtonClick()
    {

        if (netIndex < numSkins)
        {
            netIndex++;
        }
        if (netIndex > numSkins - 1)
        {
            netIndex = 0;
        }
    }
    void PreviousNetButtonClick()
    {
        if (netIndex >= 0)
        {
            netIndex--;
        }
        if (netIndex < 0)
        {
            netIndex = numSkins - 1;
        }
    }

    void PurchaseNetButtonClick()
    {
        if (PlayerPrefs.GetInt("Coins") >= 20)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            purchasedNet[netIndex] = true;
            purchasedNets += 1 << netIndex;
            PlayerPrefs.SetInt("NetAvailability", purchasedNets);
            selectNet.gameObject.SetActive(true);
            purchaseNet.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(InsufficentCoins("Insufficent Coins", 1.5f));
        }
    }

    void SelectNetButtonClick()
    {
        selectedNet[netIndex] = true;
        PlayerPrefs.SetInt("CurrentNet", netIndex);
        selectNet.gameObject.SetActive(false);
        purchaseNet.gameObject.SetActive(true);
        purchaseNet.image.sprite = selected;
        purchaseNet.interactable = false;
        for (int y = 0; y < netIndex; y++)
        {
            selectedNet[y] = false;
        }
        for (int y = netIndex + 1; y > netIndex; y++)
        {
            selectedNet[y] = false;
        }

    }

    void NextFloorButtonClick()
    {

        if (floorIndex < numSkins)
        {
            floorIndex++;
        }
        if (floorIndex > numSkins - 1)
        {
            floorIndex = 0;
        }
    }
    void PreviousFloorButtonClick()
    {
        if (floorIndex >= 0)
        {
            floorIndex--;
        }
        if (floorIndex < 0)
        {
            floorIndex = numSkins - 1;
        }
    }

    void PurchaseFloorButtonClick()
    {
        if (PlayerPrefs.GetInt("Coins") >= 20)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            purchasedFloor[floorIndex] = true;
            purchasedFloors += 1 << floorIndex;
            PlayerPrefs.SetInt("FloorAvailability", purchasedFloors);
            selectFloor.gameObject.SetActive(true);
            purchaseFloor.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(InsufficentCoins("Insufficent Coins", 1.5f));
        }
    }

    void SelectFloorButtonClick()
    {
        selectedFloor[floorIndex] = true;
        PlayerPrefs.SetInt("CurrentFloor", floorIndex);
        selectFloor.gameObject.SetActive(false);
        purchaseFloor.gameObject.SetActive(true);
        purchaseFloor.image.sprite = selected;
        purchaseFloor.interactable = false;
        for (int y = 0; y < floorIndex; y++)
        {
            selectedFloor[y] = false;
        }
        for (int y = floorIndex + 1; y > floorIndex; y++)
        {
            selectedFloor[y] = false;
        }

    }

    IEnumerator InsufficentCoins(string message, float delay)
    {
        insufficientCoins.text = message;
        noCoins = true;
        yield return new WaitForSeconds(delay);
        noCoins = false;
        insufficientCoins.color = new Color32(255, 0, 0, 0);
    }

}
