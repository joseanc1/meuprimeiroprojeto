using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void CleartData()
    {
        SaveController.Instance.ClearSave();
    }
}
