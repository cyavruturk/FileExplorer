using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbsuruculer.Items.AddRange(DriveInfo.GetDrives()); //cmbsürücüler comboBoxıma bilgisayarımın mantıksal sürülerini yükledim.(c: ve D: sürücüler (mantıksal sürücüler))
        }

        private void cmbsuruculer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo seciliSurucu = cmbsuruculer.SelectedItem as DriveInfo;  // as: Cast işlemi yapıyor!!!(as yerine unboxing işlemi yapsakda aynıydı)

            if (seciliSurucu != null && seciliSurucu.IsReady)   //secilisurucu null değilse ve secilisurucu hazırsa...
            {
                klasorleriDoldurBySurucu(seciliSurucu.Name);
            }
            else
            {
                MessageBox.Show("Sürücü yok ya da hazır değil!");
            }
        }
        void klasorleriDoldurBySurucu(string surucuAdi)
        {
            trwklasorler.Nodes.Clear();             //treevies (combobox ıtem gibi) nodes kullanılır. (içerisindeki olayları temizle)

            TreeNode surucuNode = new TreeNode();     //treeviwe nesnesi oluşturduk
            surucuNode.Text = surucuAdi;              //oluşturduğumuz node nesnesi surucuAdına atadık.
            trwklasorler.Nodes.Add(surucuNode);       //treevien nodelarına(ıtems gibi) surucuNode ları ekledik.  
            //Böylece seçilen surucu adları treenodeda çıktı.

            DirectoryInfo dizin = new DirectoryInfo(surucuAdi);   //surucu adı bizim pathmiz oluyor.
            DirectoryInfo[] klasorler = dizin.GetDirectories();   //GetDirectories::: Pathin(sürücüadı) altındaki klasorleri getir.

            foreach (DirectoryInfo item in klasorler)   //klasorlerin içibde tek tek dönüyoruz her birinn fullnameine erişiyoruz.
            {
                TreeNode klasorNode = new TreeNode();
                klasorNode.Text = item.Name;
                klasorNode.Tag = item.FullName;         //fullname propertiesini tag olarak aldık gittiği her yere orayıda alıcak
                surucuNode.Nodes.Add(klasorNode);        //treevie ile nesne oluşturmuştuk nodelar c'nin ya da D'nin altındaki klasorleri yerleştiricek.
            }
            surucuNode.Expand();                          //genişletmek demek . + işareti yerine direkt genişlet.
        }

        private void trwklasorler_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
            {
                altKlasorleriDoldur(item);
            }
        }

        private void trwklasorler_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cmbfiltrele.Items.Clear();
            cmbfiltrele.Items.Add(".*");
            lstbilgiler.Items.Clear();
            DosyalariListViewYukle(e.Node.FullPath, ".*");
            hedefalanı = trwklasorler.SelectedNode.FullPath;

        }

        void DosyalariListViewYukle(string fullPath, string fileExtension)
        {
            lstbilgiler.Items.Clear();
            cmbfiltrele.Items.Clear();

            long toplamboyut = 0;
            try
            {
                DirectoryInfo directoryinfo = new DirectoryInfo(fullPath);
                FileInfo[] dosyalarim = directoryinfo.GetFiles("*" + fileExtension);



                foreach (FileInfo item in dosyalarim)
                {
                    ListViewItem itm = new ListViewItem();
                    itm.Text = item.Name;
                    itm.Tag = item.FullName;

                    long boyut = item.Length;
                    toplamboyut = toplamboyut + boyut;
                    itm.SubItems.Add(boyutDonustur(boyut));    //subitem yan yana kolon gibi düşün boyut kolonuna ekleme yapıyor

                    DateTime olusturulmaTarihi = item.CreationTime;
                    itm.SubItems.Add(olusturulmaTarihi.ToString());

                    lstbilgiler.Items.Add(itm);

                    string yeniuzanti = item.Extension;
                    if (!cmbfiltrele.Items.Contains(yeniuzanti))
                    {
                        cmbfiltrele.Items.Add(yeniuzanti);

                    }
                }
            }
            catch
            {
                //ignore
            }
            tssToplamBoyut.Text = "Boyut:" + boyutDonustur(toplamboyut);
            tssToplamOge.Text = "Toplam Dosya Sayısı" + lstbilgiler.Items.Count;

            if (lstbilgiler.Items.Count == 0)
            {
                cmbfiltrele.Enabled = false;
                cmbfiltrele.Text = "";
            }
            else
            {
                cmbfiltrele.Text = "Uzantı seçiniz";
                cmbfiltrele.Enabled = true;
                cmbfiltrele.Tag = fullPath;

            }
        }
        public string boyutDonustur(long boyut)
        {
            string uzanti = "";

            if (boyut < 1024)
            {
                uzanti = "byte";
            }

            if (boyut >= (1024))
            {
                uzanti = "kbyte";
                boyut = boyut / 1024;
            }

            if (boyut >= 1024)
            {
                uzanti = "Mbyte";
                boyut = boyut / 1024;
            }

            if (boyut >= 1024)
            {
                uzanti = "Gbyte";
                boyut = boyut / 1024;
            }
            return boyut.ToString() + uzanti;
        }
        void altKlasorleriDoldur(TreeNode nd)
        {
            try
            {
                nd.Nodes.Clear();
                DirectoryInfo altdizin = new DirectoryInfo(nd.Tag.ToString());     //alt dizin 
                DirectoryInfo[] altklasorler = altdizin.GetDirectories();

                foreach (DirectoryInfo dialtklasorler in altklasorler)
                {
                    TreeNode altklasorNode = new TreeNode();
                    altklasorNode.Text = dialtklasorler.Name;
                    altklasorNode.Tag = dialtklasorler.FullName;
                    nd.Nodes.Add(altklasorNode);
                }
            }
            catch
            {
                //ignore    : tepki verme ama çalış böylece 
            }
        }

        private void cmbfiltrele_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbilgiler.Items.Clear();
            DosyalariListViewYukle((sender as ComboBox).Tag.ToString(), (sender as ComboBox).SelectedItem.ToString()); // sender bu iventi tetikleyen senderi cast ediyoruz

        }

        private void lstbilgiler_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start(lstbilgiler.SelectedItems[0].Tag.ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("Dosyayı açamıyoruz uygun program seçiniz!");
            }

        }

        #region 
        bool kopyalandi = false, kesildi = false;           //bool tipinde T/F olarak döndürecek 2 tane değişken oluşturduk bunlar kesip kesmediğini ya da kopyalayıp kopyalamadığını kontrol edicekler.
        string alinacakdosya, dosyaAd, hedefalanı;          // string tipinde kopyalanacak olan dosyayı adını ve kopyalayacağımız yeri belirten değişkenler oluşturduk.
        int secilenindis = 0;                               //secilen indis değeri adında int tipinde bir değişken oluşturduk 
        #endregion

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenindis < lstbilgiler.SelectedItems.Count)     //eğer secilenindis listviewdeki verilerin toplamından küçükse(yani tek bir adet seçim varsa)
            {
                File.Delete(lstbilgiler.SelectedItems[secilenindis].Tag.ToString());   //secilen indis değerinin bütün yollarını(dosya adı boyutu tarihi) sil.
                lstbilgiler.Items.Remove(lstbilgiler.SelectedItems[secilenindis]);    //listviewden remove ile kaldır. 
            }
            else
            {
                MessageBox.Show("Bir dosya seçiniz!");              //eğer dosya seçimi yoksa mesaj verdir.
            }
        }
       
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenindis < lstbilgiler.SelectedItems.Count)    //secilen indis listviewdeki verilerin toplamından küçükse 
            {
                alinacakdosya = lstbilgiler.SelectedItems[secilenindis].Tag.ToString();     //listviewdeki seçilen indis değerinin tüm tagini(etiketini yolunu vs) kopyalanacak olan dosyaya ata.
                dosyaAd = lstbilgiler.SelectedItems[secilenindis].Text;                     //secilen indisin tüm text(metin yazısını url si falan) dosyaAdına ata
                kopyalandi = true;                                                          //kopyalandımı evet de. Hafızada tutacak.
            }
            else
            {
                MessageBox.Show("Bir dosya seçiniz!");                                      //eğer bir seçim işlemi yoksa mesaj ver.
            }        
               
        }
        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenindis < lstbilgiler.SelectedItems.Count)   // secilen indis listviesdeki verilen toplamından küçükse
            {
                alinacakdosya = lstbilgiler.SelectedItems[secilenindis].Tag.ToString();  //kopyalamadaki işlemlerin aynısını gerçekleştir hafızada tut
                dosyaAd = lstbilgiler.SelectedItems[secilenindis].Text;
                kesildi = true;
            }
            else
            {
                MessageBox.Show("Bir dosya seçiniz!");
            }
            
        }
        private void yapistirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try            //olası bir patlamaya karşı önledik ve try catch bloğuna aldık.
            {
                if(kopyalandi == true)    //kopyalama işlemi gerçekleştiyse yani yukarısı true sa
                {
                    File.Copy(alinacakdosya, Path.Combine(hedefalanı, dosyaAd), true);  //file copy ile kopyalanacak dosyayı al, hedefalanını dosya adıyla birleştir ve işlemi gerçekleştir(true)
                    kopyalandi = false;                                                 //hafızadan bırak. (false);
                }

                else if (kesildi == true )                                             //eğer kesim işlemi yapıyorsak 
                {
                    File.Move(alinacakdosya, Path.Combine(hedefalanı, dosyaAd));        //file move ile taşıma işlemi olduğunu belirityoruz kopyalamadaki işlemlerin aynısını yapıyoruz. İşlem gerçekleştiğini belirtmiyoruz çünkü zaten hafızadan atacak.
                    kesildi = false;                                                    //hafızadan bırak
                }
            }
            catch    //exception fırlatmicak catch blogu çalışmicak. 
            {
                //ignore
            }
           
        }

        private void lstbilgiler_ColumnClick(object sender, ColumnClickEventArgs e)   //listviesin üzerine tıklandığında 
        {
            sirala sira = (sirala)lstbilgiler.ListViewItemSorter;     //siralama değerlerini listviewmiz üzerine alıyoruz.
            if (sira == null)                                         //eğer sıra değişkeni boşssa
            {
                sira = new sirala(e.Column);                         //yeni bir argüman değeri oluştur(kolon değerinde).
                sira.Order = SortOrder.Ascending;                    //sıralamayı artandan doğru yaptır.
                lstbilgiler.ListViewItemSorter = sira;               
            }
            if (e.Column == sira.Column)                            //eğer sıra değerimizle yeni oluşturduğumuz kolon değeri birbirini utuyorsa
            {
                if (sira.Order == SortOrder.Ascending)              //ve eğer sıralama artıyorsa
                    sira.Order = SortOrder.Descending;              //azalana doğru sırala.
                else
                    sira.Order = SortOrder.Ascending;               //sıralama tersse azalandan artıya doğru sırala
            }
            else
            {
                sira.Column = e.Column;                         //sıra kolonumuz ve yeni nesneyi eşitle 
                sira.Order = SortOrder.Ascending;               // azdan çoğa doğru yap.
            }

            lstbilgiler.Sort();                                 //listelemesini yap.
        }

    }
    public class sirala : IComparer        //listviewde sıralama yapabilmemiz için bir sınıf oluşturmamız gerekiyor.
    {
        public int Column { get; set; }   // kolon adında okuma ve yazma değeri alan bir değişken tanımladık
     
        public SortOrder Order { get; set; }   //sıralama belirttik
        public sirala(int colIndex)    //sırala adında method oluştyrduk
        {
            Column = colIndex;        //parametreyi read/write değeri alan değişkene aadık
            Order = SortOrder.None;  
        }
        public int Compare(object a, object b)   //compare metodu oluturduk obje parametreleri alıcak
        {
            int result;
            ListViewItem itemA = a as ListViewItem;    //listview nesnesi tanımladık 2 adet
            ListViewItem itemB = b as ListViewItem;
            if (itemA == null && itemB == null)        // atadığımız itemA ve itemB boş ise result değeri 0 dönecek
                result = 0;
            else if (itemA == null)                    //sadece itemA boşsa -1 döncek
                result = -1;
            else if (itemB == null)                     //sadece itemB boşsa 1 dönecek
                result = 1;
            if (itemA == itemB)                       //birbirlerine eşitlerse 0 dönecek
                result = 0;
   
            // kolonda bulunan verilerin tarih değerlerini karşılaştırıyoruz böylece sıralamayı buna göre yapabilelim
            DateTime x1, y1;
            if (!DateTime.TryParse(itemA.SubItems[Column].Text, out x1))
                x1 = DateTime.MinValue;
            if (!DateTime.TryParse(itemB.SubItems[Column].Text, out y1))
                y1 = DateTime.MinValue;
            result = DateTime.Compare(x1, y1);
            if (x1 != DateTime.MinValue && y1 != DateTime.MinValue)
                goto done;
         
            //kolondaki verilen sayı(boyut) değerlerlerini karşılaştırılıyoruz 
            decimal x2, y2;
            if (!Decimal.TryParse(itemA.SubItems[Column].Text, out x2))
                x2 = Decimal.MinValue;
            if (!Decimal.TryParse(itemB.SubItems[Column].Text, out y2))
                y2 = Decimal.MinValue;
            result = Decimal.Compare(x2, y2);
            if (x2 != Decimal.MinValue && y2 != Decimal.MinValue)
                goto done;
        
            //kolondaki verilen alfabetik(dosyaadı) değerlerini karşılaştırıyoruz
            result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
        done:
            if (Order == SortOrder.Descending)
                result *= -1;
            return result;
        }
    }
}