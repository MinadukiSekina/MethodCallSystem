
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Test
{
    public class test : UdonSharpBehaviour
    {
        [SerializeField] private UnityEngine.UI.Text text;
        [SerializeField] private Minadukitei.Products.When_JoinLeft joinLeft;

        public void PickUp()
        {
            text.text = $"{nameof(PickUp)}";
        }

        public void Drop()
        {
            text.text = $"{nameof(Drop)}";
        }

        public void UseDown()
        {
            text.text = $"{nameof(UseDown)}";
        }

        public void UseUp()
        {
            text.text = $"{nameof(UseUp)}";
        }

        public void Interacted()
        {
            text.text = $"{nameof(Interacted)}";
        }

        //public override void OnPlayerJoined(VRCPlayerApi player)
        //{
        //    text.text += $"\n{nameof(OnPlayerJoined)}:{player.displayName}";
        //}
        //public override void OnPlayerLeft(VRCPlayerApi player)
        //{
        //    text.text += $"\n{nameof(OnPlayerLeft)}:{player.displayName}";
        //}
        public void Start()
        {
            text.text += $"\n{nameof(Start)}";
        }

        public void Join()
        {
            text.text += $"\n{nameof(OnPlayerJoined)}:{joinLeft.playerApi.displayName}";
        }

        public void Left()
        {
            text.text += $"\n{nameof(OnPlayerLeft)}:{joinLeft.playerApi.displayName}";
        }
    }
}
