using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement characterMovement;
    [SerializeField]
    private GroundChecker groundChecker;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] footstepSFX;

    [SerializeField]
    private AudioClip landedClip;

    [SerializeField]
    [Range(0, 1)]
    private float moveSFXLengthModifirer;

    [SerializeField]
    [Range(0, 1)]
    private float landedVolumeScale;

    private int currentClipIndex;

    private float timer;

    private void Update()
    {
        var moveNext = groundChecker.IsGrounded && Mathf.Abs(characterMovement.Velocity.x) > 0 && timer <= 0;

        if (groundChecker.IsLandedLastFrame)
        {
            audioSource.PlayOneShot(landedClip, landedVolumeScale);
        }

        if (moveNext)
        {
            audioSource.PlayOneShot(footstepSFX[currentClipIndex]);

            currentClipIndex = (currentClipIndex + 1) % footstepSFX.Length;

            timer = footstepSFX[currentClipIndex].length * moveSFXLengthModifirer;
        }
        timer -= Time.deltaTime;
    }
}