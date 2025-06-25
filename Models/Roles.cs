namespace AUTHDEMO1.Models
{
    public  static class Roles
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Accounts = "Accounts";
        public const string Operations = "Operations";
        public const string HR = "HR";

        public static readonly string[] AllRoles = new string[]
        {
            SuperAdmin,
            Admin,
            Accounts,
            Operations,
            HR
        };
    }
}
