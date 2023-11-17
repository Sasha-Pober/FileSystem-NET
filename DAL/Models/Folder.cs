namespace DAL.Models;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Folder Parent { get; set; } = null!;
    public int? ParentId { get; set; }
    public ICollection<Folder> SubFolders { get; } = new List<Folder>();
}

