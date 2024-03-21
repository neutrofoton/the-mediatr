using MediatR;

namespace TheMediatR.ConsoleApp;

public class Announcement : INotification
{
    public string Message {get;set;} = string.Empty;
}

public class AnnouncementExt : INotification
{
    public string Message {get;set;} = string.Empty;
}