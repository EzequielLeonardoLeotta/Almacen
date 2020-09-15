namespace BE_Template_NetCore.Models
{
  public class ServiceResponse<T>
  {
    public T Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = null;
  }
}