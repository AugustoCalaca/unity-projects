using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour {
  List<Transform> tail = new List<Transform>();
  public GameObject tailPrefab;
  public GameObject panel;
  Vector2 direction;
  public Text showPoints;
  bool eat;
  int points, plus;

  void Start() {
    direction = Vector2.up;
    eat = false;
    points = 0;
    plus = 100;
    panel.SetActive(false);
    InvokeRepeating("Move", 0.5f, 0.08f);
  }

  void Update() {
    if(Input.GetKey(KeyCode.RightArrow) && !direction.Equals(Vector2.left))
      direction = Vector2.right;
    if(Input.GetKey(KeyCode.DownArrow) && !direction.Equals(Vector2.up))
      direction = Vector2.down;
    if(Input.GetKey(KeyCode.LeftArrow) && !direction.Equals(Vector2.right))
      direction = Vector2.left;
    if(Input.GetKey(KeyCode.UpArrow) && !direction.Equals(Vector2.down))
      direction = Vector2.up;
  }

  void Move() {
    Vector2 temp = transform.position;
    transform.Translate(direction);
    if(eat) {
      GameObject obj = Instantiate(tailPrefab, temp, Quaternion.identity);
      tail.Insert(0, obj.transform);
      eat = false;
    }
    else if(tail.Count > 0) {
      tail.Last().position = temp;
      tail.Insert(0, tail.Last());
      tail.RemoveAt(tail.Count - 1);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Food")) {
      points += plus;
      showPoints.text = points.ToString();
      eat = true;
    }

    if(other.gameObject.CompareTag("Border") || 
       other.gameObject.CompareTag("Tail")) {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
  }
}
