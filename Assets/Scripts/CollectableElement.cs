using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class CollectableElement : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    private Renderer _renderer;
    private bool _selected;

    public GameObject CollectedObject;
    public bool IsDragging;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!IsDragging)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    _renderer.material = selectedMaterial;
                    _selected = true;
                }
                else
                {
                    _renderer.material = defaultMaterial;
                    _selected = false;
                }
            }

            if (Input.GetMouseButtonDown(0) && _selected)
            {
                CollectedObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
