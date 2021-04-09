using System;
using UnityEngine;


namespace CustomEvents
{
    public class PlayerControllerEvents : IEventStorage
    {
        public Action<Vector3> OnPlayerMoving;
    }
}