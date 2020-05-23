using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOST : MonoBehaviour {
    [SerializeField]
    private float WalkSpeed;

    [SerializeField]
    private float runSpeed;
    private float applySpeed;

    private bool isRun;
    private bool isGround;
    private bool isCrouch;

    //땅에 닿아있는지 여부
    private CapsuleCollider capsuleCollider;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;

    [SerializeField]
    private float jumpForce;

    // 앉았을 때 얼마나 앉을지 결정하는 변수.
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;
    private float crouchSpeed;

    [SerializeField]
    private Camera theCamera;

    private Rigidbody myRigid;

    // Start is called before the first frame update
    void Start() {
        theCamera = FindObjectOfType<Camera>();    
        myRigid = GetComponent<Rigidbody>();
        applySpeed = WalkSpeed;
        crouchSpeed = applySpeed * 0.7f;
        capsuleCollider = GetComponent<CapsuleCollider>();
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
    }

    // Update is called once per frame
    void Update() {
        IsGround();
        TryJump();
        TryRun();
        Move();
        CameraRotation();
        CharacterRotation();
    }
    
    // 점프
    private void Jump() {
        if (isCrouch) {
            Crouch();
        }
        
        myRigid.velocity = transform.up * jumpForce;
    }

    // 앉기 시도
    private void TryCrouch() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Crouch();
        }
    }


    // 앉기 동작
    private void Crouch() {
        isCrouch = !isCrouch;

        if (isCrouch) {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else {
            applySpeed = WalkSpeed;
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());

    }

    // 부드러운 동작 실행.
    IEnumerator CrouchCoroutine() {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while (_posY != applyCrouchPosY) {
            count++;
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);
            
            if (count > 15) {
                break;
            }
            
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
    }
    
    // 점프 시도
    private void TryJump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            Jump();
        }
    }

    private void IsGround() {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }

    private void TryRun() {
        if(Input.GetKey(KeyCode.LeftShift)) {
            Running();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            RunningCancel();
        }
    }
    
    private void Running() {
        isRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancel() {
        isRun = false;
        applySpeed = WalkSpeed;
    }
    
    private void Move(){
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
    
    private void CharacterRotation() {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void CameraRotation() {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}
