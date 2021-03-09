using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadFile
{
    class UploadFileUser
    {
        private const int PageCount= 5;
        List<Page> Pages { get; set; }

        List<DynamicPage> LivingPages { get; set; }
        public string FilePath { get; private set; }
        public UploadFileUser(long ElementsCount, bool rewrite, string FileName="txt.txt") {
            FilePath = FileName;
            Pages = new List<Page>();
            int listCount =(int)( ElementsCount / Page.CellsCount);
            listCount += ElementsCount % Page.CellsCount != 0 ? 1 : 0;
            for (int i = 0; i < listCount; i++)
                Pages.Add(new Page(i,rewrite ,FileName));
            LivingPages = new List<DynamicPage>(PageCount);
            for (int i = 0; i < PageCount; i++) {
                LivingPages.Add(null);
            }
        }

        private int IndexOfPage(int number) {
            for (int i = 0; i < PageCount; i++) {
                try
                {
                    if (LivingPages[i].ThisPage.Number == number) return i;
                }
                catch (Exception e) { }
            }
            return -1;
        }//индекс нужной странице среди подгруженных

        private void RewriteExcept(int number) {
            string TmpFile = "tmp.txt";
            {

                FileInfo file = new FileInfo(TmpFile);
                if (!file.Exists) file.Create();
                else using (StreamWriter sw = new StreamWriter(TmpFile, false))
                    {
                        sw.Write("");
                    }
            }
            foreach (var a in Pages)
            {
                if (a.Number != number) a.Rewrite(TmpFile);
                else { LivingPages[IndexOfPage(a.Number)].Save(TmpFile); }
            }
            FileInfo oldFile = new FileInfo(FilePath);
            oldFile.Delete();
            FileInfo newFile = new FileInfo(TmpFile);
            newFile.MoveTo(FilePath);
        }//записывает все страницы без изменений кроме 

        private int Oldest() {
            int index = 0; try
            {
                DateTime max = LivingPages[0].LastUsage;
                for (int i = 1; i < PageCount; i++)
                {
                    if (max < LivingPages[i].LastUsage)
                    {
                        max = LivingPages[i].LastUsage;
                        index = i;
                    }
                }
            }
            catch (Exception e) { }
            return index;
        }//страницы со старейшим вмешательством

        private int LoadNewPage(int number) {
            for (int i=0;i<PageCount;i++) {
                if (LivingPages[i] == null) {
                    LivingPages[i] = new DynamicPage(Pages[number]);
                    return i;
                }
            }
            int oldest = Oldest();
            RewriteExcept(oldest);
            LivingPages[oldest] = new DynamicPage(Pages[number]);
            return oldest;
        }//подгрузка новой страницы заместо старейшей

        private int WhichPageIsItOn(long index) {
            foreach (var a in Pages) {
                if (a.IsHere(index)) {
                    return a.Number;
                }
            }
            throw (new ArgumentException("Index out of range"));
            return -1;
        }
        
        private int getThePageReady(long indexOfItem) {
            int page = WhichPageIsItOn(indexOfItem) ;
            int livingPage = IndexOfPage(page);
            if (livingPage == -1)
            {
                livingPage = LoadNewPage(page);
            }
            return livingPage;
        }//проверит, подгруженна ли нужная страница по номеру лемента, если нет, то загрузит ее

        public Tuple<string, int> Item(long index) {//вывод элемента на экран
            int livingPage = getThePageReady(index);
            return new Tuple<string, int>(LivingPages[livingPage].Item(index), LivingPages[livingPage].ThisPage.Number);
        }

        public int Write(string item, long index) {//запись элемента
            int page = WhichPageIsItOn(index);
            int livingPage = getThePageReady(index);            
            LivingPages[livingPage].WriteAt(item, index);
            return page;
        }

        public int Delete(long index) {//удаление элемента
            int page = WhichPageIsItOn(index);
            int livingPage = getThePageReady(index);
            LivingPages[livingPage].DeleteAt(index);
            return page;
        }

        /*

        старый сейв на всякий случай
        public void Save() {
            
        if (Pages.Where(x => x.isChanged).Count() == 0) throw (new Exception("Save doesnt needed"));
            string TmpFile = "tmp.txt";
            {
               
                FileInfo file = new FileInfo(TmpFile);
                if (!file.Exists) file.Create();
                else using (StreamWriter sw = new StreamWriter(TmpFile, false)) {
                        sw.Write("");
                    }
            }
            foreach (var a in Pages) {
                if (a.isChanged)
                    a.Save(TmpFile);
                else
                    a.Rewrite(TmpFile);
            }
            FileInfo oldFile = new FileInfo(FilePath);
            oldFile.Delete();
            FileInfo newFile = new FileInfo(TmpFile);
            newFile.MoveTo(FilePath);
        }*/

    }
}
