namespace VkInternship.Requests
{
    public class AddUserRequest
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? GroupCode { get; set; }

        public string? GroupDescription { get; set; }

        public string? UserStateDescription { get; set; }
    }
}
