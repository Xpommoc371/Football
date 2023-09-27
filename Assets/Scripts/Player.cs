using System;
using UnityEngine;
using UnityEngine.Events;

namespace ConsoleApp1
{
    public class Player
    {
        public string PlayerName { get;}
        public int PlayerNum { get; }

        public StateController playerState { get; set; }
        public UnityEvent OnGotBall = new UnityEvent();
        public UnityEvent OnKick = new UnityEvent();
        public UnityEvent OnScore = new UnityEvent();
        public UnityEvent OnPass = new UnityEvent();

        public Player (string name, int num)
        {
            PlayerName = name;
            PlayerNum = num;
            playerState = new StateController();
            playerState.Start();
            playerState.gotBall.AddListener(() => PlayerGotBall());
            playerState.kick.AddListener(() => KickTheBall());
            playerState.score.AddListener(() => ScoreTheBall());
            playerState.pass.AddListener(() => MakePass());
            playerState.miss.AddListener(() => MakePass());
            playerState.loseBall.AddListener(() => MakePass());
        }


        public void DoAction()
        {
            Debug.Log($"Player {PlayerName} taking action");
            playerState.Update();
        }

        private void PlayerGotBall()
        {
            OnGotBall.Invoke();
            Debug.Log($"Player #{PlayerNum} {PlayerName} got ball");
        }

        public void KickTheBall()
        {
            OnKick.Invoke();
            Debug.Log($"Player {PlayerName} kicked the ball");
        }

        public void MakePass()
        {
            OnPass.Invoke();
            Debug.Log($"Player {PlayerName} passes the ball");
        }


        public void ScoreTheBall()
        {
            OnScore.Invoke();
            Debug.Log($"Player {PlayerName} scores the ball!!! WHAT A SHOT!");
        }        
        public void Miss()
        {
            OnScore.Invoke();
            Debug.Log($"Player {PlayerName} misses!");
        }        
        public void LoseBall()
        {
            OnScore.Invoke();
            Debug.Log($"Player {PlayerName} lose the ball!");
        }
    }
}
