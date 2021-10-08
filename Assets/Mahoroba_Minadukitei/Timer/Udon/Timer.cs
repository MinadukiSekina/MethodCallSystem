
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class Timer : UdonSharpBehaviour
    {
        [Tooltip("処理を実行するUdon")]
        [SerializeField] private UdonBehaviour otherBehaviour;
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool delayCallIsGlobal;
        [Tooltip("呼び出し時の通知先。delayCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget delayCallNetworkTarget;
        [Tooltip("指定間隔で実行する処理の名前。()は不要です。")]
        [SerializeField] private string delayMethodName;
        [Tooltip("遅延する秒数。0の場合は何もしません。")]
        [SerializeField] private float delaySeconds;

        // flag of stop
        private bool timerStop = false;

        public void TimerStart()
        {
            if (delaySeconds <= 0) return;
            DoDelayedSeconds();
        }

        public void TimerStop()
        {
            timerStop = true;
        }

        public void DoDelayedSeconds()
        {
            // If flag is true, timer should stop and initialize.
            if (timerStop)
            {
                timerStop = false;
                return;
            }

            if (delayCallIsGlobal)
            {
                otherBehaviour.SendCustomNetworkEvent(delayCallNetworkTarget, delayMethodName);
            }
            else
            {
                otherBehaviour.SendCustomEvent(delayMethodName);
            }

            SendCustomEventDelayedSeconds(nameof(DoDelayedSeconds), delaySeconds);
        }
    }
}
