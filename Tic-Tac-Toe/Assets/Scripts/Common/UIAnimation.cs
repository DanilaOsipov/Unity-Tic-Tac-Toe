using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public abstract class UIAnimation : MonoBehaviour
    {
        public abstract void Play(Action callback);
    }
}