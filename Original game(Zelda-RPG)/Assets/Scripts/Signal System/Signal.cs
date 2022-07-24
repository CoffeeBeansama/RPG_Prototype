using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Samurai
{
[CreateAssetMenu]
public class Signal : ScriptableObject
{

    public List<SignalListener> listeners = new List<SignalListener>();
    
    public void Raise()
    {
        
    }
}
}