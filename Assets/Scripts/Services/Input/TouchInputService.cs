using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public class TouchInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}