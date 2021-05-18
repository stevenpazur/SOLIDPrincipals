namespace App
{
    public class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public Owner(string firstName, string lastName, string email, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            JobTitle = jobTitle;
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }
    }
}