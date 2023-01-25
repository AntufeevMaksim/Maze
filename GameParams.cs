
struct GameParams
{
  public int Rows { get; private set; } = 0;

  public int Columns { get; private set; } = 0;

  public GameMode GameMode { get; private set; }
  public string Path { get; private set; }
  public AlgType Algorithm { get; private set; }

  public GameParams(int rows, int columns, GameMode mode, string path, AlgType algorithm)
  {
    Rows = rows;
    Columns = columns;
    GameMode = mode;
    Path = path;
    Algorithm = algorithm;
  }
}

enum GameMode
{
  NewMaze,

  NewAndSave,
  LoadMaze
}

enum AlgType
{
  BinaryTree,
  SideWinder
}
