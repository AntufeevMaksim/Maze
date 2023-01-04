
class Game
{
  public void Run(){
    Grid grid = new Grid(10, 10);
    ASCIIGraphics graphics = new ASCIIGraphics();
    graphics.Draw(grid);
  }
}