using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void StartRunAnimation()
    {
        _playerAnimator.SetTrigger("Run");
    }

    public void JumpAnimation(bool state)
    {
        _playerAnimator.SetBool("Jump", state);
    }
}
