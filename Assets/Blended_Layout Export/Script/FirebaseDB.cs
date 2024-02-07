using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[Serializable]
public class FirebaseDB
{
    public List<string> attempt;

    public FirebaseDB(List<string> values)
    {
        attempt = values;
    }
}