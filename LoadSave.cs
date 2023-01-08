using System.Runtime.Serialization;
using System.Xml;

class LoadSave
{
  public void Save(string path, Grid grid)
  {
    FileStream writer = new FileStream(path, FileMode.OpenOrCreate);
    DataContractSerializer ser = new DataContractSerializer(typeof(Grid));

    ser.WriteObject(writer, grid);
    writer.Close();
  }

  public Grid Load(string path)
  {
    FileStream fs = new FileStream(path, FileMode.Open);
    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
    DataContractSerializer ser = new DataContractSerializer(typeof(Grid));

            // Deserialize the data and read it from the instance.
    Grid grid = (Grid)ser.ReadObject(reader, true);
    reader.Close();
    fs.Close();
    return grid;
  }
}