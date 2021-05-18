namespace App
{
  public class Owner
  {
    public Owner(string firstName, string lastName, string email, string jobTitle)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      JobTitle = jobTitle;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }

    public void ChangeFirstName(string firstName)
    {
      FirstName = firstName;
    }

    public void ChangeLastName(string lastName)
    {
      LastName = lastName;
    }

    public string getOwnerFirstName()
    {
      return FirstName;
    }

    public string getOwnerLastName()
    {
      return LastName;
    }

    public string getOwnerJobTitle()
    {
      return JobTitle;
    }

    public string getOwnerEmail()
    {
      return Email;
    }
  }
}