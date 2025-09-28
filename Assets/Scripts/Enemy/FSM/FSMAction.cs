using UnityEngine;
namespace Enemy.FSM
{
    public abstract class FSMAction : MonoBehaviour
    {
        public abstract void Act();
    }
}