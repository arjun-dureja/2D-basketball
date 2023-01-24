using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public SpriteRenderer ball;
    public SpriteRenderer net;
    public SpriteRenderer floor;

    public Sprite[] ballSkins;
    public Sprite basketBall;
    public Sprite tennisBall;
    public Sprite soccerBall;
    public Sprite bowlingBall;
    public Sprite volleyBall;

    public Sprite[] netSkins;
    public Sprite netOne;
    public Sprite netTwo;
    public Sprite netThree;
    public Sprite netFour;
    public Sprite netFive;

    public Sprite[] floorSkins;
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

    void Start()
    {
        ballSkins = new Sprite[5];
        ballSkins[0] = basketBall;
        ballSkins[1] = tennisBall;
        ballSkins[2] = soccerBall;
        ballSkins[3] = bowlingBall;
        ballSkins[4] = volleyBall;
        ball.sprite = ballSkins[PlayerPrefs.GetInt("CurrentBall")];

        netSkins = new Sprite[5];
        netSkins[0] = netOne;
        netSkins[1] = netTwo;
        netSkins[2] = netThree;
        netSkins[3] = netFour;
        netSkins[4] = netFive;
        net.sprite = netSkins[PlayerPrefs.GetInt("CurrentNet")];

        floorSkins = new Sprite[5];
        floorSkins[0] = floorOne;
        floorSkins[1] = floorTwo;
        floorSkins[2] = floorThree;
        floorSkins[3] = floorFour;
        floorSkins[4] = floorFive;
        floor.sprite = floorSkins[PlayerPrefs.GetInt("CurrentFloor")];

        ballColor = new Color[5];
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
        ballMaterial.color = ballColor[PlayerPrefs.GetInt("CurrentBall")];
    }
}
