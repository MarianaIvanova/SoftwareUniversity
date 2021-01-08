using System;
using System.IO;

namespace Lab_5_Slice_a_File_INTERESTING
{
    class Program
    {
        static void Main(string[] args)//NO Judge access to check it!!!
        {
            int piecesCount = 4;//Number of pieces and files we want to make
            using(FileStream stream = new FileStream("../../../InputSliceFile.txt", FileMode.Open))
            {
                long size = stream.Length / piecesCount;

                for (int i = 0; i < piecesCount; i++)
                {
                    byte[] buffer = new byte[1];//We can choose 4096 or more if the file is very big

                    using(FileStream pieceStream = new FileStream($"../../../part-{i+1}.txt", FileMode.Create))
                    {
                        int count = 0;
                        while(count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStream.Write(buffer, 0, buffer.Length);
                            count+= buffer.Length;
                        }
                    }
                }
            }
        }
    }
}
