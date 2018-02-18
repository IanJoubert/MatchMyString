namespace Mms.Business.Services
{
    public interface IMatcherService
    {
        string GetMatches(string searchString, string file);
    }
}
