namespace Models;

public class ErrorViewModel
{
    private string? _requestId {get;} public string? RequestId {get{return _requestId;}}  

    public bool ShowRequestId => !string.IsNullOrEmpty(_requestId);
}
