using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    [SerializeField] private Material _fontMaterial;
    
    [SerializeField] private List<GameObject> _letters = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var letter in _letters)
        {
            if (DataStorage.CheckActiveLetter(letter.name))
            {
                ActiveLetter(letter);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActiveLetter(GameObject letter)
    {
        letter.TryGetComponent<MeshRenderer>(out MeshRenderer _mesh);
        letter.TryGetComponent<TMP_Text>(out TMP_Text _text);

        _mesh.material = _fontMaterial;
        _text.enableVertexGradient = true;
    }
}
