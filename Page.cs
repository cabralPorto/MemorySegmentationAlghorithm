public class Page
{
    public int PageNumber { get; set; }
    public bool Referenced { get; set; }
    public bool Modified { get; set; }
    public bool SecondChance { get; set; }
    public DateTime LastReferencedTime { get; set; }
}
