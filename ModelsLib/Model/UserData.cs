namespace ModelsLib.Model
{
    public class UserData
    {
        public UserData(int userId, string userName, string userPassword)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
        }

        public int UserId { get; set; }

        //keep it as hashed
        public string UserName { get; set; }

        //keep it as hashed
        public string UserPassword { get; set; }
    }
}
