using UnityEngine;

public class ManagerAsteroids : MonoBehaviour
{
    public GameObject _asteroidsPrefabs;
    public int _numberOfAsteroidsOnAxisX = 10;
    public int _numberOfAsteroidsOnAxisY = 10;
    public int _numberOfAsteroidsOnAxisZ = 10;
    public int _gridSpacing = 10;

    private void Start()
    {
        for(int i = 0;  i < _numberOfAsteroidsOnAxisX; i++)
        {
            for (int j = 0; j < _numberOfAsteroidsOnAxisY; j++)
            {
                for (int k = 0; k < _numberOfAsteroidsOnAxisZ; k++)
                {
                    InstantiateAsteroids(i, j, k);
                }
            }
        }
    }

    private void InstantiateAsteroids(int x, int y, int z)
    {
        Instantiate(_asteroidsPrefabs, new Vector3(transform.position.x + x * _gridSpacing + OffsetAst(),
                                                   transform.position.y + y * _gridSpacing + OffsetAst(),
                                                   transform.position.z + z * _gridSpacing + OffsetAst()),
        Quaternion.identity, transform);
    }

    private float OffsetAst()
    {
        return Random.Range(-_gridSpacing / 3f, _gridSpacing / 3f);
    }
}
