using System.Runtime.Serialization;

[DataContract]
class Cell
{

  [DataMember]
  HashSet<Side> _links = new HashSet<Side>();

  [DataMember]
  CellType _type = CellType.Usual;

  public HashSet<Side> Links { get => _links;}
  public CellType Type { get => _type; set => _type = value;}

  public void Link(Side side)
  {
    _links.Add(side);
    
  }
}

enum CellType
{
  Input,
  Exit,
  Usual
}