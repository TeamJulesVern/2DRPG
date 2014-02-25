using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public Transform player;
	
	public float smoothRate = 0.5f;
	
	private Transform thisTransform;
	private Vector2 velocity;
	// Use this for initialization
	void Start () {
		thisTransform = transform;
		velocity = new Vector2 (0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPos2D = Vector2.zero;
		if ((player.position.x < 3.90f || player.position.x > 35.08f) && (player.position.y > 3.30f || player.position.y < -41.61f)) {
			newPos2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x<3.90f ? 3.90f : 35.08f, ref velocity.x, smoothRate);
			newPos2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y > 3.30f ? 3.30f : -41.61f, ref velocity.y, smoothRate);
		} else if (player.position.y > 3.30f || player.position.y < -41.61f) {
			newPos2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x, ref velocity.x, smoothRate);
			newPos2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y > 3.30f ? 3.30f : -41.61f, ref velocity.y, smoothRate);
		} else if ((player.position.x < 3.90f || player.position.x > 35.08f)) {
			newPos2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x<3.90f ? 3.90f : 35.08f, ref velocity.x, smoothRate);
			newPos2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y, ref velocity.y, smoothRate);		
		} else {
			newPos2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x, ref velocity.x, smoothRate);
			newPos2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y, ref velocity.y, smoothRate);
		}
		
		
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, transform.position.z);
		transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
	}
}
