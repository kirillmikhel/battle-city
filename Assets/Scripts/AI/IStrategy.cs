using System.Collections;
using UnityEngine;

namespace AI
{
    public interface IStrategy
    {
        IEnumerator Run(Move move, Shooting shooting);
    }
}