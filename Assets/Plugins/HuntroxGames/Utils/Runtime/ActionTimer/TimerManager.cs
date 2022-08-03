using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HuntroxGames.Utils
{
    public class TimerManager : Singleton<TimerManager>
    {
        private List<ActionTimer> timers = new List<ActionTimer>();
        
        private Queue<ActionTimer> queueForRemoval = new Queue<ActionTimer>();
        private Queue<ActionTimer> queueForAdding = new Queue<ActionTimer>();
        protected override void Awake()
        {
            base.Awake();
            
        }

        private void Update()
        {
            foreach (var timer in timers)
                timer.DoUpdate();
            
            //remove cleaned up timers
            var removalCount = queueForRemoval.Count;
            for (int i = 0; i < removalCount; i++)
            {
                var timer = queueForRemoval.Dequeue();
                if (timers.Contains(timer))
                    timers.Remove(timer);
            }
            
            //add new timers
            var addCount = queueForAdding.Count;
            for (int i = 0; i < addCount; i++)
            {
                var timer = queueForAdding.Dequeue();
                if (!timers.Contains(timer))
                    timers.Add(timer);
            }
        }

        public void RemoverTimer(ActionTimer actionTimer)
        {
            if(timers.Contains(actionTimer))
                queueForRemoval.Enqueue(actionTimer);
        }

        public void AddTimer(ActionTimer actionTimer)
        {
            if(!timers.Contains(actionTimer))
                queueForAdding.Enqueue(actionTimer);
        }
    }
}