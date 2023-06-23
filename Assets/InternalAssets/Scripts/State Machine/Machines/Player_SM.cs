
using UnityEngine;
using StateManager;

    public class Player_SM: MonoBehaviour
    {
        private StateMachine _SM;

        private void InitStates()
        {
            _SM = new StateMachine();
        }
        
        private void Awake()
        {
            InitStates();
        }

        private void Update()
        {
            _SM.CurrentState.Update();
        }
    }