public class Media
{
    public string Type { get; set; }
    public string PortNumber { get; set; }
    public string Transport { get; set; }
    public List<string> Format { get; set; } = new List<string>();
}
