using System.Runtime.Serialization;

[DataContract]
class Cell
{
  [DataMember]
  public HashSet<Side> Links { get; private set; } = new HashSet<Side>();
  [DataMember]
  public CellType Type { get; set; } = CellType.Usual;
  [DataMember]
  public int? Distance { get; set; } = null;
  [DataMember]
  public bool CellOnWay { get; set; }
  [DataMember]
  public int X { get; private set; }
  [DataMember]
  public int Y { get; private set; }



  public Cell(int x, int y)
  {
    X = x;
    Y = y;

  }

  public void Link(Side side)
  {
    Links.Add(side);

  }
}

enum CellType
{
  Input,
  Exit,
  Usual
}