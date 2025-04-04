namespace Calculator;

public class Names
{
    public string NickName { get; set; }
    public string FullName(string firstName, string lastName)
    {
        NickName = $"{firstName[0]}+{lastName[0]}";
        return $"{firstName} {lastName}";
    }
}
