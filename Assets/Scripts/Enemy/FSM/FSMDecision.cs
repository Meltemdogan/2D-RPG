using UnityEngine;


namespace Enemy.FSM
{
    public abstract class FSMDecision : MonoBehaviour
    {
        public abstract bool Decide();
    }
}