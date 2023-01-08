using System.Runtime.Serialization;

[DataContract]
class Grid
{
  [DataMember]
  int _rows, _columns;

  [DataMember]
  List<List<Cell>> _grid = new List<List<Cell>>();

  public int Rows {get => _rows;}
  public int Columns {get => _columns;}

  public Grid(int columns, int rows)
  {
    _rows = rows;
    _columns = columns;

    PrepareGrid();
  }


  public Cell this[int x, int y]
   {
      get { return _grid[y][x];}
   }
  public void Link(int x, int y, Side side)
  {
    _grid[y][x].Link(side);

    int[] coords = GetCoordsLinkedCell(x, y, side);
    _grid[coords[1]][coords[0]].Link(RevertSide(side)); // carve wall in linked cell

  }


  int[] GetCoordsLinkedCell(int x, int y, Side side)
  {
    if(side == Side.North){return new int[]{x, y-1};}
    if(side == Side.South){return new int[]{x, y+1};}
    if(side == Side.West){return new int[]{x-1, y};}
    return new int[]{x+1, y};
  }

  Side RevertSide(Side side)
  {
    if(side == Side.North){return Side.South;}
    if(side == Side.South){return Side.North;}
    if(side == Side.West){return Side.East;}
    return Side.West;
  }
  void PrepareGrid()
  {
    for(int y=0; y<_rows; y++)
    {
      _grid.Add(new List<Cell>());
      for(int x=0; x<_columns; x++)
      {
        _grid[y].Add(new Cell());
      }
    }
  }


}


enum Side
{
  North,
  South,
  East,
  West
}