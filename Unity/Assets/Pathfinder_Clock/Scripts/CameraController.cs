using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 20f;
	public float minPanLimitX, maxPanLimitX, minusPanLimitY, maxPanLimitY, minHeight, maxHeight;
	public float scrollSpeed = 15f;

	public bool hasTarget = false;
	private Vector3 targetOffset = new Vector3(4f,7f,0f);
	public Transform targetFollow;
	public float targetSpeed;

    private void Awake()
    {
        transform.position = new Vector3(0f, 30f, 0f);
    }

    void Update () {

		Vector3 pos = transform.position;

		if((Input.GetKey(KeyCode.Z))||(Input.GetKey(KeyCode.Q))||(Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.D))){
			if(Input.GetKey(KeyCode.Z)){
				pos.x -= panSpeed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.Q)){
				pos.z -= panSpeed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.S)){
				pos.x += panSpeed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.D)){
				pos.z += panSpeed * Time.deltaTime;
			}
			hasTarget = false;
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if(!hasTarget){
			pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;
		}else if(hasTarget){
			targetOffset.y -= scroll * scrollSpeed * 100 * Time.deltaTime;
			targetOffset.x += -scroll * (targetOffset.y/1.75f);
			targetOffset.y = Mathf.Clamp(targetOffset.y, minHeight, maxHeight);
			targetOffset.x = Mathf.Clamp(targetOffset.x, targetOffset.y/1.75f, targetOffset.y/1.75f);

		}

		pos.x = Mathf.Clamp(pos.x, minPanLimitX, maxPanLimitX);
		pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
		pos.z = Mathf.Clamp(pos.z, minusPanLimitY, maxPanLimitY);

		if(!hasTarget){
			transform.position = pos;
		}else	if(hasTarget){
			FollowTarget();
		}
	}

	public void SetTarget(Transform target){
		hasTarget = true;
		targetFollow = target;
	}

	private void FollowTarget(){
		Vector3 targetPos = new Vector3(targetFollow.position.x, 0, targetFollow.position.z) + targetOffset;
		transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime*targetSpeed);
	}
}
