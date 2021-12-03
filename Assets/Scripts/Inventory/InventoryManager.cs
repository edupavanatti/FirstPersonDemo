using System.Collections;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static readonly int IsShowing = Animator.StringToHash("IsShowing");

    [SerializeField] private Animator inventoryAnimator;
    [SerializeField] private AnimationClip showAnimation;

    private bool _hasAnimationEnded = true;
    private bool _isShowing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _hasAnimationEnded)
        {
            _hasAnimationEnded = false;
            StartCoroutine(ShowInventory());
        }
    }

    private IEnumerator ShowInventory()
    {
        _isShowing = !_isShowing;
        inventoryAnimator.SetBool(IsShowing, _isShowing);

        if (_isShowing) Cursor.lockState = CursorLockMode.Confined;
        else Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(showAnimation.length);
        _hasAnimationEnded = true;
    }
}
