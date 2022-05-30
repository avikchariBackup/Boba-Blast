using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

namespace BobaBlast.Gameplay
{
    /// <summary>
    /// Add this class to a character so it can use weapons and so that semi-auto weapons trigger on button release
    /// Note that this component will trigger animations (if their parameter is present in the Animator), based on 
    /// the current weapon's Animations
    /// Animator parameters : defined from the Weapon's inspector
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/Abilities/Right Joystick Handle Weapon")]
    public class RightJoystickHandleWeapon : CharacterHandleWeapon
    {
        /// <summary>
        /// Gets input and triggers methods based on what's been pressed, making sure that a semi-auto weapon only fires on ButtonUp
        /// </summary>
        protected override void HandleInput()
        {
            if (!AbilityAuthorized
                || _condition.CurrentState != CharacterStates.CharacterConditions.Normal)
            {
                return;
            }
            if ((CurrentWeapon is null || CurrentWeapon.TriggerMode == Weapon.TriggerModes.Auto) && _inputManager.ShootButton.State.CurrentState == MMInput.ButtonStates.ButtonDown || _inputManager.ShootAxis == MMInput.ButtonStates.ButtonDown)
            {
                ShootStart();
            }

            if (!(CurrentWeapon is null))
            {
                if (ContinuousPress && CurrentWeapon.TriggerMode == Weapon.TriggerModes.Auto && _inputManager.ShootButton.State.CurrentState == MMInput.ButtonStates.ButtonPressed)
                {
                    ShootStart();
                }
                if (ContinuousPress && CurrentWeapon.TriggerMode == Weapon.TriggerModes.Auto && _inputManager.ShootAxis == MMInput.ButtonStates.ButtonPressed)
                {
                    ShootStart();
                }
            }
            
            if (_inputManager.ReloadButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                Reload();
            }

            if (_inputManager.ShootButton.State.CurrentState == MMInput.ButtonStates.ButtonUp || _inputManager.ShootAxis == MMInput.ButtonStates.ButtonUp)
            {
                if (!(CurrentWeapon is null) && CurrentWeapon.TriggerMode == Weapon.TriggerModes.SemiAuto)
                    ShootStart();
                else
                    ShootStop();
            }

            if (CurrentWeapon is null) return;
            if (CurrentWeapon.WeaponState.CurrentState == Weapon.WeaponStates.WeaponDelayBetweenUses && _inputManager.ShootAxis == MMInput.ButtonStates.Off && _inputManager.ShootButton.State.CurrentState == MMInput.ButtonStates.Off)
            {
                CurrentWeapon.WeaponInputStop();
            }
        }
    }
}
