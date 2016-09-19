namespace MockAndInject.DTO
{
    public class UserDTO
    {
        // Simple POCO class
        public UserDTO() { }

        public UserDTO(string userName, bool auth)
        {
            this.UserName = userName;
            this.IsAuthenticated = auth; 
        }

      

        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }
        public string PassWord { get; set; }        
    }
}
