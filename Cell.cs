
class Cell
{

  HashSet<Side> _links = new HashSet<Side>();

  public HashSet<Side> Links { get => _links;}

  public void Link(Side side)
  {
    _links.Add(side);
    
  }
}