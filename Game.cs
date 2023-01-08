
class Game
{
  public void Run(){
//     LoadSave loadSave = new();
//     Grid grid = new Grid(20, 10);
//     ASCIIGraphics graphics = new ASCIIGraphics();
// //    BinaryTree algorithm = new BinaryTree();
//     SideWinder algorithm = new SideWinder();
//     grid = algorithm.Run(grid);
//     graphics.Draw(grid);

//     loadSave.Save("/home/maksim/ForPrograms/Maze/maze1.xml", grid);


    LoadSave loadSave = new();
//    Grid grid = new Grid(20, 10);
    Grid grid = loadSave.Load("/home/maksim/ForPrograms/Maze/maze1.xml");
    ASCIIGraphics graphics = new ASCIIGraphics();
//    SideWinder algorithm = new SideWinder();
//    grid = algorithm.Run(grid);
    graphics.Draw(grid);

    loadSave.Save("/home/maksim/ForPrograms/Maze/maze1.xml", grid);
  }
}