namespace WiseEngine2.Game;

public class SceneManager
{
    private Scene? _currentScene;
    private Dictionary<string, Scene> _scenes;

    public Logger SceneLogger;
    public SceneManager()
    {
        _scenes = new Dictionary<string, Scene>();
        SceneLogger = new Logger();
        SceneLogger.AddMessage("Scene Manager initialized succesfully");
    }

    public void LoadScene (string sceneName, Scene scene)
    {
        if (scene is not null && _scenes.TryAdd(sceneName, scene))
        {            
            if (_currentScene == null)
            {
               SetCurrentScene(sceneName);
            }                
        }
        else
        {
            SceneLogger.AddMessage($"Scene was not added because {sceneName} is already exists or scene is empty");
        }
    } 
    public void SetCurrentScene (string sceneName)
    {
        if (_scenes.TryGetValue(sceneName, out Scene scene) && scene != null)
        {
            _currentScene = scene;
            SceneLogger.AddMessage($"Current scene was set to {sceneName}");
        }
        else
        {
            SceneLogger.AddMessage($"Scene {sceneName} was not as current added because this scene does not exist or scene is empty");
        }
    }
    public Scene GetCurrentScene ()
    {
        return _currentScene;
    }

    public  void RemoveScene (string sceneName)
    {
        if (_scenes.Remove(sceneName))
        {
            SceneLogger.AddMessage($"Scene {sceneName} removed successfully");
        }
        else
        {
            SceneLogger.AddMessage($"Scene {sceneName} was not removed");
        }
    }
}
