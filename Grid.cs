using System.Runtime.Serialization;

[DataContract]
class Grid
{

  [DataMember]
  List<List<Cell>> _grid = new List<List<Cell>>();

  [DataMember]
  public int Rows { get; private set; }
  [DataMember]
  public int Columns { get; private set; }
  [DataMember]
  public Cell OutputCell { get; private set; }
  [DataMember]
  public Cell InputCell { get; private set; }

  public Grid(int columns, int rows)
  {
    Rows = rows;
    Columns = columns;

    PrepareGrid();
  }


  public Cell this[int x, int y]
  {
    get { return _grid[y][x]; }
  }

  public void Link(int x, int y, Side side)
  {
    Cell cell = _grid[y][x];

    cell.Link(side);
    GetLinkedCell(cell, side).Link(RevertSide(side)); // carve wall in linked cell

  }

  public List<Cell> GetLinkedCells(Cell cell)
  {
    HashSet<Side> links = cell.Links;
    List<Cell> linked_cells = new();

    foreach (var link in links)
    {
      linked_cells.Add(GetLinkedCell(cell, link));
    }
    return linked_cells;
  }

  Cell GetLinkedCell(Cell cell, Side side)
  {
    int x = cell.X;
    int y = cell.Y;
    if (side == Side.North) { return _grid[y - 1][x]; }
    if (side == Side.South) { return _grid[y + 1][x]; }
    if (side == Side.West) { return _grid[y][x - 1]; }
    return _grid[y][x + 1];
  }

  Side RevertSide(Side side)
  {
    if (side == Side.North) { return Side.South; }
    if (side == Side.South) { return Side.North; }
    if (side == Side.West) { return Side.East; }
    return Side.West;
  }
  void PrepareGrid()
  {
    for (int y = 0; y < Rows; y++)
    {
      _grid.Add(new List<Cell>());
      for (int x = 0; x < Columns; x++)
      {
        _grid[y].Add(new Cell(x, y));
      }
    }
  }

  public void MakeInputExit()
  {
    Random random = new();

    int x_in = 0;
    int y_in = random.Next(0, Rows);

    int x_out = Columns - 1;
    int y_out = random.Next(0, Rows);

    OutputCell = _grid[y_out][x_out];
    InputCell = _grid[y_in][x_in];

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