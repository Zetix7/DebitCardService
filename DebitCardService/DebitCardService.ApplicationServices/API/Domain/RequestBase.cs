namespace DebitCardService.ApplicationServices.API.Domain;

public class RequestBase
{
    public int IdAuthentication { get; set; }
    public string? NameAuthentication { get; set; }
    public string? AccessLevelAuthentication { get; set; }
}
