using Assets.Client.Scripts.MainGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.View
{
    public class InputController : MonoBehaviour
    {
        private const string InputControllerName = "InputController";
        private const string HorizontalInputKey = "Horizontal";
        private const string VerticalInputKey = "Vertical";

        private static InputController instance;
        public static InputController Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameObject(InputControllerName).AddComponent<InputController>();

                return instance;
            }
        }

        [SerializeField]
        private float vertical, horizontal;

        public Direction GetDirection()
        {
            Direction direction = Direction.None;

            if (vertical > 0)
                direction = Direction.Up;
            else if (vertical < 0)
                direction = Direction.Down;
            else if (horizontal > 0)
                direction = Direction.Right;
            else if (horizontal < 0)
                direction = Direction.Left;

            return direction;
        }

        private void Update()
        {
            vertical = Input.GetAxis(VerticalInputKey);
            horizontal = Input.GetAxis(HorizontalInputKey);
        }

    }
}