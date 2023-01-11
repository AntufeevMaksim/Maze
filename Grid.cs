using System.Runtime.Serialization;

[DataContract]
class Grid
{
  [DataMember]
  int _rows, _columns;

  [DataMember]
  Cell _output_cell, _input_cell;

  [DataMember]
  List<List<Cell>> _grid = new List<List<Cell>>();

  public int Rows {get => _rows;}
  public int Columns {get => _columns;}
  public Cell OutputCell { get => _output_cell;}
  internal Cell InputCell { get => _input_cell;}

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

  public List<Cell> GetLinkedCells(Cell cell)
  {
    HashSet<Side> links = cell.Links;
    List<Cell> linked_cells = new();

    foreach(var link in links)
    {
      int[] link_cell = GetCoordsLinkedCell(cell.X, cell.Y, link);
      linked_cells.Add(_grid[link_cell[1]][link_cell[0]]);
    }
    return linked_cells;
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
        _grid[y].Add(new Cell(x,y));
      }
    }
  }

  public void MakeInputExit()
  {
    Random random = new();

    int x_in = 0;
    int y_in = random.Next(0, _rows);

    int x_out = Columns-1;
    int y_out = random.Next(0, _rows);

    _output_cell = _grid[y_out][x_out];
    _input_cell = _grid[y_in][x_in];

    _grid[y_in][x_in].Type = CellType.Input;
    _grid[y_out][x_out].Type = CellType.Exit;
  }
}


enum Side
{
  North,
  South,
  East,
  West
}