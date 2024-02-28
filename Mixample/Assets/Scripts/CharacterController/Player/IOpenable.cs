using UnityEngine;

public interface IOpenable
{
    public void OpenOrCLose();
    public void UnLock();
    public void Lock(CodeLock codeLock);
}