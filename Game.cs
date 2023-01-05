
class Game
{
  public void Run(){
    Grid grid = new Grid(10, 10);
    ASCIIGraphics graphics = new ASCIIGraphics();
//    BinaryTree algorithm = new BinaryTree();
    SideWinder algorithm = new SideWinder();
    grid = algorithm.Run(grid);
    graphics.Draw(grid);
  }
}