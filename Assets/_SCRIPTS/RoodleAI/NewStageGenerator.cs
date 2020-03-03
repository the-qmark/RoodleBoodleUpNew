using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _newStageTemplate;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(_newStageTemplate, transform.position, transform.rotation);
        }
    }

    public void CreateNewStage()
    {
        Destroy(Instantiate(_newStageTemplate, transform.position, transform.rotation), 20f);
    }
}
