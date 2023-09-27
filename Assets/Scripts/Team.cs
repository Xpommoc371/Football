using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ConsoleApp1
{
    public class Team
    {
        private string _teamName = "";
        private bool hasBall = false;
        private int score = 0;

        public string TeamName { get { return _teamName; } }
        public List<Player> players = new List<Player>();
        public int TeamScore { get { return score; } }
        public UnityEvent OnTeamScore = new UnityEvent();

        public void AddPlayer(Player player)
        {
            players.Add(player);
            player.OnGotBall.AddListener(() => OnGotBall());
            player.OnPass.AddListener(() => OnPass());
            player.OnScore.AddListener(() => OnScore());
        }

        public Team(string teamName, string[] playersNames)
        {
            _teamName = teamName;
            for(int i = 00; i < playersNames.Length; i++)
            {
                Player fieldPlayer = new Player(playersNames[i], i);
                AddPlayer(fieldPlayer);
            }
        }
        private void OnGotBall()
        {
            hasBall = true;
        }

        private void OnPass()
        {
            int randomPlayerNum = Random.Range(0, players.Count);
            Player randPlayer = players[randomPlayerNum];
            StateController playerController = randPlayer.playerState;
            playerController.ChangeState(playerController.hasBall);
        }

        private void OnScore()
        {
            score++;
            OnTeamScore.Invoke();
        }

        public void DoTeamMove()
        {
            for(int i = 0; i < players.Count; i++)
            {
                players[i].DoAction();
                if (hasBall) break;
            }
        }
    }
}
