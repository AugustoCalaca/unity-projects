using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour {
  private Vector2 direction = Vector2.right;
  private List<Transform> tail = new List<Transform>();
  private GameObject tailPrefab;
  bool eat = false;

	void Start() {
    InvokeRepeating("move", 0.3f, 0.3f);
	}

	void move() {
    // move tail
    Vector2 v = transform.position; // take empty position

    // move head
    transform.Translate(direction);

    if(eat) {
      GameObject go = Instantiate(tailPrefab, v, Quaternion.identity);
      tail.Insert(0, go.transform);
      eat = false;
    } else if(tail.Count  > 0) {
      tail.Last().position = v;
      tail.Insert(0, tail.Last());
      tail.RemoveAt(tail.Count - 1);
    }
	}

  void OnTriggerEnter2D(Collider2D coll) {
    if(coll.name.StartsWith("foodPrefab")) {
      eat = true;
      Destroy(coll.gameObject);
    } else {
      // game over
    }
  }

  void Update() {
    if(Input.GetKey(KeyCode.RightArrow))
      direction = Vector2.right;
    else if(Input.GetKey(KeyCode.LeftArrow))
      direction = Vector2.left;
    else if(Input.GetKey(KeyCode.UpArrow))
      direction =Vector2.up;
    else if(Input.GetKey(KeyCode.DownArrow))
      direction = Vector2.down;
  }
}
