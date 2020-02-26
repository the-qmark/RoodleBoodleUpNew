using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoController : MonoBehaviour
{
    private List<AutoMoveData> _autoMoveData; 
    
    
    public void AddNewData(Quaternion _rotation, Vector3 _position)
    {
        _autoMoveData.Add(new AutoMoveData(_rotation, _position));
    }

    private void Update()
    {
        
    }


}
