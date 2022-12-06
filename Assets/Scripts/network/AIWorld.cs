using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using network.notify;
using network.service;
using UnityEngine;

namespace network
{
    public class AIWorld 
    {
        //延迟时间,根据排位得出,建议令牌抢占时间为500毫秒
        public float delayTime = 0.2f;


        /// <summary>
        /// AI得优先等级
        /// </summary>
        public int AILevel { get; set; }

        /// <summary>
        /// AI计算令牌
        /// </summary>
        public int AIID { get; set; }

        private bool _isStart = false;

        public bool ISStart
        {
            get { return _isStart; }
            private set { value = _isStart; }
        }

        public Action AICallback;
        public Action CommonCallback;

        public void setDelay(float delayTime)
        {
            this.delayTime = delayTime;
        }

        //AI计算间隔,建议为200毫秒,即正常为5帧/秒
        public float intervalTime = 0.2f;
        //public float TotalTime { get; set; }
        //public float LastTime { get; set; }

        public void setInterval(float intervalTime)
        {
            this.intervalTime = intervalTime;
        }

        public void start()
        {
            AIID = 0;
            AIAccumulateTime = 0;
            AILevel = 0;
            _isStart = true;
            ClientStart = Time.time;

            RoomNetService.ins.onAiIdChangedNotify(OnAIIDChanged);
            RoomNetService.ins.onAiLevelNotify(OnAILevelNotify);
        }

        /// <summary>
        /// AI计算累积的时间
        /// </summary>
        public float AIAccumulateTime { get; set; }

        public float curDeltaTime = 0f;

        private void OnAILevelNotify(int level)
        {
            //level = 500;
            AILevel = level;
            this.delayTime = level * .2f + intervalTime;
            Debug.Log("======================= delayTime:" + delayTime + " ==============================");
        }

        public float ClientStart { get; set; }
        public float ServerStart { get; set; }

        public float ServerTime
        {
            get
            {
                if (ClientStart == 0) return 0;
                return (Time.time - ClientStart) + ServerStart;
            }
        }

        private void OnAIIDChanged(int aicmdid, int serverTime)
        {
            AIID = aicmdid;
            AIAccumulateTime = 0;

            ServerStart = serverTime / 1000f;
            ClientStart = Time.time;
            //Debug.Log("===== aiid"+ AIID+" =====");
        }
        public void update(float deltaTime)
        {
            if (_isStart)
            {
                //TotalTime += deltaTime;
                AIAccumulateTime += deltaTime;
                curDeltaTime += deltaTime;
                if (AIAccumulateTime > delayTime)
                {
                    //Debug.Log("===== 重新获取AI令牌 =====");
                    AIAccumulateTime = float.MinValue;
                    RoomNetService.ins.reqAiId(AIID, AICallback.Invoke,
                        ((code, info) =>
                        {
                            Debug.LogError($"===== reqAiId fail AIID:{AIID},code:{code},info:{info} =====");
                        }));
                }
                //AIManager.Instance.ProcZombieStateMechine();
                CommonCallback?.Invoke();
            }
        }

        public void clear()
        {
            RoomNetService.ins.offAiIdChangedNotify();
            RoomNetService.ins.offAiLevelNotify();

            AICallback = null;
            CommonCallback = null;
            AIID = 0;
            AIAccumulateTime = 0;
            AILevel = 0;
            _isStart = false;
            ClientStart = 0;
        }
    }
}