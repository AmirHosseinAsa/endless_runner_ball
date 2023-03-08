using System.Threading.Tasks;
using UnityEngine;

public sealed class UnityInputService : Service, IInputService
{
    private float _holdingTimeLeft;
    private bool _isHoldingLeft;
    private bool _isReleasedLeft;
    private bool _isStartedHoldingLeft;

    private float _holdingTimeRight;
    private bool _isHoldingRight;
    private bool _isReleasedRight;
    private bool _isStartedHoldingRight;

    private bool CanUseKeyboard = false;

    public UnityInputService(Contexts contexts) : base(contexts)
    {
    }

    public async void Update(float delta)
    {
        var midPoint = Screen.width / 2f;

        var leftHitCounter = 0;
        var rightHitCounter = 0;
        if (!SaveScript.IsItFirstTimeRunning)
        {
            if (CanUseKeyboard)
            {
                #region Keyboard
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.JoystickButton3) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
                {
                    leftHitCounter++;
                }
                Debug.Log(Input.GetAxis("Vertical"));
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetAxis("Vertical")==1)
                {
                    rightHitCounter++;
                }
                #endregion

                if (leftHitCounter > 0)
                {
                    if (_isHoldingLeft)
                    {
                        _holdingTimeLeft += delta;
                        _isStartedHoldingLeft = false;
                    }
                    else
                    {
                        _holdingTimeLeft = 0f;
                        _isStartedHoldingLeft = true;
                    }

                    _isHoldingLeft = true;
                    _isReleasedLeft = false;
                }
                else
                {
                    if (_isHoldingLeft)
                    {
                        _isHoldingLeft = false;
                        _isReleasedLeft = true;
                    }
                    else
                    {
                        _isReleasedLeft = false;
                    }
                }

                if (rightHitCounter > 0)
                {
                    if (_isHoldingRight)
                    {
                        _holdingTimeRight += delta;
                        _isStartedHoldingRight = false;
                    }
                    else
                    {
                        _holdingTimeRight = 0f;
                        _isStartedHoldingRight = true;
                    }

                    _isHoldingRight = true;
                    _isReleasedRight = false;
                }
                else
                {
                    if (_isHoldingRight)
                    {
                        _isHoldingRight = false;
                        _isReleasedRight = true;
                    }
                    else
                    {
                        _isReleasedRight = false;
                    }
                }
            }
            else
            {
                await Task.Delay(500);
                CanUseKeyboard = true;
            }
        }
    }

    #region Interface Implementation

    #region Left
    public bool IsHoldingLeft()
    {
        return _isHoldingLeft;
    }

    public bool IsStartedHoldingLeft()
    {
        return _isStartedHoldingLeft;
    }

    public float HoldingTimeLeft()
    {
        return _holdingTimeLeft;
    }

    public bool IsReleasedLeft()
    {
        return _isReleasedLeft;
    }
    #endregion

    #region Right
    public bool IsHoldingRight()
    {
        return _isHoldingRight;
    }

    public bool IsStartedHoldingRight()
    {
        return _isStartedHoldingRight;
    }

    public float HoldingTimeRight()
    {
        return _holdingTimeRight;
    }

    public bool IsReleasedRight()
    {
        return _isReleasedRight;
    }
    #endregion

    #endregion
}