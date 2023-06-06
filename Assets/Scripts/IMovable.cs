using System;
using UnityEngine;

namespace SpaceMadness
{
    public interface IMovable
    {
        public void Move(Vector2 direction);
        public void ChangeSpeed(float multiplier, bool useDefault = true);
        public float GetSpeed(bool useDefault = true);
    }
}