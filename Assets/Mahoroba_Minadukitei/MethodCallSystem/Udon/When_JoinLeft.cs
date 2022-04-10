
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class When_JoinLeft : UdonSharpBehaviour
    {

        [Tooltip("処理を実行するUdon")]
        [SerializeField] private UdonBehaviour otherBehaviour;

        [Header("プレイヤーがワールドにJoinした時")]
        [Tooltip("チェック時、JoinしたプレイヤーがLocalか判断します。")]
        [SerializeField] private bool joinedPlayerLocalCheck = true;
        [Tooltip("チェック時、JoinしたプレイヤーがLocalなら処理を呼び出しません。joinedPlayerLocalCheckがチェックされている場合のみ有効")]
        [SerializeField] private bool exceptLocalPlayerJoin = true;
        [Tooltip("チェック時、JoinしたプレイヤーがRemoteなら処理を呼び出しません。joinedPlayerLocalCheckがチェックされている場合のみ有効")]
        [SerializeField] private bool exceptRemotePlayerJoin = false;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string joinedCallMethodName;

        [Header("プレイヤーがワールドを離れた時")]
        [Tooltip("チェック時、離れたプレイヤーがLocalか判断します。")]
        [SerializeField] private bool leftPlayerLocalCheck = true;
        [Tooltip("チェック時、離れたプレイヤーがLocalなら処理を呼び出しません。leftPlayerLocalCheckがチェックされている場合のみ有効")]
        [SerializeField] private bool exceptLocalPlayerLeft = true;
        [Tooltip("チェック時、離れたプレイヤーがRemoteなら処理を呼び出しません。leftPlayerLocalCheckがチェックされている場合のみ有効")]
        [SerializeField] private bool exceptRemotePlayerLeft = false;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string LeftCallMethodName;

        [HideInInspector] public VRCPlayerApi playerApi;

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            // Check the join player is local. 
            if (joinedPlayerLocalCheck)
            {
                if (exceptLocalPlayerJoin && player.isLocal) return;
                if (exceptRemotePlayerJoin && !player.isLocal) return;
            }

            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(joinedCallMethodName)) return;

            playerApi = player;
            otherBehaviour.SendCustomEvent(joinedCallMethodName);
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            // Check the Left player is local. 
            if (leftPlayerLocalCheck)
            {
                if (exceptLocalPlayerLeft && player.isLocal) return;
                if (exceptRemotePlayerLeft && !player.isLocal) return;
            }

            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(LeftCallMethodName)) return;

            playerApi = player;
            otherBehaviour.SendCustomEvent(LeftCallMethodName);
        }
    }
}
