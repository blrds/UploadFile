using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadFile
{ 
    class Page
    {
        public const int CellsCount= 256;//константы характеризующие страницы и элементы
        public const int BitesPerCell = 2;
        public int Number { get; private set; }//номер страницы

        public long BitMapIndex { get; private set; }//номер первого элемента бытмапы в файле

        public string FileName { get; private set; }//имя родительского файла

        public long InfoIndex { get;private set; }//номер первого элемента в файле

        public Page(int number,bool rewrite, string File="txt.txt") {

           
            Number = number;
            FileName = File;
            {
                FileInfo file = new FileInfo(File);

                if (!file.Exists)
                {
                    if (rewrite) throw (new ArgumentException("there is no file to rewrite"));
                    file.Create();

                }
                if (number != 0)
                {
                    BitMapIndex = file.Length;
                    InfoIndex = BitMapIndex + CellsCount;
                }
                else
                {
                    BitMapIndex = 0;
                    InfoIndex = CellsCount;
                }
            }
                if (rewrite)
            {
                using (StreamWriter sw = new StreamWriter(File, number == 0 ? false : true))
                {
                    for (int i = 0; i < BitesPerCell + 1; i++)
                        for (int j = 0; j < CellsCount; j++)
                            sw.Write('0');
                }
            }
        }
        

        public bool IsHere(long index) {//проверяет входит ли индекс в данную страницу
            if (Number * CellsCount <= index && (Number + 1) * CellsCount - 1 >= index) return true;
            else return false;
        }

        public int GetLocalIndex(long index) { //возвращает индекс относительно этой страницы
            return (int)index - Number * CellsCount;
        }

        public void Rewrite(string target) {//копирует всю страницу из родительского файла в новый
            if (FileName == target) throw (new ArgumentException("Source file cant be target file"));
            using (StreamReader sr = new StreamReader(FileName)) {
                using (StreamWriter sw = new StreamWriter(target, true)) {
                    for (int i = 0; i < BitMapIndex; i++)
                        sr.Read();
                    for (int i = 0; i < CellsCount; i++)
                    {
                        char c = Convert.ToChar(sr.Read());
                        sw.Write(int.Parse(c.ToString()));
                    }
                    for (int i = 0; i < CellsCount; i++) {
                        StringBuilder str = new StringBuilder();
                        for (int j = 0; j < BitesPerCell; j++)
                            str.Append(Convert.ToChar(sr.Read()));
                        sw.Write(str.ToString());
                    }

                }
            }
        }

    }
}
