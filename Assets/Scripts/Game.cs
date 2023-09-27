using UnityEngine;
using ConsoleApp1;

public enum Turn { Team1, Team2 }

public class Game : MonoBehaviour
{
    public string TeamName1;
    public string TeamName2;

    public string[] PlayersTeam1 = new string[11];
    public string[] PlayersTeam2 = new string[11];

    private Team team1, team2;
    
    private void Start()
    {
        team1 = new Team(TeamName1, PlayersTeam1);
        team2 = new Team(TeamName2, PlayersTeam2);
        team1.OnTeamScore.AddListener(() => UpdateScore());
        team2.OnTeamScore.AddListener(() => UpdateScore());

        Debug.Log($"Starting Game Between {team1.TeamName } and {team2.TeamName}");
        Debug.Log($"{team1.TeamName } turn ");
        team1.DoTeamMove();
        Debug.Log($"{team2.TeamName } turn ");
        team2.DoTeamMove();
    }

    private void UpdateScore()
    {
        Debug.Log($"{team1.TeamName } - {team2.TeamName} \n {team1.TeamScore} : {team2.TeamScore} ");
    }
}
