using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // �� �ڷ�ƾ �� �� �ʿ�

public class TitleUIManager : MonoBehaviour
{
    [Header("���� �޽��� ĵ����")]
    public GameObject loadErrorUI; // Inspector���� �����ؾ� ��

    private Coroutine blinkCoroutine;

    public void OnClickNewGame()
    {
        SaveManager.Instance.ResetData();
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickLoadGame()
    {
        if (SaveManager.Instance.HasSavedData())
        {
            SaveManager.Instance.LoadData();
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("����� �����Ͱ� �����ϴ�.");

            if (blinkCoroutine != null)
                StopCoroutine(blinkCoroutine); // �ߺ� ����

            blinkCoroutine = StartCoroutine(BlinkLoadError());
        }
    }

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private IEnumerator BlinkLoadError()
    {
        int count = 3;
        float interval = 0.3f;

        for (int i = 0; i < count; i++)
        {
            loadErrorUI.SetActive(true);
            yield return new WaitForSeconds(interval);
            loadErrorUI.SetActive(false);
            yield return new WaitForSeconds(interval);
        }
    }

}
