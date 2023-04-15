namespace WebApp.Models.AssignmentInternship
{
    public class Login
    {
        string uuid { get; set; }
        string username { get; set; }
        string password { get; set; }
        string salt { get; set; }
        string md5 { get; set; }
        string sha1 { get; set; }
        string sha256 { get; set; }
    }
}
