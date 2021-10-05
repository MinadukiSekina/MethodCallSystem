
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class When_Interact : UdonSharpBehaviour
    {
        [Tooltip("処理を実行するUdon")]
        [SerializeField] private UdonBehaviour otherBehaviour;

        [Header("プレイヤーが触れた時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool interactedCallIsGlobal;
        [Tooltip("呼び出し時の通知先。interactedCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget interactedCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string interactedCallMethodName;

        public override void Interact()
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(interactedCallMethodName)) return;

            if (interactedCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(interactedCallNetworkTarget, interactedCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(interactedCallMethodName);
            }
        }
    }
}
