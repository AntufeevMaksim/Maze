
class TerminalInputOutput
{
  public void Draw(Grid grid)
  {
    Console.Clear();
    for(int y=0; y<grid.Rows; y++)
    {
      for(int x=0; x<grid.Columns; x++)
      {
        DrawCell(x,y, grid);
      }
    }
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
  }

  void DrawCell(int x, int y, Grid grid)
  {

    DrawWallCrossings(x,y);

    if (grid[x, y].Type == CellType.Usual)
    {
      DrawUsualCell(x, y, grid);
    }
    else
    {
      DrawInputExitCell(x, y, grid);
    }
  }

  private void DrawUsualCell(int x, int y, Grid grid)
  {
    HashSet<Side> empty_walls = grid[x, y].Links;

    //north wall
    DrawNorthWall(x, y, empty_walls);

    //west wall
    DrawWestWall(x, y, empty_walls);

    //south wall
    DrawSouthWall(x, y, empty_walls);


    //east wall
    DrawEastWall(x, y, empty_walls);
  }

  void DrawInputExitCell(int x, int y, Grid grid)
  {
    HashSet<Side> empty_walls = grid[x,y].Links;

    if(x != 0){DrawWestWall(x, y, empty_walls);}
    if(x != grid.Columns-1){DrawEastWall(x, y, empty_walls);}

    if(y != 0){DrawNorthWall(x, y, empty_walls);}
    if(y != grid.Rows-1){DrawSouthWall(x, y, empty_walls);}
  }

  void DrawWallCrossings(int x, int y)
  {
    int tx = x*4;
    int ty = y*2;

    Console.SetCursorPosition(tx,ty);
    Console.Write("+");

    Console.SetCursorPosition(tx+4,ty);
    Console.Write("+");

    Console.SetCursorPosition(tx,ty+2);
    Console.Write("+");

    Console.SetCursorPosition(tx+4,ty+2);
    Console.Write("+");
  }


  private void DrawEastWall(int x, int y, HashSet<Side> empty_walls)
  {
    if (!empty_walls.Contains(Side.East))
    {
      Console.SetCursorPosition(4*x + 4, 2*y + 1);
      Console.Write("|");
    }
  }

  private void DrawSouthWall(int x, int y, HashSet<Side> empty_walls)
  {
    if (!empty_walls.Contains(Side.South))
    {
      Console.SetCursorPosition(4*x + 1, 2*y + 2);
      Console.Write("---");
    }
  }

  private void DrawWestWall(int x, int y, HashSet<Side> empty_walls)
  {
    if (!empty_walls.Contains(Side.West))
    {
      Console.SetCursorPosition(4*x, 2*y + 1);
      Console.Write("|");
    }
  }

  private void DrawNorthWall(int x, int y, HashSet<Side> empty_walls)
  {
    if (!empty_walls.Contains(Side.North))
    {
      Console.SetCursorPosition(4*x + 1, 2*y);
      Console.Write("---");
    }
  }

  public Args ParseInput()
  {
    List<string> str_args = Console.ReadLine().Split(" ").ToList();

    int columns=0;
    int rows=0;

    GameMode mode;
    AlgType algorithm = AlgType.SideWinder;
    string path = "";

    switch (str_args[0])
    {
      case("-n"):
        mode = GameMode.NewMaze;
        algorithm = ParseAlgorithm(str_args[1]);
        columns = Int32.Parse(str_args[2]);
        rows = Int32.Parse(str_args[3]); 
        break;
      
      case ("-ns"):
        mode = GameMode.NewAndSave;
        algorithm = ParseAlgorithm(str_args[1]);
        columns = Int32.Parse(str_args[2]);
        rows = Int32.Parse(str_args[3]); 
        path = str_args[4]; 
        break;

      case("-l"):
        mode = GameMode.LoadMaze;
        path = str_args[1];
        break;

      default:
        mode = GameMode.NewMaze;
        break;
    }

    Args args = new(rows, columns, mode, path, algorithm);
    return args;
  }


  AlgType ParseAlgorithm(string arg)
  {
    switch(arg)
    {
      case("-b"):
        return AlgType.BinaryTree;

      case("-s"):
        return AlgType.SideWinder;
    }
    return AlgType.SideWinder;
  }
}
