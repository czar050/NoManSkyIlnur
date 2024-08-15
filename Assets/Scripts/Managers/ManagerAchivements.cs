using UnityEngine;

public class ManagerAchivements : SingletonManager<ManagerAchivements>
{
    private void OnEnable()
    {
        ManagerScore.Instance.OnNewScore += CheckAchivements;
    }

    private void OnDisable()
    {
        ManagerScore.Instance.OnNewScore -= CheckAchivements;
    }

    private void CheckAchivements(int newScore)
    {
        if (newScore > 10)
        {
            Debug.Log("Win");
        }
    }
}
