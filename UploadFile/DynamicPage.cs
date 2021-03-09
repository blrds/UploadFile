using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadFile
{
    class DynamicPage
    {
        public List<int> BitMap { get; private set; }

        public List<string> Info { get; private set; }//элементы

        public Page ThisPage { get; private set; }//Страница данных битмапы и элементов
        public DateTime LastUsage { get; private set; }//время последнего использования

        public bool isChanged { get; private set; }//было ли изменение

        public DynamicPage(Page ThisPage) {
            {
                FileInfo file = new FileInfo(ThisPage.FileName);
                if (file.Length < ThisPage.InfoIndex + Page.CellsCount * Page.BitesPerCell) throw (new InvalidDataException("Data files was corrupted"));
            }
            this.ThisPage = ThisPage;
            getBitMap();
            getInfo();
            LastUsage = DateTime.Now;
            isChanged = false;
        }
       

        private void getBitMap()//подгрузка битмапы
        {
            BitMap = new List<int>();
            using (StreamReader sr = new StreamReader(ThisPage.FileName))
            {

                for (int i = 0; i < ThisPage.Number * Page.CellsCount * (Page.BitesPerCell + 1); i++)
                    sr.Read();
                for (int i = 0; i < Page.CellsCount; i++)
                {
                    char c = Convert.ToChar(sr.Read());
                    BitMap.Add(int.Parse(c.ToString()));
                }
            }
        }
        private void getInfo()//подгрузка элементов
        {
            Info = new List<string>();
            using (StreamReader sr = new StreamReader(ThisPage.FileName))
            {

                for (int i = 0; i < ThisPage.InfoIndex; i++)
                    sr.Read();
                for (int i = 0; i < Page.CellsCount; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < Page.BitesPerCell; j++)
                        sb.Append(Convert.ToChar(sr.Read()));
                    Info.Add(sb.ToString());
                }
            }
        }
        public bool IsSomethinigIn(long index)//да, если элемент есть, нет, если ничего не записано
        {
            if (ThisPage.IsHere(index))
            {                
                int localIndex = ThisPage.GetLocalIndex(index);
                bool help = Convert.ToBoolean(BitMap[localIndex]);
                return help;
            }
            throw (new ArgumentException("Index out of range"));//если индекс не здешний
            return false;
        }

        private string Zeros()//возращает нулевую строку для записи пустого элемента
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Page.BitesPerCell; i++)
                str.Append("0");
            return str.ToString();
        }
        public string Item(long index)//возращает элемент или ""
        {
            if (ThisPage.IsHere(index))
            {
                int localIndex = ThisPage.GetLocalIndex(index);
                string str;
                LastUsage = DateTime.Now;
                if (BitMap[localIndex] == 1) str = Info[localIndex];
                else str = "";
                return str;
            }
            else throw (new ArgumentException("Index out of range"));
        }
        private bool isByte(char a)//проверяет, является ли страка 16ричной
        {
            if (char.IsDigit(a)) return true;
            if (char.IsLower(a)) return false;
            if (a >= 'A' && a <= 'F') return true;
            return false;
        }

        public bool WriteAt(string bytes, long index)//запись по индексу
        {
            for (int i = 0; i < bytes.Length; i++)
                if (!isByte(bytes[i])) throw new ArgumentException("NON Byte symbol");
            int localIndex = ThisPage.GetLocalIndex(index);
            BitMap[localIndex] = 1;
            Info[localIndex] = bytes;
            LastUsage = DateTime.Now;
            isChanged = true;
            return true;
        }


        public bool DeleteAt(long index)//удаляет по индексу
        {
            int localIndex = ThisPage.GetLocalIndex(index);
            BitMap[localIndex] = 0;
            Info[localIndex] = Zeros();
            LastUsage = DateTime.Now;
            isChanged = true;
            return true;
        }

        public void Save(string FileName)//записывает эту страницу в файл
        {
            using (StreamWriter sw = new StreamWriter(FileName, true))
            {
                foreach (var a in BitMap)//запись битмапы
                {
                    sw.Write(a);
                }
                foreach (var a in Info)//запись элементов
                {
                    sw.Write(a);
                }
            }
        }
    }
}
