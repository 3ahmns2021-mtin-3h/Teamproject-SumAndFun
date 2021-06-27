using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public const int startSceneIndex = 0;
    public const int gameSceneIndex = 1;
    public const int scoreSceneIndex = 2;

    public enum NextScene
    {
        StartScene,
        GameScene,
        ScoreScene
    }

    public IEnumerator LoadAsynchronously(NextScene scene)
    {
        int sceneIndex = 0;
        switch (scene)
        {
            case NextScene.StartScene:
                sceneIndex = startSceneIndex;
                break;
            case NextScene.GameScene:
                sceneIndex = gameSceneIndex;
                break;
            case NextScene.ScoreScene:
                sceneIndex = scoreSceneIndex;
                break;
        }

        yield return new WaitForEndOfFrame();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            // Add Scene Transition here

            yield return null;
        }
    }
}
