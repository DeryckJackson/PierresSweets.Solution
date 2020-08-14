namespace Sweets.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<Treat>();
    }

    public int FlavorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Treat> Treats { get; }
  }
}