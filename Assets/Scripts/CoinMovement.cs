using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
