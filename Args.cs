
struct Args
{
  int _rows = 0;
  int _columns = 0;

  GameMode _mode;
  AlgType _algorithm;

  string _path = "";

  public int Rows{get => _rows;}
  public int Columns{get => _columns;}

  public GameMode GameMode{get => _mode;}
  public string Path { get => _path;}
  public AlgType Algorithm { get => _algorithm;}

  public Args(int rows, int columns, GameMode mode, string path, AlgType algorithm)
  {
    _rows = rows;
    _columns = columns;
    _mode = mode;
    _path = path;
    _algorithm = algorithm;
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
