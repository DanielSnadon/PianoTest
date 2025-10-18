using TMPro;
using UnityEngine;

public class ResultCounter : MonoBehaviour
{
    public TMP_Text overallText;
    public TMP_Text perfectText;
    public TMP_Text goodText;
    public TMP_Text okayText;
    public TMP_Text missedText;
    public int perfectsCount;
    public int goodsCount;
    public int okaysCount;
    public int missesCount;
    public int overall;

    public void resetAllCounts()
    {
        overall = 0;
        perfectsCount = 0;
        goodsCount = 0;
        okaysCount = 0;
        missesCount = 0;

        updateOverallText();
        updatePerfectText();
        updateGoodText();
        updateOkayText();
        updateMissText();
    }
    public void updateOverallText()
    {
        overallText.text = $"Overall Notes - {overall}";
    }

    public void updatePerfectText()
    {
        perfectText.text = $"Perfect - {perfectsCount}";
    }
    public void updateGoodText()
    {
        goodText.text = $"Good - {goodsCount}";
    }
    public void updateOkayText()
    {
        okayText.text = $"Okay - {okaysCount}";
    }
        public void updateMissText()
    {
        missedText.text = $"Missed - {missesCount}";
    }
}
