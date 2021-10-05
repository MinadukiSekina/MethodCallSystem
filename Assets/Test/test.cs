
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Test
{
    public class test : UdonSharpBehaviour
    {
        [SerializeField] private UnityEngine.UI.Text text;

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
    }
}
