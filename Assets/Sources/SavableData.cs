[System.Serializable]
public class ScoreData 
{
    public int MaximumScore;

    public ScoreData(int MaximumScore)
    {
        this.MaximumScore = MaximumScore;
    }

    public ScoreData(ScoreData scoreData)
    {
        this.MaximumScore = scoreData.MaximumScore;
    }
}
