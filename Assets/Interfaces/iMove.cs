using UnityEngine;
using System.Collections;

public interface iMove {
	
	float moveRight(float horizontal);
	float moveLeft(float horizontal);
	float moveUp(float vertical);
	float moveDown(float vertical);
}
