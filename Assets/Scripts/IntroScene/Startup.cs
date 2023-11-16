using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private string sceneToLoad;

    private IEnumerator Start()
    {
        foreach (var obj in objects)
        {
            Instantiate(obj);
        }

        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene(sceneToLoad);
    }
}
