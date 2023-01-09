
class Game
{
  public void Run()
  {
    TerminalInputOutput input_output = new TerminalInputOutput();
    LoadSave load_save = new();

    Args args = input_output.ParseInput();
    Grid grid = CreateGrid(load_save, args);
    
    input_output.Draw(grid);
  }

  private Grid CreateGrid(LoadSave load_save, Args args)
  {
    if(args.GameMode == GameMode.LoadMaze)
    {
      return load_save.Load(args.Path);
    }


    Algorithm algorithm;
    if(args.Algorithm == AlgType.SideWinder)
    {
      algorithm = new SideWinder();
    }
    else
    {
      algorithm = new BinaryTree();
    }

    Grid grid = new(args.Columns, args.Rows);
    grid = algorithm.Run(grid);

    if(args.GameMode == GameMode.NewAndSave)
    {
      load_save.Save(args.Path, grid);
    }

    return grid;
  }
}


// /home/maksim/ForPrograms/Maze/maze1.xml
// -ns -s 10 10 /home/maksim/ForPrograms/Maze/maze1.xml