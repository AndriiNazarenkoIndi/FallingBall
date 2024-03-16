using System;
using System.IO;

[Serializable]
public class GameDataToSave : IDataSaveble
{
    public int maxScoreValue;
    public int maxDiamondsValue;
    public int localScoreValue;
    public int totalAmountExtraLife;

    public GameDataToSave()
    {
        maxScoreValue = 0;
        maxDiamondsValue = 0;
        localScoreValue = 0;
        totalAmountExtraLife = 0;
    }

    public void LoadData(BinaryReader binaryReader)
    {
        maxScoreValue = binaryReader.ReadInt32();
        maxDiamondsValue = binaryReader.ReadInt32();
        localScoreValue = binaryReader.ReadInt32();
        totalAmountExtraLife = binaryReader.ReadInt32();
    }

    public void SaveData(BinaryWriter binaryWriter)
    {
        binaryWriter.Write(maxScoreValue);
        binaryWriter.Write(maxDiamondsValue);
        binaryWriter.Write(localScoreValue);
        binaryWriter.Write(totalAmountExtraLife);
    }
}