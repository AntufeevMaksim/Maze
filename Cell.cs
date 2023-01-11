using System.Runtime.Serialization;

[DataContract]
class Cell
{

  [DataMember]
  HashSet<Side> _links = new HashSet<Side>();

  [DataMember]
  CellType _type = CellType.Usual;

  [DataMember]
  bool _cell_on_way = false;

  [DataMember]
  int? distance = null;

  [DataMember]
  int _x,_y;
  
  public HashSet<Side> Links { get => _links;}
  public CellType Type { get => _type; set => _type = value;}
  public int? Distance { get => distance; set => distance = value; }
  public int X { get => _x;}
  public int Y { get => _y;}
  public bool CellOnWay { get => _cell_on_way; set => _cell_on_way = value; }

  public Cell(int x, int y)
  {
    _x = x;
    _y = y;

  }

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