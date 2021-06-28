using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public int maxSum;
    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI zText;

    private void OnEnable()
    {
        Timer.OnTimeOut += TimeIsOut;
        GenerateCalculation();
    }

    private void TimeIsOut()
    {
        //Check wheter another question is to be displayed
        
        GenerateCalculation();
    }

    private void GenerateCalculation()
    {
        Vector3 values = Calculation.Addition(maxSum);
        int calculationIndex = Random.Range(0, 3);
        // 0: x + ? = z
        // 1: x + y = ?
        // 2: ? + ? = z

        switch (calculationIndex)
        {
            case 0:
                xText.text = values.x.ToString();
                zText.text = values.z.ToString();
                break;
            case 1:
                xText.text = values.x.ToString();
                yText.text = values.y.ToString();
                break;
            case 2:
                zText.text = values.z.ToString();
                break;
        }
    }

    private void OnDisable()
    {
        Timer.OnTimeOut -= TimeIsOut;
    }
}
