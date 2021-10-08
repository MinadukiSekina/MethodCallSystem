
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Test
{
    public class Sample : UdonSharpBehaviour
    {
        [SerializeField] private UnityEngine.UI.Text timeText;
        [SerializeField] private UnityEngine.UI.Text noteText;
        [SerializeField] private UnityEngine.UI.Text enterText;
        [SerializeField] private Minadukitei.Products.When_JoinLeft when_JoinLeft;
        [SerializeField] private Minadukitei.Products.Timer timer;
        [SerializeField] private GameObject targetObject;
        private Animator targetAnimator;

        public void Start()
        {
            timer.SendCustomEvent("TimerStart");
            targetAnimator = targetObject.GetComponent<Animator>();
        }

        public void TimeUpdate()
        {
            timeText.text = System.DateTime.Now.ToLongTimeString();
        }

        public void JoinNotification()
        {
            noteText.text += $"\nJoin : {when_JoinLeft.playerApi.displayName}";
        }

        public void LeftNotification()
        {
            noteText.text += $"\nLeave : {when_JoinLeft.playerApi.displayName}";
        }

        public void PickUped()
        {
            targetAnimator.SetInteger("Color", 1);
        }

        public void Dropped()
        {
            targetAnimator.SetInteger("Color", 0);
        }

        public void PickUpUseDown()
        {
            targetAnimator.SetInteger("Color", 2);
        }

        public void PickUpUseUp()
        {
            targetAnimator.SetInteger("Color", 1);
        }

        public void PlayerEntered()
        {
            enterText.text = "Player entered";
        }

        public void PlayerStay()
        {
            enterText.text = "Player stay";
        }

        public void PlayerLeft()
        {
            enterText.text = "Player Left";
        }
    }
}
