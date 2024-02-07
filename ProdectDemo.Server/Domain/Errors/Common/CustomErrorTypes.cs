namespace ProductDemo.Server.Domain.Errors.Common;

public static class CustomErrorTypes
{
    public const int BadRequest = 400;
    public const int Forbidden = 403;
    public const int NotAcceptable = 406;
    public const int Timeout = 408;
    public const int Gone = 410;
    public const int Internal = 500;
}
