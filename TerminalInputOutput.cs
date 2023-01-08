
class TerminalInputOutput
{
  public void Draw(Grid grid)
  {
    Console.Clear();
    for(int y=0; y<grid.Rows; y++)
    {
      for(int x=0; x<grid.Columns; x++)
      {
        DrawCell(x,y, grid[x,y]);
      }
    }
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
  }

  void DrawCell(int x, int y, Cell cell)
  {
     
    Console.SetCursorPosition(4*x, 2*y+1);

    HashSet<Side> empty_walls = cell.Links;

    //north wall
    Console.Write("+");
    if(!empty_walls.Contains(Side.North)){Console.Write("---");}
    Console.SetCursorPosition(4*x+4, 2*y+1);
    Console.Write("+");

    //west wall
    if(!empty_walls.Contains(Side.West))
    {
      Console.SetCursorPosition(4*x, 2*y+2);
      Console.Write("|");
    }
    Console.SetCursorPosition(4*x, 2*y+3);
    Console.Write("+");    

    //south wall
    if(!empty_walls.Contains(Side.South)){Console.Write("---");}
    Console.SetCursorPosition(4*x+4, 2*y+3);
    Console.Write("+");


    //east wall
    if(!empty_walls.Contains(Side.East))
    {
      Console.SetCursorPosition(4*x+4, 2*y+2);
      Console.Write("|");
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