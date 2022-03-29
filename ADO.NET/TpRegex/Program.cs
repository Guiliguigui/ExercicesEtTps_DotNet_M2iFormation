

using System.Text.RegularExpressions;

void ValidateEmailRegex(string email)
{
    var regex = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
    if (!regex.IsMatch(email))
    {
        throw new ArgumentException("Email is not valid");
    }
}

//function that normalize email to minuscule and remove all spaces
string NormalizeEmail(string email)
{
    return email.ToLower().Replace(" ", "");
}

// function that iterate all emails and validate them and normalize them
void ValidateEmails(string[] emails)
{
    foreach (var email in emails)
    {
        ValidateEmailRegex(email);
        Console.WriteLine(NormalizeEmail(email));
    }
}
