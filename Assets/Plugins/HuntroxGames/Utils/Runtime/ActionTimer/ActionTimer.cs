using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HuntroxGames.Utils
{
    public class ActionTimer
    {
        private readonly float timer = 5;

        public float TimeLeft => timerCountDown;
        
        private float timerCountDown = 0;
        private readonly bool useUnscaledDeltaTime = false;
        private readonly bool repeat = false;

        
        private Action<ActionTimer> onUpdateEvent;
        private Action<ActionTimer> onCompleteEvent;
        private Action<ActionTimer> onRestartEvent;
        private Action<ActionTimer> onCleanupEvent;
        private bool started; 

        public ActionTimer(float timer, bool repeat = false, bool useUnscaledDeltaTime = false)
        {
            this.timer = timer;
            this.repeat = repeat;
            this.useUnscaledDeltaTime = useUnscaledDeltaTime;
        }


        internal void DoUpdate()
        {
            if (!started) return;
            var time = useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
            if (timerCountDown > 0)
            {
                timerCountDown -= time;
                onUpdateEvent?.Invoke(this);
            }

            if (timerCountDown <= 0)
            {
                timerCountDown = 0;
                onCompleteEvent?.Invoke(this);
                if (repeat)
                {
                    timerCountDown = timer;
                    onRestartEvent?.Invoke(this);
                }
                else
                    CleanUp();
            }
        }


        internal void CleanUp()
        {
            onCleanupEvent?.Invoke(this);
            TimerManager.Instance.RemoverTimer(this);
        }

        public void Start()
        {
            timerCountDown = timer;
            TimerManager.Instance.AddTimer(this);
            started = true;
        }

        public ActionTimer OnUpdate(Action<ActionTimer> updateListener)
        {
            onUpdateEvent += updateListener;
            return this;
        }

        public ActionTimer OnComplete(Action<ActionTimer> onCompleteListener)
        {
            onCompleteEvent += onCompleteListener;
            return this;
        }

        public ActionTimer OnRestart(Action<ActionTimer> onRestartListener)
        {
            onRestartEvent += onRestartListener;
            return this;
        }

        public ActionTimer OnCleanup(Action<ActionTimer> cleanupListener)
        {
            onCleanupEvent += cleanupListener;
            return this;
        }
    }
}