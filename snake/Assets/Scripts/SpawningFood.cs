using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningFood : MonoBehaviour {
  public GameObject food;
  public Transform top;
  public Transform bottom;
  public Transform left;
  public Transform right;

  void Spawn() {
    int x = (int) Random.Range(left.position.x, right.position.x);
    int y = (int) Random.Range(bottom.position.y, top.position.y);

    Instantiate(food, new Vector2(x, y), Quaternion.identity);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Food")) {
      Destroy(other.gameObject);  
      Spawn();
    }
  }
}
