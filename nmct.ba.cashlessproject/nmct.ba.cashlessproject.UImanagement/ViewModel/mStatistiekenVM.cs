using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using Newtonsoft.Json;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class mStatistiekenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Statistiek"; }
        }

        public mStatistiekenVM()
        {
            GetRegisters();
            GetProducts();
            GetSales();
        }

        private ObservableCollection<Registers> _registers;
        public ObservableCollection<Registers> Registers
        {
            get { return _registers; }
            set
            {
                _registers = value;
                OnPropertyChanged("Registers");
            }
        }

        private ObservableCollection<Products> _products;
        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        private Registers _selectedRegister;
        public Registers SelectedRegister
        {
            get { return _selectedRegister; }
            set
            {
                _selectedRegister = value;
                OnPropertyChanged("SelectedRegister");
            }
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private ObservableCollection<Sales> _sales;
        public ObservableCollection<Sales> Sales
        {
            get { return _sales; }
            set
            {
                _sales = value;
                OnPropertyChanged("Sales");
                ShowSales = Sales;
            }
        }

        private ObservableCollection<Sales> _showSales;
        public ObservableCollection<Sales> ShowSales
        {
            get { return _showSales; }
            set
            {
                _showSales = value;
                OnPropertyChanged("ShowSales");
                BerekenTotaal();
            }
        }

        private DateTime _van = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public DateTime Van
        {
            get { return _van; }
            set
            {
                _van = value;
                OnPropertyChanged("Van");
                VanChanged = true;
            }
        }

        private DateTime _tot = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public DateTime Tot
        {
            get { return _tot; }
            set
            {
                _tot = value;
                OnPropertyChanged("Tot");
                TotChanged = true;
            }
        }

        private double _totaal;
        public double Totaal
        {
            get { return _totaal; }
            set
            {
                _totaal = value;
                OnPropertyChanged("Totaal");
            }
        }

        private Boolean _vanChanged;
        public Boolean VanChanged
        {
            get { return _vanChanged; }
            set
            {
                _vanChanged = value;
                OnPropertyChanged("VanChanged");
            }
        }

        private Boolean _totChanged;
        public Boolean TotChanged
        {
            get { return _totChanged; }
            set
            {
                _totChanged = value;
                OnPropertyChanged("TotChanged");
            }
        }

        private async void GetRegisters()
        {
            Registers r = new Registers();
            r.ID = 0;
            r.RegisterName = "Alle Kassa's";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Kassa");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Registers = JsonConvert.DeserializeObject<ObservableCollection<Registers>>(json);
                    Registers.Add(r);
                }
            }
        }

        //Products ophalen
        private async void GetProducts()
        {
            Products p = new Products();
            p.ID = 0;
            p.ProductName = "Alle Producten";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Product");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
                    Products.Add(p);
                }
            }
        }

        //Sales ophalen
        private async void GetSales()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Sale");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Sales = JsonConvert.DeserializeObject<ObservableCollection<Sales>>(json);
                }
            }
        }

        public ICommand SearchStatsCommand
        {
            get { return new RelayCommand(SearchStats); }
        }

        private void SearchStats()
        {
            ShowSales = new ObservableCollection<Sales>();
            DateTime standardDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            if (VanChanged == true && TotChanged == true && SelectedRegister != null && SelectedRegister.ID > 0 && SelectedProduct != null && SelectedProduct.ID > 0)
            {
                foreach (Sales s in Sales)
                {
                    if (s.Timestamp.Ticks > Van.Ticks && s.Timestamp.Ticks < Tot.Ticks && s.RegisterID == SelectedRegister.ID && s.ProductID == SelectedProduct.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == true && TotChanged == true && SelectedRegister != null && SelectedRegister.ID > 0 && (SelectedProduct == null || SelectedProduct.ID == 0))
            {
                foreach (Sales s in Sales)
                {
                    if (s.Timestamp.Ticks > Van.Ticks && s.Timestamp.Ticks < Tot.Ticks && s.RegisterID == SelectedRegister.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == true && TotChanged == true && (SelectedRegister == null || SelectedRegister.ID == 0) && SelectedProduct != null && SelectedProduct.ID > 0)
            {
                foreach (Sales s in Sales)
                {
                    if (s.Timestamp.Ticks > Van.Ticks && s.Timestamp.Ticks < Tot.Ticks && s.ProductID == SelectedProduct.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == false && TotChanged == false && SelectedRegister != null && SelectedRegister.ID > 0 && SelectedProduct != null && SelectedProduct.ID > 0)
            {
                foreach (Sales s in Sales)
                {
                    if (s.RegisterID == SelectedRegister.ID && s.ProductID == SelectedProduct.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged && TotChanged == true && (SelectedRegister == null || SelectedRegister.ID == 0) && (SelectedProduct == null || SelectedProduct.ID == 0))
            {
                foreach (Sales s in Sales)
                {
                    if (s.Timestamp.Ticks > Van.Ticks && s.Timestamp.Ticks < Tot.Ticks)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == false && TotChanged == false && SelectedRegister != null && SelectedRegister.ID > 0 && (SelectedProduct == null || SelectedProduct.ID == 0))
            {
                foreach (Sales s in Sales)
                {
                    if (s.RegisterID == SelectedRegister.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == false && TotChanged == false && (SelectedRegister == null || SelectedRegister.ID == 0) && SelectedProduct != null && SelectedProduct.ID > 0)
            {
                foreach (Sales s in Sales)
                {
                    if (s.ProductID == SelectedProduct.ID)
                        ShowSales.Add(s);
                }
            }

            if (VanChanged == false && TotChanged == false && (SelectedRegister == null || SelectedRegister.ID == 0) && (SelectedProduct == null || SelectedProduct.ID == 0))
                ShowSales = Sales;

            BerekenTotaal();
        }

        //totaal berekenen
        void BerekenTotaal()
        {
            Totaal = 0;

            foreach (Sales s in ShowSales)
                Totaal += s.TotalPrice;
        }

        public ICommand ExportToExcelCommand
        {
            get { return new RelayCommand(ExportToExcel); }
        }

        private void ExportToExcel()
        {
            DateTime time = DateTime.Now;
            string t = time.ToString("dd-MM-yy.hhumm");

            string FromDate, UntilDate, kName, pName;

            if (VanChanged == true)
                FromDate = Van.ToString("dd-MM-yy");
            else
                FromDate = "-";

            if (TotChanged == true)
                UntilDate = Tot.ToString("dd-MM-yy");
            else
                UntilDate = "-";

            if (SelectedRegister != null && SelectedRegister.ID > 0)
                kName = SelectedRegister.RegisterName;
            else
                kName = "-";

            if (SelectedProduct != null && SelectedProduct.ID > 0)
                pName = SelectedProduct.ProductName;
            else
                pName = "-";

            //Document aanmaken
            SpreadsheetDocument doc = SpreadsheetDocument.Create("Statistiek" + t + ".xlsx", SpreadsheetDocumentType.Workbook);

            WorkbookPart wbp = doc.AddWorkbookPart();
            wbp.Workbook = new Workbook();

            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            SheetData data = new SheetData();
            wsp.Worksheet = new Worksheet(data);

            Sheets sheets = doc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = doc.WorkbookPart.GetIdOfPart(wsp),
                SheetId = 1,
                Name = "Statistieken"
            };
            sheets.Append(sheet);

            //Gezochte data toevoegen
            Row zoekdata = new Row() { RowIndex = 1 };
            Cell van = new Cell() { CellReference = "A1", DataType = CellValues.String, CellValue = new CellValue("Van:") };
            Cell vanzd = new Cell() { CellReference = "B1", DataType = CellValues.String, CellValue = new CellValue(FromDate) };
            Cell tot = new Cell() { CellReference = "C1", DataType = CellValues.String, CellValue = new CellValue("Tot:") };
            Cell totzd = new Cell() { CellReference = "D1", DataType = CellValues.String, CellValue = new CellValue(UntilDate) };
            Cell kassa = new Cell() { CellReference = "E1", DataType = CellValues.String, CellValue = new CellValue("Kassa:") };
            Cell kassazd = new Cell() { CellReference = "F1", DataType = CellValues.String, CellValue = new CellValue(kName) };
            Cell product = new Cell() { CellReference = "G1", DataType = CellValues.String, CellValue = new CellValue("Product:") };
            Cell productzd = new Cell() { CellReference = "H1", DataType = CellValues.String, CellValue = new CellValue(pName) };

            zoekdata.Append(van, vanzd, tot, totzd, kassa, kassazd, product, productzd);
            data.Append(zoekdata);

            //Kolommen toevoegen
            Row header = new Row() { RowIndex = 3 };
            Cell kassah = new Cell() { CellReference = "A3", DataType = CellValues.String, CellValue = new CellValue("Kassa") };
            Cell producth = new Cell() { CellReference = "B3", DataType = CellValues.String, CellValue = new CellValue("Product") };
            Cell tijdstiph = new Cell() { CellReference = "C3", DataType = CellValues.String, CellValue = new CellValue("Datum") };
            Cell aantalh = new Cell() { CellReference = "D3", DataType = CellValues.String, CellValue = new CellValue("Aantal") };
            Cell prijsh = new Cell() { CellReference = "E3", DataType = CellValues.String, CellValue = new CellValue("Prijs") };
            Cell totprijsh = new Cell() { CellReference = "F3", DataType = CellValues.String, CellValue = new CellValue("Totale Prijs") };

            header.Append(kassah, producth, tijdstiph, aantalh, prijsh, totprijsh);
            data.Append(header);

            //Data invullen
            int i;
            int c = ShowSales.Count;

            for (i = 0; i < c; i++)
            {
                int ii = i + 4;
                Row sale = new Row() { RowIndex = Convert.ToUInt32(ii) };
                Cell kassaName = new Cell() { CellReference = "A" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].RegisterName) };
                Cell productName = new Cell() { CellReference = "B" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].ProductName) };
                Cell tijdstip = new Cell() { CellReference = "C" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].Timestamp.ToString()) };
                Cell aantal = new Cell() { CellReference = "D" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].Amount.ToString()) };
                Cell prijs = new Cell() { CellReference = "E" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].Price.ToString()) };
                Cell totprijs = new Cell() { CellReference = "F" + ii, DataType = CellValues.String, CellValue = new CellValue(ShowSales[i].TotalPrice.ToString()) };

                sale.Append(kassaName, productName, tijdstip, aantal, prijs, totprijs);
                data.Append(sale);
            }

            //Bestand opslaan
            wbp.Workbook.Save();
            doc.Close();

            MessageBox.Show("Statistieken exporteren geslaagd.","Geslaagd!");
        }
    }
}
