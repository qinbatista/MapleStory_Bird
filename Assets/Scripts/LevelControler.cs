using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelControler : MonoBehaviour
{
    // Start is called before the first frame update
    private static int _nextLevelIndex = 0;
    private Enemy[] _enemies;
    private void OnEnable() {
        _enemies  = FindObjectsOfType<Enemy>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy!=null)
                return;
        }
        Debug.Log("you killed all enemies");
        _nextLevelIndex++;
        string nextLevelName = "level"+_nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
