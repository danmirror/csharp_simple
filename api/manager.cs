using System;
using System.Threading;
using Repository;


class Manager
{
    private static RepositoryHandler obj = new RepositoryHandler();

    public delegate void callbackRetrieve(string? data);
    public delegate void callbackGetType(int? data);
    public event callbackRetrieve? OnRetrieved;
    public event callbackGetType? OnGetType;
    public void RegisterManager(string itemName, string itemContent, int itemType)
    {
        Thread workerThread = new Thread(() =>
        {
            Thread.Sleep(10);
            obj.Register(itemName, itemContent, itemType);
        });
        workerThread.Start();
        workerThread.Join();
    }
    
     public void DeRegisterManager(string content)
    {
        Thread workerThread = new Thread(() =>
        {
            Thread.Sleep(10);
            obj.DeRegister(content);
        });
        workerThread.Start();
        workerThread.Join();
    }

    public void RetrieveManager(string content)
    {
       Thread workerThread = new Thread(() =>
        {
            Thread.Sleep(10);
            string? result = obj.Retrieve(content);
            OnRetrieved?.Invoke(result);
        });
        workerThread.Start();
        workerThread.Join();
    }
    public void GetTypeManager(string content)
    {
       Thread workerThread = new Thread(() =>
        {
            Thread.Sleep(10);
            int? result = obj.GetType(content);
            OnGetType?.Invoke(result);
        });
        workerThread.Start();
        workerThread.Join();
    }

  
    
}
