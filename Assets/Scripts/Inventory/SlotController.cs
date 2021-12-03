using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IPointerDownHandler
{
    private const float offset = 4.2f;

    [SerializeField] GameObject slotItem;
    [SerializeField] GameObject itemPrefab;

    private Transform _newItem;
    private Rigidbody _itemRigidbody;
    private CollectableElement _collectableElement;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _newItem)
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset);
            var objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            _newItem.position = objectPosition;
        }
        else if (Input.GetMouseButtonUp(0) && _newItem)
        {
            if (_collectableElement)
            {
                _collectableElement.CollectedObject = slotItem;
                _collectableElement.IsDragging = false;
            }
            
            if (_itemRigidbody) _itemRigidbody.isKinematic = false;

            _newItem = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (slotItem.activeSelf)
        {
            slotItem.SetActive(false);

            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset);
            var objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            _newItem = Instantiate(itemPrefab, objectPosition, Quaternion.identity).transform;
            _itemRigidbody = _newItem.GetComponent<Rigidbody>();
            _collectableElement = _newItem.GetComponent<CollectableElement>();

            if (_itemRigidbody) _itemRigidbody.isKinematic = true;
            if (_collectableElement) _collectableElement.IsDragging = true;
        }
    }
}
