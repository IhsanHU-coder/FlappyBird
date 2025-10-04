using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float _maxTime = 1.5f;
    [SerializeField] float _heightRange = 0.45f;
    [SerializeField] GameObject _pipe;

    private float _timer;

    private bool canMove = false;

    public void CanMove()
    {
        canMove = true;
    }

    private void Update()
    {
        if (!canMove) return;

        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnpos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnpos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
