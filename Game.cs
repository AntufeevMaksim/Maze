
class Game
{
  public void Run()
  {
    TerminalInputOutput input_output = new TerminalInputOutput();

    GameParams args = input_output.ParseInput();

    LoadSave load_save = new LoadSave();
    Grid grid = CreateGrid(load_save, args);

    input_output.Draw(grid);
  }

  private Grid CreateGrid(LoadSave load_save, GameParams args)
  {
    if (args.GameMode == GameMode.LoadMaze)
    {
      return load_save.Load(args.Path);
    }


    Algorithm algorithm;
    switch (args.Algorithm)
    {
      case AlgType.SideWinder:
        algorithm = new SideWinder();
        break;

      case AlgType.BinaryTree:
        algorithm = new BinaryTree();
        break;

      default:
        algorithm = new SideWinder();
        break;
    }

    Grid grid = new(args.Columns, args.Rows);
    grid = algorithm.CreateMaze(grid);

    Dijkstra dijkstra = new();
    grid = dijkstra.SolveMaze(grid);

    if (args.GameMode == GameMode.NewAndSave)
    {
      load_save.Save(args.Path, grid);
    }
    return grid;
  }
}