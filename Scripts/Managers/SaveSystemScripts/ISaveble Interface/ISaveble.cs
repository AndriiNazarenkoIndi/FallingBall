using System.IO;

public interface IDataSaveble
{
    public void SaveData(BinaryWriter binaryWriter);
    public void LoadData(BinaryReader binaryReader);
}