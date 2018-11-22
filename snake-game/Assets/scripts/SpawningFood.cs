﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningFood : MonoBehaviour {
  public GameObject foodPrefab;

  public Transform borderTop;
  public Transform borderBottom;
  public Transform borderLeft;
  public Transform borderRight;

	void Start() {
    InvokeRepeating("spawn", 3, 4);
	}

  void spawn() {
    int x = (int) Random.Range(borderLeft.position.x, borderRight.position.x);
    int y = (int) Random.Range(borderTop.position.y, borderBottom.position.y);

    Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
  }
}