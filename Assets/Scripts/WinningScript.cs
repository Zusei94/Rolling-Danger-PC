using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    [SerializeField] private Material winningMaterial;
    [SerializeField] private GameObject winningUI;
    [SerializeField] private int loadScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WinningRoutine()
    {
        GetComponent<MeshRenderer>().material = winningMaterial;

        winningUI.SetActive(true);

        Time.timeScale = 0.25f;

        //wait for 1f, but note every second in real life now is 0.25 in our game to this wait will be around 4 second
        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        SceneManager.LoadSceneAsync(loadScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WinningRoutine());
        }
    }
}
