using System;
using UnityEngine;
namespace Enemy.FSM
{
    [Serializable]
    public class FSMTransition 
    {
        public FSMDecision Decision;
        public string TrueState;
        public string FalseState;
    }
}