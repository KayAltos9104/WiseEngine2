namespace WiseEngine2;

public class Logger
{
    private List<string> _log;
    public Logger ()
    {
        _log = new List<string> ();
        _log.Add("=============Begin Log============");
    }

    public void AddMessage (string message)
    {
        _log.Add (string.Join(". ", new string[] {DateTime.Now.ToString(), message}));
    }
    public void ClearLog()
    {
        _log = new List<string> ();
    }
    public string GetLog()
    {
        string logMessage = "";
        foreach (var message in _log)
        {
            logMessage += message+"\n";
        }
        return logMessage;
    }
}
