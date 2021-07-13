using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
namespace ClientWPF
{
    class ImagineModel
    {
        CarService.Imagine imagine;
        public int ImagineId { get { return imagine.ImagineId; } }
        public string Titlu { get { return imagine.Titlu; } }
        public string Descriere { get { return imagine.Descriere; } }
        public DateTime Data { get { return imagine.Data; } }
        public BitmapImage Foto
        {
            get
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(imagine.Foto);
                image.DecodePixelWidth = 100;
                image.EndInit();         
                return image;
            }
        }
        public int DetaliuComandaDetaliuComandaId { get { return imagine.DetaliuComanda.DetaliuComandaId; } }
        public ImagineModel(CarService.Imagine imagine)
        {
            this.imagine = imagine;
        }
    }

    class DetaliuComandaModel
    {
        CarService.DetaliuComanda detaliuComanda;
        public int DetaliuComandaId { get { return detaliuComanda.DetaliuComandaId; } }
        public int ComandaComandaId { get { return detaliuComanda.ComandaComandaId; } }
        public int MaterialMaterialId { get { return detaliuComanda.MaterialMaterialId; } }
        public int MecanicMecanicId { get { return detaliuComanda.MecanicMecanicId; } }
        public int OperatieOperatieId { get { return detaliuComanda.OperatieOperatieId; } }
        public int ImagineImagineId { get { return detaliuComanda.Imagine.ImagineId; } }
        public DetaliuComandaModel(CarService.DetaliuComanda detaliuComanda)
        {
            this.detaliuComanda = detaliuComanda;
        }
    }




    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceClient c = new ServiceClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor autoturisme.
        /// </summary>
        private void AutoColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "AutoId",
                Binding = new Binding("AutoId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "NumarAuto",
                Width = DataGridLength.Auto,
                Binding = new Binding("NumarAuto")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "SasiuId",
                Width = DataGridLength.Auto,
                Binding = new Binding("SasiuSasiuId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "SerieSasiu",
                Width = DataGridLength.Auto,
                Binding = new Binding("SerieSasiu")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "ClientId",
                Width = DataGridLength.Auto,
                Binding = new Binding("ClientClientId")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza autoturismele dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="autoCollection">Colectie de autoturisme.</param>
        private void AutoView(IEnumerable<CarService.Auto> autoCollection)
        {
            AutoColumns();
            foreach (var item in autoCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor clienti.
        /// </summary>
        private void ClientColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "ClientId",
                Binding = new Binding("ClientId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Nume",
                Width = DataGridLength.Auto,
                Binding = new Binding("Nume")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Prenume",
                Width = DataGridLength.Auto,
                Binding = new Binding("Prenume")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Adresa",
                Width = DataGridLength.Auto,
                Binding = new Binding("Adresa")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Localitate",
                Width = DataGridLength.Auto,
                Binding = new Binding("Localitate")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Judet",
                Width = DataGridLength.Auto,
                Binding = new Binding("Judet")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Telefon",
                Width = DataGridLength.Auto,
                Binding = new Binding("Telefon")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Email",
                Width = DataGridLength.Auto,
                Binding = new Binding("Email")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza clientii dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="clientCollection">Colectie de clienti.</param>
        private void ClientView(IEnumerable<CarService.Client> clientCollection)
        {
            ClientColumns();
            foreach (var item in clientCollection)
                entitiesDataGrid.Items.Add(item);
        }
        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor sasiuri.
        /// </summary>
        private void SasiuColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "SasiuId",
                Binding = new Binding("SasiuId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "CodSasiu",
                Width = DataGridLength.Auto,
                Binding = new Binding("CodSasiu")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Denumire",
                Width = DataGridLength.Auto,
                Binding = new Binding("Denumire")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza sasiurile dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="sasiuCollection">Colectie de sasiuri.</param>
        private void SasiuView(IEnumerable<CarService.Sasiu> sasiuCollection)
        {
            SasiuColumns();
            foreach (var item in sasiuCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor mecanici.
        /// </summary>
        private void MecanicColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "MecanicId",
                Binding = new Binding("MecanicId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Nume",
                Width = DataGridLength.Auto,
                Binding = new Binding("Nume")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Prenume",
                Width = DataGridLength.Auto,
                Binding = new Binding("Prenume")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza mecanicii dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="mecanicCollection">Colectie de mecanici.</param>
        private void MecanicView(IEnumerable<CarService.Mecanic> mecanicCollection)
        {
            MecanicColumns();
            foreach (var item in mecanicCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor materiale.
        /// </summary>
        private void MaterialColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "MaterialId",
                Binding = new Binding("MaterialId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Denumire",
                Width = DataGridLength.Auto,
                Binding = new Binding("Denumire")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Cantitate",
                Width = DataGridLength.Auto,
                Binding = new Binding("Cantitate")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Pret",
                Width = DataGridLength.Auto,
                Binding = new Binding("Pret")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "DataAprovizionare",
                Width = DataGridLength.Auto,
                Binding = new Binding("DataAprovizionare")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza materialele dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="materialCollection">Colectie de materiale.</param>
        private void MaterialView(IEnumerable<CarService.Material> materialCollection)
        {
            MaterialColumns();
            foreach (var item in materialCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor operatii.
        /// </summary>
        private void OperatieColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "OperatieId",
                Binding = new Binding("OperatieId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Denumire",
                Width = DataGridLength.Auto,
                Binding = new Binding("Denumire")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "TimpExecutie",
                Width = DataGridLength.Auto,
                Binding = new Binding("TimpExecutie")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza operatiile dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="operatieCollection">Colectie de operatii.</param>
        private void OperatieView(IEnumerable<CarService.Operatie> operatieCollection)
        {
            OperatieColumns();
            foreach (var item in operatieCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor imagini.
        /// </summary>
        private void ImagineColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "ImagineId",
                Binding = new Binding("ImagineId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "DetaliuComandaId",
                Width = DataGridLength.Auto,
                Binding = new Binding("DetaliuComandaDetaliuComandaId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Titlu",
                Width = DataGridLength.Auto,
                Binding = new Binding("Titlu")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Descriere",
                Width = DataGridLength.Auto,
                Binding = new Binding("Descriere")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Data",
                Width = DataGridLength.Auto,
                Binding = new Binding("Data")
            };
            entitiesDataGrid.Columns.Add(col);
            DataGridTemplateColumn col1 = (DataGridTemplateColumn)this.FindResource("dgt");
            entitiesDataGrid.Columns.Add(col1);
        }

        /// <summary>
        /// Afiseaza imaginile dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="imagineCollection">Colectie de imagini.</param>
        private void ImagineView(IEnumerable<CarService.Imagine> imagineCollection)
        {
            ImagineColumns();
            foreach (var item in imagineCollection)
            {
                entitiesDataGrid.Items.Add(new ImagineModel(item));
            }
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor comenzi.
        /// </summary>
        private void ComandaColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "ComandaId",
                Binding = new Binding("ComandaId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "ClientId",
                Width = DataGridLength.Auto,
                Binding = new Binding("ClientClientId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "AutoId",
                Width = DataGridLength.Auto,
                Binding = new Binding("AutoAutoId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "StareComanda",
                Width = DataGridLength.Auto,
                Binding = new Binding("StareComanda")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "DataSystem",
                Width = DataGridLength.Auto,
                Binding = new Binding("DataSystem")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "DataProgramare",
                Width = DataGridLength.Auto,
                Binding = new Binding("DataProgramare")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "DataFinalizare",
                Width = DataGridLength.Auto,
                Binding = new Binding("DataFinalizare")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "KmBord",
                Width = DataGridLength.Auto,
                Binding = new Binding("KmBord")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "Descriere",
                Width = DataGridLength.Auto,
                Binding = new Binding("Descriere")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "ValoarePiese",
                Width = DataGridLength.Auto,
                Binding = new Binding("ValoarePiese")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza comenzile dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="comandaCollection">Colectie de comenzi.</param>
        private void ComandaView(IEnumerable<CarService.Comanda> comandaCollection)
        {
            ComandaColumns();
            foreach (var item in comandaCollection)
                entitiesDataGrid.Items.Add(item);
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGrid pentru afisarea unor detalii ale unor comenzi.
        /// </summary>
        private void DetaliuComandaColumns()
        {
            entitiesDataGrid.Visibility = Visibility.Visible;
            entitiesDataGrid.Columns.Clear();
            entitiesDataGrid.Items.Clear();
            DataGridTextColumn col = new DataGridTextColumn
            {
                Header = "DetaliuComandaId",
                Binding = new Binding("DetaliuComandaId"),
                Width = DataGridLength.Auto
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "ComandaId",
                Width = DataGridLength.Auto,
                Binding = new Binding("ComandaComandaId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "MecanicId",
                Width = DataGridLength.Auto,
                Binding = new Binding("MecanicMecanicId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "MaterialId",
                Width = DataGridLength.Auto,
                Binding = new Binding("MaterialMaterialId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "OperatieId",
                Width = DataGridLength.Auto,
                Binding = new Binding("OperatieOperatieId")
            };
            entitiesDataGrid.Columns.Add(col);
            col = new DataGridTextColumn
            {
                Header = "ImagineId",
                Width = DataGridLength.Auto,
                Binding = new Binding("ImagineImagineId")
            };
            entitiesDataGrid.Columns.Add(col);
        }

        /// <summary>
        /// Afiseaza detaliile unor comenzi dintr-o colectie in obiectul de tip DataGrid.
        /// </summary>
        /// <param name="detaliuComandaCollection">Colectie de detalii comenzi.</param>
        private void DetaliuComandaView(IEnumerable<CarService.DetaliuComanda> detaliuComandaCollection)
        {
            DetaliuComandaColumns();
            foreach (var item in detaliuComandaCollection)
                entitiesDataGrid.Items.Add(new DetaliuComandaModel(item));
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Adaugare, creeaza o noua fereastra
        /// </summary>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (entitiesComboBox.SelectedIndex > -1)
            {
                var selected = entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1];
                var addW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF." + selected + "Window"));
                var b = (Button)addW.FindName("button");
                b.Click += Add_Click;
                ((TextBox)addW.FindName(char.ToLower(selected[0]) + selected.Substring(1, selected.Length - 1) + "IdTextBox")).IsReadOnly = true;
                if (selected == "Comanda")
                {
                    ((TextBox)addW.FindName("dataSystemTextBox")).IsReadOnly = true;
                    ((TextBox)addW.FindName("clientIdTextBox")).IsReadOnly = true;
                }
                else if (selected=="DetaliuComanda")
                {
                    ((TextBox)addW.FindName("imagineIdTextBox")).IsReadOnly = true;
                }
                addW.ShowDialog();
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din fereastra suplimentara pentru adaugare, se ocupa de adaugarea propriu-zisa in baza de date.
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selected = entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1];
            Type type = Type.GetType("CarService." + selected + ",CarService");
            CarService.Entitate item = (CarService.Entitate)Activator.CreateInstance(type);
            Window addW = GetWindow((Button)sender);
            try
            {
                foreach (var element in LogicalTreeHelper.GetChildren(addW))
                {
                    if (element.ToString() == "System.Windows.Controls.Grid")
                    {
                        foreach (var ctrl in LogicalTreeHelper.GetChildren((FrameworkElement)element))
                        {
                            if (ctrl is TextBox ctrl1)
                            {
                                if (ctrl1.Text != "")
                                {
                                    string name = ctrl1.Name;
                                    string propertyName = char.ToUpper(name[0]) + name.Substring(1, name.Length - 8);
                                    if (propertyName.EndsWith("Id") && !propertyName.StartsWith(selected))
                                        propertyName = propertyName.Substring(0, propertyName.Length - 2) + propertyName;
                                    if (propertyName == "DetaliuComandaDetaliuComandaId")
                                    {
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        var dict = new Dictionary<string, object>();
                                        dict["detaliuComandaId"] = value;
                                        dict["comandaId"] = -1;
                                        dict["mecanicId"] = -1;
                                        dict["materialId"] = -1;
                                        dict["operatieId"] = -1;
                                        ((CarService.Imagine)item).DetaliuComanda = c.FirstOrDefaultDetaliuComanda(dict, "Imagine");
                                        continue;
                                    }
                                    PropertyInfo prop = type.GetProperty(propertyName);
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(int?))
                                    {
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        if (!decimal.TryParse(ctrl1.Text, out decimal value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        if (!DateTime.TryParse(ctrl1.Text, out DateTime value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(byte[]))
                                    {
                                        try
                                        {
                                            var value = File.ReadAllBytes(ctrl1.Text);
                                            prop.SetValue(item, value, null);
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Imaginea nu poate fi citita", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (ctrl1.Name == "telefonTextBox" && ctrl1.Text.Any(c => c < '0' || c > '9'))
                                        {
                                            MessageBox.Show("Nr de telefon nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        if (ctrl1.Name == "emailTextBox")
                                        {
                                            try
                                            {
                                                var addr = new MailAddress(ctrl1.Text);
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("email nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                                return;
                                            }
                                        }
                                        if (ctrl1.Name == "numarAutoTextBox")
                                        {
                                            if (ctrl1.Text.Count() != 10 ||
                                            !(
                                            (ctrl1.Text[0] >= 'A' && ctrl1.Text[0] <= 'Z' && ctrl1.Text[1] >= 'A' && ctrl1.Text[1] <= 'Z' &&
                                            ctrl1.Text[2] == ' ' && ctrl1.Text[3] >= '0' && ctrl1.Text[3] <= '9' &&
                                            ctrl1.Text[4] >= '0' && ctrl1.Text[4] <= '9' && ctrl1.Text[5] >= '0' && ctrl1.Text[5] <= '9' &&
                                            ctrl1.Text[6] == ' ' && ctrl1.Text[7] >= 'A' && ctrl1.Text[7] <= 'Z' && ctrl1.Text[8] >= 'A' &&
                                            ctrl1.Text[8] <= 'Z' && ctrl1.Text[9] >= 'A' && ctrl1.Text[9] <= 'Z'
                                            ) ||
                                            (
                                            ctrl1.Text[0] >= 'A' && ctrl1.Text[0] <= 'Z' && ctrl1.Text[1] >= 'A' && ctrl1.Text[1] <= 'Z' &&
                                            ctrl1.Text[2] >= '0' && ctrl1.Text[2] <= '9' && ctrl1.Text[3] >= '0' && ctrl1.Text[3] <= '9' &&
                                            ctrl1.Text[4] >= '0' && ctrl1.Text[4] <= '9' && ctrl1.Text[5] >= '0' && ctrl1.Text[5] <= '9' &&
                                            ctrl1.Text[6] >= '0' && ctrl1.Text[6] <= '9' && ctrl1.Text[7] >= '0' && ctrl1.Text[7] <= '9' &&
                                            ctrl1.Text[8] >= '0' && ctrl1.Text[8] <= '9' && ctrl1.Text[9] >= '0' && ctrl1.Text[9] <= '9'
                                            ))
                                            )
                                            {
                                                MessageBox.Show("Numar auto nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                                return;
                                            }
                                        }
                                        if (ctrl1.Name == "codSasiuTextBox" && (ctrl1.Text.Count() != 2 || !char.IsLetterOrDigit(ctrl1.Text[0]) || !char.IsLetterOrDigit(ctrl1.Text[1])))
                                        {
                                            MessageBox.Show("Cod sasiu nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, ctrl1.Text, null);
                                    }

                                }
                                else if (!(selected == "DetaliuComanda" && ctrl1.Name == "imagineIdTextBox") && !(selected == "Comanda" && (ctrl1.Name == "clientIdTextBox" || ctrl1.Name == "dataSystemTextBox")) && !ctrl1.Name.StartsWith(selected, StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Proprietate obligatorie", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                }
                switch (selected)
                {
                    case "Auto":
                        var auto = (CarService.Auto)item;
                        if (!auto.SerieSasiu.Substring(6, 2).Equals(c.GetSasiuById(auto.SasiuSasiuId).CodSasiu))
                        {
                            MessageBox.Show("Nepotrivire intre codul sasiu si codul de pe pozitiile 7,8 din seria sasiu", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        c.AddAuto(auto);
                        AutoView(c.GetAutoturisme(null, null, "Sasiu,Comenzi.DetaliiComenzi.Material"));
                        break;
                    case "Client":
                        var cl = (CarService.Client)item;
                        c.AddClient(cl);
                        ClientView(c.GetClienti(null, null, "Autoturisme,Comenzi"));
                        break;
                    case "Comanda":
                        var comanda = (CarService.Comanda)item;
                        comanda.DataSystem = DateTime.Now;
                        comanda.ClientClientId = c.GetAutoById(comanda.AutoAutoId).ClientClientId;
                        c.AddComanda(comanda);
                        ComandaView(c.GetComenzi(null, null, "DetaliiComenzi.Material,DetaliiComenzi.Imagine"));
                        break;
                    case "DetaliuComanda":
                        var detaliuComanda = (CarService.DetaliuComanda)item;
                        c.AddDetaliuComanda(detaliuComanda);
                        DetaliuComandaView(c.GetDetaliiComenzi(null, null, "Imagine"));
                        break;
                    case "Mecanic":
                        var mecanic = (CarService.Mecanic)item;
                        c.AddMecanic(mecanic);
                        MecanicView(c.GetMecanici(null, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Material":
                        var material = (CarService.Material)item;
                        c.AddMaterial(material);
                        MaterialView(c.GetMateriale(null, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Operatie":
                        var operatie = (CarService.Operatie)item;
                        c.AddOperatie(operatie);
                        OperatieView(c.GetOperatii(null, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Sasiu":
                        var sasiu = (CarService.Sasiu)item;
                        c.AddSasiu(sasiu);
                        SasiuView(c.GetSasiuri(null, null, "Autoturisme"));
                        break;
                    case "Imagine":
                        var imagine = (CarService.Imagine)item;
                        c.AddImagine(imagine);
                        ImagineView(c.GetImagini(null, null, "DetaliuComanda"));
                        break;
                }
                addW.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Vizualizare colectie, duce la afisarea tuturor elementelor din colectia de tipul selectat.
        /// </summary>
        private void ViewAllBtn_Click(object sender, RoutedEventArgs e)
        {

            if (entitiesComboBox.SelectedIndex != -1)
            {
                try
                {
                    switch (entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1])
                    {
                        case "Auto":
                            AutoView(c.GetAutoturisme(null, null, "Sasiu,Comenzi.DetaliiComenzi.Material"));
                            break;
                        case "Client":
                            ClientView(c.GetClienti(null, null, "Autoturisme,Comenzi"));
                            break;
                        case "Comanda":
                            ComandaView(c.GetComenzi(null, null, "DetaliiComenzi.Material,DetaliiComenzi.Imagine"));
                            break;
                        case "DetaliuComanda":
                            DetaliuComandaView(c.GetDetaliiComenzi(null, null, "Imagine"));
                            break;
                        case "Mecanic":
                            MecanicView(c.GetMecanici(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "Material":
                            MaterialView(c.GetMateriale(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "Operatie":
                            OperatieView(c.GetOperatii(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "Sasiu":
                            SasiuView(c.GetSasiuri(null, null, "Autoturisme"));
                            break;
                        case "Imagine":
                            ImagineView(c.GetImagini(null, null, "DetaliuComanda"));
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Problema la afisare","Problema",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Cautare, creeaza o noua fereastra.
        /// </summary>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (entitiesComboBox.SelectedIndex != -1)
            {
                var selected = entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1];
                var searchingW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF." + selected + "Window"));
                var b = (Button)searchingW.FindName("button");
                b.Click += Search_Click;
                if (selected == "Imagine")
                    ((TextBox)searchingW.FindName("fotoTextBox")).IsReadOnly = true;
                searchingW.ShowDialog();
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din fereastra suplimentara pentru cautare, se ocupa de cautarea propriu-zisa in baza de date.
        /// </summary>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Window searchingW = GetWindow((Button)sender);
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                switch (entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1])
                {
                    case "Auto":
                        var autoId = ((TextBox)searchingW.FindName("autoIdTextBox")).Text;
                        if (autoId?.Length == 0)
                            dict["autoId"] = -1;
                        else
                        {
                            var autoId1 = -1;
                            if (!int.TryParse(autoId, out autoId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["autoId"] = autoId1;
                        }
                        dict["numarAuto"] = ((TextBox)searchingW.FindName("numarAutoTextBox")).Text;
                        var sasiuId = ((TextBox)searchingW.FindName("sasiuIdTextBox")).Text;
                        if (sasiuId?.Length == 0)
                            dict["sasiuId"] = -1;
                        else
                        {
                            var sasiuId1 = -1;
                            if (!int.TryParse(sasiuId, out sasiuId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["sasiuId"] = sasiuId1;
                        }
                        dict["serieSasiu"] = ((TextBox)searchingW.FindName("serieSasiuTextBox")).Text;
                        var clientId = ((TextBox)searchingW.FindName("clientIdTextBox")).Text;
                        if (clientId?.Length == 0)
                            dict["clientId"] = -1;
                        else
                        {
                            var clientId1 = -1;
                            if (!int.TryParse(clientId, out clientId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["clientId"] = clientId1;
                        }
                        AutoView(c.GetAutoturisme(dict, null, "Sasiu,Comenzi.DetaliiComenzi.Material"));
                        break;
                    case "Client":
                        clientId = ((TextBox)searchingW.FindName("clientIdTextBox")).Text;
                        if (clientId?.Length == 0)
                            dict["clientId"] = -1;
                        else
                        {
                            var clientId1 = -1;
                            if (!int.TryParse(clientId, out clientId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["clientId"] = clientId1;
                        }
                        dict["nume"] = ((TextBox)searchingW.FindName("numeTextBox")).Text;
                        dict["prenume"] = ((TextBox)searchingW.FindName("prenumeTextBox")).Text;
                        dict["localitate"] = ((TextBox)searchingW.FindName("localitateTextBox")).Text;
                        dict["adresa"] = ((TextBox)searchingW.FindName("adresaTextBox")).Text;
                        dict["judet"] = ((TextBox)searchingW.FindName("judetTextBox")).Text;
                        dict["telefon"] = ((TextBox)searchingW.FindName("telefonTextBox")).Text;
                        dict["email"] = ((TextBox)searchingW.FindName("emailTextBox")).Text;
                        ClientView(c.GetClienti(dict, null, "Autoturisme,Comenzi"));
                        break;
                    case "Comanda":
                        var comandaId = ((TextBox)searchingW.FindName("comandaIdTextBox")).Text;
                        if (comandaId?.Length == 0)
                            dict["comandaId"] = -1;
                        else
                        {
                            var comandaId1 = -1;
                            if (!int.TryParse(comandaId, out comandaId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["comandaId"] = comandaId1;
                        }
                        clientId = ((TextBox)searchingW.FindName("clientIdTextBox")).Text;
                        if (clientId?.Length == 0)
                            dict["clientId"] = -1;
                        else
                        {
                            var clientId1 = -1;
                            if (!int.TryParse(clientId, out clientId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["clientId"] = clientId1;
                        }
                        autoId = ((TextBox)searchingW.FindName("autoIdTextBox")).Text;
                        if (autoId?.Length == 0)
                            dict["autoId"] = -1;
                        else
                        {
                            var autoId1 = -1;
                            if (!int.TryParse(autoId, out autoId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["autoId"] = autoId1;
                        }
                        dict["stareComanda"] = ((TextBox)searchingW.FindName("stareComandaTextBox")).Text;
                        var kmBord = ((TextBox)searchingW.FindName("kmBordTextBox")).Text;
                        if (kmBord?.Length == 0)
                            dict["kmBord"] = -1;
                        else
                        {
                            var kmBord1 = -1;
                            if (!int.TryParse(kmBord, out kmBord1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["kmBord"] = kmBord1;
                        }
                        dict["descriere"] = ((TextBox)searchingW.FindName("descriereTextBox")).Text;
                        var dataAdaugare = ((TextBox)searchingW.FindName("dataSystemTextBox")).Text;
                        if (dataAdaugare?.Length == 0)
                            dict["dataSystem"] = new DateTime(2000, 01, 01);
                        else
                        {
                            var dataAdaugare1 = new DateTime();
                            if (!DateTime.TryParse(dataAdaugare, out dataAdaugare1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["dataSystem"] = dataAdaugare1;
                        }
                        var dataProgramare = ((TextBox)searchingW.FindName("dataProgramareTextBox")).Text;
                        if (dataProgramare?.Length == 0)
                            dict["dataProgramare"] = new DateTime(2000, 01, 01);
                        else
                        {
                            var dataProgramare1 = new DateTime();
                            if (!DateTime.TryParse(dataProgramare, out dataProgramare1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["dataProgramare"] = dataProgramare1;
                        }
                        var dataFinalizare = ((TextBox)searchingW.FindName("dataFinalizareTextBox")).Text;
                        if (dataFinalizare?.Length == 0)
                            dict["dataFinalizare"] = new DateTime(2000, 01, 01);
                        else
                        {
                            var dataFinalizare1 = new DateTime();
                            if (!DateTime.TryParse(dataFinalizare, out dataFinalizare1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["dataFinalizare"] = dataFinalizare1;
                        }
                        ComandaView(c.GetComenzi(dict, null, "DetaliiComenzi.Material,DetaliiComenzi.Imagine"));
                        break;
                    case "DetaliuComanda":
                        var detaliuComandaId = ((TextBox)searchingW.FindName("detaliuComandaIdTextBox")).Text;
                        if (detaliuComandaId?.Length == 0)
                            dict["detaliuComandaId"] = -1;
                        else
                        {
                            var detaliuComandaId1 = -1;
                            if (!int.TryParse(detaliuComandaId, out detaliuComandaId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["detaliuComandaId"] = detaliuComandaId1;
                        }
                        comandaId = ((TextBox)searchingW.FindName("comandaIdTextBox")).Text;
                        if (comandaId?.Length == 0)
                            dict["comandaId"] = -1;
                        else
                        {
                            var comandaId1 = -1;
                            if (!int.TryParse(comandaId, out comandaId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["comandaId"] = comandaId1;
                        }
                        var mecanicId = ((TextBox)searchingW.FindName("mecanicIdTextBox")).Text;
                        if (mecanicId?.Length == 0)
                            dict["mecanicId"] = -1;
                        else
                        {
                            var mecanicId1 = -1;
                            if (!int.TryParse(mecanicId, out mecanicId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["mecanicId"] = mecanicId1;
                        }
                        var materialId = ((TextBox)searchingW.FindName("materialIdTextBox")).Text;
                        if (materialId?.Length == 0)
                            dict["materialId"] = -1;
                        else
                        {
                            var materialId1 = -1;
                            if (!int.TryParse(materialId, out materialId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["materialId"] = materialId1;
                        }
                        var operatieId = ((TextBox)searchingW.FindName("operatieIdTextBox")).Text;
                        if (operatieId?.Length == 0)
                            dict["operatieId"] = -1;
                        else
                        {
                            var operatieId1 = -1;
                            if (!int.TryParse(operatieId, out operatieId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["operatieId"] = operatieId1;
                        }
                        DetaliuComandaView(c.GetDetaliiComenzi(dict, null, "Imagine"));
                        break;
                    case "Mecanic":
                        mecanicId = ((TextBox)searchingW.FindName("mecanicIdTextBox")).Text;
                        if (mecanicId?.Length == 0)
                            dict["mecanicId"] = -1;
                        else
                        {
                            var mecanicId1 = -1;
                            if (!int.TryParse(mecanicId, out mecanicId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["mecanicId"] = mecanicId1;
                        }
                        dict["nume"] = ((TextBox)searchingW.FindName("numeTextBox")).Text;
                        dict["prenume"] = ((TextBox)searchingW.FindName("prenumeTextBox")).Text;
                        MecanicView(c.GetMecanici(dict, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Material":
                        materialId = ((TextBox)searchingW.FindName("materialIdTextBox")).Text;
                        if (materialId?.Length == 0)
                            dict["materialId"] = -1;
                        else
                        {
                            var materialId1 = -1;
                            if (!int.TryParse(materialId, out materialId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["materialId"] = materialId1;
                        }
                        dict["denumire"] = ((TextBox)searchingW.FindName("denumireTextBox")).Text;
                        var cantitate = ((TextBox)searchingW.FindName("cantitateTextBox")).Text;
                        if (cantitate?.Length == 0)
                            dict["cantitate"] = -1m;
                        else
                        {
                            var cantitate1 = -1m;
                            if (!decimal.TryParse(cantitate, out cantitate1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["cantitate"] = cantitate1;
                        }
                        var pret = ((TextBox)searchingW.FindName("pretTextBox")).Text;
                        if (pret?.Length == 0)
                            dict["pret"] = -1m;
                        else
                        {
                            var pret1 = -1m;
                            if (!decimal.TryParse(cantitate, out pret1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["pret"] = pret1;
                        }
                        MaterialView(c.GetMateriale(dict, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Operatie":
                        operatieId = ((TextBox)searchingW.FindName("operatieIdTextBox")).Text;
                        if (operatieId?.Length == 0)
                            dict["operatieId"] = -1;
                        else
                        {
                            var operatieId1 = -1;
                            if (!int.TryParse(operatieId, out operatieId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["operatieId"] = operatieId1;
                        }
                        dict["denumire"] = ((TextBox)searchingW.FindName("denumireTextBox")).Text;
                        var timpExecutie = ((TextBox)searchingW.FindName("timpExecutieTextBox")).Text;
                        if (timpExecutie?.Length == 0)
                            dict["timpExecutie"] = -1m;
                        else
                        {
                            var timpExecutie1 = -1m;
                            if (!decimal.TryParse(timpExecutie, out timpExecutie1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["timpExecutie"] = timpExecutie1;
                        }
                        OperatieView(c.GetOperatii(dict, null, "DetaliiComenzi.Imagine"));
                        break;
                    case "Sasiu":
                        sasiuId = ((TextBox)searchingW.FindName("sasiuIdTextBox")).Text;
                        if (sasiuId?.Length == 0)
                            dict["sasiuId"] = -1;
                        else
                        {
                            var sasiuId1 = -1;
                            if (!int.TryParse(sasiuId, out sasiuId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["sasiuId"] = sasiuId1;
                        }
                        dict["codSasiu"] = ((TextBox)searchingW.FindName("codSasiuTextBox")).Text;
                        dict["denumire"] = ((TextBox)searchingW.FindName("denumireTextBox")).Text;
                        SasiuView(c.GetSasiuri(dict, null, "Autoturisme"));
                        break;
                    case "Imagine":
                        var imagineId = ((TextBox)searchingW.FindName("imagineIdTextBox")).Text;
                        if (imagineId?.Length == 0)
                            dict["imagineId"] = -1;
                        else
                        {
                            var imagineId1 = -1;
                            if (!int.TryParse(imagineId, out imagineId1))
                            {
                                MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            dict["imagineId"] = imagineId1;
                        }
                        dict["titlu"] = ((TextBox)searchingW.FindName("titluTextBox")).Text;
                        dict["descriere"] = ((TextBox)searchingW.FindName("descriereIdTextBox")).Text;
                        ImagineView(c.GetImagini(dict, null, "DetaliuComanda"));
                        break;
                }
                searchingW.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Problema la cautare", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Editare, creeaza o noua fereastra
        /// </summary>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (entitiesDataGrid.SelectedIndex != -1)
            {
                var name = entitiesDataGrid.Columns[0].Header.ToString().Substring(0, entitiesDataGrid.Columns[0].Header.ToString().Length - 2);
                var editW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF." + name + "Window"));
                var b = (Button)editW.FindName("button");
                b.Click += Edit_Click;
                ((TextBox)editW.FindName(char.ToLower(name[0]) + name.Substring(1, name.Length - 1) + "IdTextBox")).IsReadOnly = true;
                int i = 0;
                if (name == "Comanda")
                {
                    ((TextBox)editW.FindName("dataSystemTextBox")).IsReadOnly = true;
                    ((TextBox)editW.FindName("clientIdTextBox")).IsReadOnly = true;
                }
                else if (name == "DetaliuComanda")
                {
                    ((TextBox)editW.FindName("imagineIdTextBox")).IsReadOnly = true;
                }
                else if (name == "Imagine")
                {
                    ((TextBox)editW.FindName("detaliuComandaIdTextBox")).IsReadOnly = true;
                }
                var row = (DataGridRow)entitiesDataGrid.ItemContainerGenerator.ContainerFromIndex(entitiesDataGrid.SelectedIndex);
                foreach (var element in LogicalTreeHelper.GetChildren(editW))
                {
                    if (element.ToString() == "System.Windows.Controls.Grid")
                    {
                        foreach (var ctrl in LogicalTreeHelper.GetChildren((FrameworkElement)element))
                        {
                            if (ctrl is TextBox textBox)
                            {
                                var item1 = textBox;
                                if (item1.Name != "fotoTextBox" && !(name == "Comanda" && item1.Name == "clientIdTextBox") && !(name=="Comanda" && item1.Name =="dataSystemTextBox"))
                                {
                                    TextBlock text = entitiesDataGrid.Columns[i].GetCellContent(row) as TextBlock;
                                    item1.Text = text.Text;
                                }
                                i++;
                            }
                        }
                    }
                }
                editW.ShowDialog();
            }
            else
                MessageBox.Show("Selectati entitatea", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din fereastra suplimentara, se ocupa de editarea propriu-zisa.
        /// </summary>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CarService.Entitate item = null;
            Type type = null;
            var line = (DataGridRow)entitiesDataGrid.ItemContainerGenerator.ContainerFromIndex(entitiesDataGrid.SelectedIndex);
            Window editW = GetWindow((Button)sender);
            try
            {
                switch (entitiesDataGrid.Columns[0].Header.ToString())
                {
                    case "AutoId":
                        TextBlock text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        var value = text.Text;
                        item = c.GetAutoById(int.Parse(value));
                        type = Type.GetType("CarService.Auto,CarService");
                        break;
                    case "ClientId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetClientById(int.Parse(value));
                        type = Type.GetType("CarService.Client,CarService");
                        break;
                    case "ComandaId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetComandaById(int.Parse(value));
                        type = Type.GetType("CarService.Comanda,CarService");
                        break;
                    case "DetaliuComandaId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetDetaliuComandaById(int.Parse(value));
                        type = Type.GetType("CarService.DetaliuComanda,CarService");
                        break;
                    case "MecanicId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetMecanicById(int.Parse(value));
                        type = Type.GetType("CarService.Mecanic,CarService");
                        break;
                    case "MaterialId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetMaterialById(int.Parse(value));
                        type = Type.GetType("CarService.Material,CarService");
                        break;
                    case "OperatieId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetOperatieById(int.Parse(value));
                        type = Type.GetType("CarService.Operatie,CarService");
                        break;
                    case "SasiuId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetSasiuById(int.Parse(value));
                        type = Type.GetType("CarService.Sasiu,CarService");
                        break;
                    case "ImagineId":
                        text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                        value = text.Text;
                        item = c.GetImagineById(int.Parse(value));
                        type = Type.GetType("CarService.Imagine,CarService");
                        break;
                }
                foreach (var element in LogicalTreeHelper.GetChildren(editW))
                {
                    if (element.ToString() == "System.Windows.Controls.Grid")
                    {
                        foreach (var ctrl in LogicalTreeHelper.GetChildren((FrameworkElement)element))
                        {
                            if (ctrl is TextBox textBox)
                            {
                                TextBox ctrl1 = textBox;
                                if (ctrl1.Text != "")
                                {
                                    string name = ctrl1.Name;
                                    string propertyName = char.ToUpper(name[0]) + name.Substring(1, name.Length - 8);
                                    if (propertyName.EndsWith("Id") && propertyName != entitiesDataGrid.Columns[0].Header.ToString())
                                        propertyName = propertyName.Substring(0, propertyName.Length - 2) + propertyName;
                                    PropertyInfo prop = type.GetProperty(propertyName);
                                    if (propertyName == "DetaliuComandaDetaliuComandaId")
                                    {
                                        continue;
                                        /*
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                       ((CarService.Imagine)item).DetaliuComanda = c.GetDetaliuComandaById(value);
                                        continue;
                                        */
                                    }
                                    if (propertyName == "ValoarePiese")
                                        continue;
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(int?))
                                    {
                                        if (!int.TryParse(ctrl1.Text, out int value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        if (!decimal.TryParse(ctrl1.Text, out decimal value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        if (!DateTime.TryParse(ctrl1.Text, out DateTime value))
                                        {
                                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, value, null);
                                    }
                                    else if (prop.PropertyType == typeof(byte[]))
                                    {
                                        try
                                        {
                                            var value = File.ReadAllBytes(ctrl1.Text);
                                            prop.SetValue(item, value, null);
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Imaginea nu poate fi citita", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (ctrl1.Name == "telefonTextBox" && ctrl1.Text.Any(c => c < '0' || c > '9'))
                                        {
                                            MessageBox.Show("Nr de telefon nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        if (ctrl1.Name == "emailTextBox")
                                        {
                                            try
                                            {
                                                var addr = new MailAddress(ctrl1.Text);
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("email nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                                return;
                                            }
                                        }
                                        if (ctrl1.Name == "numarAutoTextBox")
                                        {
                                            if (ctrl1.Text.Count() != 10 ||
                                            !(
                                            (ctrl1.Text[0] >= 'A' && ctrl1.Text[0] <= 'Z' && ctrl1.Text[1] >= 'A' && ctrl1.Text[1] <= 'Z' &&
                                            ctrl1.Text[2] == ' ' && ctrl1.Text[3] >= '0' && ctrl1.Text[3] <= '9' &&
                                            ctrl1.Text[4] >= '0' && ctrl1.Text[4] <= '9' && ctrl1.Text[5] >= '0' && ctrl1.Text[5] <= '9' &&
                                            ctrl1.Text[6] == ' ' && ctrl1.Text[7] >= 'A' && ctrl1.Text[7] <= 'Z' && ctrl1.Text[8] >= 'A' &&
                                            ctrl1.Text[8] <= 'Z' && ctrl1.Text[9] >= 'A' && ctrl1.Text[9] <= 'Z'
                                            ) ||
                                            (
                                            ctrl1.Text[0] >= 'A' && ctrl1.Text[0] <= 'Z' && ctrl1.Text[1] >= 'A' && ctrl1.Text[1] <= 'Z' &&
                                            ctrl1.Text[2] >= '0' && ctrl1.Text[2] <= '9' && ctrl1.Text[3] >= '0' && ctrl1.Text[3] <= '9' &&
                                            ctrl1.Text[4] >= '0' && ctrl1.Text[4] <= '9' && ctrl1.Text[5] >= '0' && ctrl1.Text[5] <= '9' &&
                                            ctrl1.Text[6] >= '0' && ctrl1.Text[6] <= '9' && ctrl1.Text[7] >= '0' && ctrl1.Text[7] <= '9' &&
                                            ctrl1.Text[8] >= '0' && ctrl1.Text[8] <= '9' && ctrl1.Text[9] >= '0' && ctrl1.Text[9] <= '9'
                                            ))
                                            )
                                            {
                                                MessageBox.Show("Numar auto nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                                return;
                                            }
                                        }
                                        if (ctrl1.Name == "codSasiuTextBox" && (ctrl1.Text.Count() != 2 || !char.IsLetterOrDigit(ctrl1.Text[0]) || !char.IsLetterOrDigit(ctrl1.Text[1])))
                                        {
                                            MessageBox.Show("Cod sasiu nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                        prop.SetValue(item, ctrl1.Text, null);
                                    }
                                }
                                else if (!(entitiesDataGrid.Columns[0].Header.ToString() == "DetaliuComandaId" && ctrl1.Name == "imagineIdTextBox") && !(entitiesDataGrid.Columns[0].Header.ToString() == "ComandaId" && (ctrl1.Name == "clientIdTextBox" || ctrl1.Name == "dataSystemTextBox")))
                                {
                                    MessageBox.Show("Proprietate obligatorie", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                        }
                        switch (entitiesComboBox.SelectedItem.ToString().Split(new char[] { ' ' })[1])
                        {
                            case "Auto":
                                var auto = (CarService.Auto)item;
                                if (!auto.SerieSasiu.Substring(6, 2).Equals(c.GetSasiuById(auto.SasiuSasiuId).CodSasiu))
                                {
                                    MessageBox.Show("Nepotrivire intre codul sasiu si codul de pe pozitiile 7,8 din seria sasiu", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                                c.EditAuto(auto);
                                AutoView(c.GetAutoturisme(null, null, "Sasiu,Comenzi.DetaliiComenzi.Material"));
                                break;
                            case "Client":
                                var cl = (CarService.Client)item;
                                c.EditClient(cl);
                                ClientView(c.GetClienti(null, null, "Autoturisme,Comenzi"));
                                break;
                            case "Comanda":
                                var comanda = (CarService.Comanda)item;
                                comanda.ClientClientId = c.GetAutoById(comanda.AutoAutoId).ClientClientId;
                                c.EditComanda(comanda);
                                ComandaView(c.GetComenzi(null, null, "DetaliiComenzi.Material,DetaliiComenzi.Imagine"));
                                break;
                            case "DetaliuComanda":
                                var detaliuComanda = (CarService.DetaliuComanda)item;
                                c.EditDetaliuComanda(detaliuComanda);
                                DetaliuComandaView(c.GetDetaliiComenzi(null, null, "Imagine"));
                                break;
                            case "Mecanic":
                                var mecanic = (CarService.Mecanic)item;
                                c.EditMecanic(mecanic);
                                MecanicView(c.GetMecanici(null, null, "DetaliiComenzi.Imagine"));
                                break;
                            case "Material":
                                var material = (CarService.Material)item;
                                c.EditMaterial(material);
                                MaterialView(c.GetMateriale(null, null, "DetaliiComenzi.Imagine"));
                                break;
                            case "Operatie":
                                var operatie = (CarService.Operatie)item;
                                c.EditOperatie(operatie);
                                OperatieView(c.GetOperatii(null, null, "DetaliiComenzi.Imagine"));
                                break;
                            case "Sasiu":
                                var sasiu = (CarService.Sasiu)item;
                                c.EditSasiu(sasiu);
                                SasiuView(c.GetSasiuri(null, null, "Autoturisme"));
                                var text = entitiesDataGrid.Columns[1].GetCellContent(line) as TextBlock;
                                var value = text.Text;
                                if (value != sasiu.CodSasiu)
                                {
                                    foreach (var auto1 in sasiu.Autoturisme)
                                    {
                                        StringBuilder sb = new StringBuilder(auto1.SerieSasiu);
                                        sb[6] = sasiu.CodSasiu[0];
                                        sb[7] = sasiu.CodSasiu[1];
                                        auto1.SerieSasiu = sb.ToString();
                                        c.EditAuto(auto1);
                                    }
                                }
                                break;
                            case "Imagine":
                                var imagine = (CarService.Imagine)item;
                                c.EditImagine(imagine);
                                ImagineView(c.GetImagini(null, null, "DetaliuComanda"));
                                break;
                        }
                    }
                }
                editW.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Entitatea nu poate fi editata", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Stergere, sterge entitatea selectata.
        /// </summary>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var line = (DataGridRow)entitiesDataGrid.ItemContainerGenerator.ContainerFromIndex(entitiesDataGrid.SelectedIndex);
            if (entitiesDataGrid.SelectedIndex != -1)
            {
                try
                {
                    switch (entitiesDataGrid.Columns[0].Header.ToString())
                    {
                        case "AutoId":
                            TextBlock text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            var value = text.Text;
                            c.RemoveAuto(c.GetAutoById(int.Parse(value)));
                            AutoView(c.GetAutoturisme(null, null, "Sasiu,Comenzi.DetaliiComenzi.Material"));
                            break;
                        case "ClientId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveClient(c.GetClientById(int.Parse(value)));
                            ClientView(c.GetClienti(null, null, "Autoturisme,Comenzi"));
                            break;
                        case "ComandaId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveComanda(c.GetComandaById(int.Parse(value)));
                            ComandaView(c.GetComenzi(null, null, "DetaliiComenzi.Material,DetaliiComenzi.Imagine"));
                            break;
                        case "SasiuId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveSasiu(c.GetSasiuById(int.Parse(value)));
                            SasiuView(c.GetSasiuri(null, null, "Autoturisme"));
                            break;
                        case "OperatieId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveOperatie(c.GetOperatieById(int.Parse(value)));
                            OperatieView(c.GetOperatii(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "MecanicId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveMecanic(c.GetMecanicById(int.Parse(value)));
                            MecanicView(c.GetMecanici(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "MaterialId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveMaterial(c.GetMaterialById(int.Parse(value)));
                            MaterialView(c.GetMateriale(null, null, "DetaliiComenzi.Imagine"));
                            break;
                        case "DetaliuComandaId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveDetaliuComanda(c.GetDetaliuComandaById(int.Parse(value)));
                            DetaliuComandaView(c.GetDetaliiComenzi(null, null, "Imagine"));
                            break;
                        case "ImagineId":
                            text = entitiesDataGrid.Columns[0].GetCellContent(line) as TextBlock;
                            value = text.Text;
                            c.RemoveImagine(c.GetImagineById(int.Parse(value)));
                            ImagineView(c.GetImagini(null, null, "DetaliuComanda"));
                            break;
                    }                 
                }
                catch (Exception)
                {
                    MessageBox.Show("Entitatea nu poate fi stearsa", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                }               
            }
            else
                MessageBox.Show("Selectati entitatea", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Vizualizare asocieri, creeaza o noua fereastra in care asocierile vor fi reprezentate intr-un element de tip TreeView.
        /// </summary>
        private void AssociationsBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = entitiesDataGrid.SelectedItems;
            if (selectedItems.Count > 0)
            {
                try
                {
                    switch (entitiesDataGrid.Columns[0].Header.ToString())
                    {
                        case "AutoId":
                            var associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            var tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var auto = (CarService.Auto)item;
                                var node = new TreeViewItem
                                {
                                    Header = auto.AutoId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "Comenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.Comanda comanda in auto.Comenzi)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "ComandaId: " + comanda.ComandaId + "; ClientId: " + comanda.ClientClientId + "; Stare comanda: " + comanda.StareComanda + "; Data sistem: " + comanda.DataSystem + "; Data programare: " + comanda.DataProgramare + "; Data finalizare: " + comanda.DataFinalizare + "; Km bord: " + comanda.KmBord + "; Descriere: " + comanda.Descriere + "; Valoare piese: " + comanda.ValoarePiese
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "ClientId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var cl = (CarService.Client)item;
                                var node = new TreeViewItem
                                {
                                    Header = cl.ClientId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "Autoturisme"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.Auto auto in cl.Autoturisme)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header="AutoId: " + auto.AutoId + "; Numar auto: " + auto.NumarAuto + "; SasiuId: " + auto.SasiuSasiuId + "; Serie sasiu: " + auto.SerieSasiu
                                    };
                                    node1.Items.Add(node2);
                                }
                                node1 = new TreeViewItem
                                {
                                    Header = "Comenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.Comanda comanda in cl.Comenzi)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "ComandaId: " + comanda.ComandaId + "; AutoId: " + comanda.AutoAutoId + "; Stare comanda: " + comanda.StareComanda + "; Data sistem: " + comanda.DataSystem + "; Data programare: " + comanda.DataProgramare + "; Data finalizare: " + comanda.DataFinalizare + "; Km bord: " + comanda.KmBord + "; Descriere: " + comanda.Descriere + "; Valoare piese: " + comanda.ValoarePiese
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "ComandaId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var comanda = (CarService.Comanda)item;
                                var node = new TreeViewItem
                                {
                                    Header = comanda.ComandaId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "DetaliiComenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.DetaliuComanda detaliuComanda in comanda.DetaliiComenzi)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "DetaliuComandaId: " + detaliuComanda.DetaliuComandaId + "; MecanicId: " + detaliuComanda.MecanicMecanicId + "; MaterialId: " + detaliuComanda.MaterialMaterialId + "; OperatieId: " + detaliuComanda.OperatieOperatieId + "; ImagineId: " + ((detaliuComanda.Imagine != null) ? detaliuComanda.Imagine.ImagineId.ToString() : "nicio imagine")
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "OperatieId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var operatie = (CarService.Operatie)item;
                                var node = new TreeViewItem
                                {
                                    Header = operatie.OperatieId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "DetaliiComenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.DetaliuComanda detaliuComanda in operatie.DetaliiComenzi)
                                {
                                    var node2=new TreeViewItem
                                    {
                                        Header = "DetaliuComandaId: " + detaliuComanda.DetaliuComandaId + "; ComandaId: " + detaliuComanda.ComandaComandaId + "; MecanicId: " + detaliuComanda.MecanicMecanicId + "; MaterialId: " + detaliuComanda.MaterialMaterialId + "; ImagineId: " + ((detaliuComanda.Imagine != null) ? detaliuComanda.Imagine.ImagineId.ToString() : "nicio imagine")
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "MaterialId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var material = (CarService.Material)item;
                                var node = new TreeViewItem
                                {
                                    Header = material.MaterialId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "DetaliiComenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.DetaliuComanda detaliuComanda in material.DetaliiComenzi)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "DetaliuComandaId: " + detaliuComanda.DetaliuComandaId + "; ComandaId: " + detaliuComanda.ComandaComandaId + "; MecanicId: " + detaliuComanda.MecanicMecanicId + "; OperatieId: " + detaliuComanda.OperatieOperatieId + "; ImagineId: " + ((detaliuComanda.Imagine != null) ? detaliuComanda.Imagine.ImagineId.ToString() : "nicio imagine")
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "MecanicId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var mecanic = (CarService.Mecanic)item;
                                var node = new TreeViewItem
                                {
                                    Header = mecanic.MecanicId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "DetaliiComenzi"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.DetaliuComanda detaliuComanda in mecanic.DetaliiComenzi)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "DetaliuComandaId: " + detaliuComanda.DetaliuComandaId + "; ComandaId: " + detaliuComanda.ComandaComandaId + "; MaterialId: " + detaliuComanda.MaterialMaterialId + "; OperatieId: " + detaliuComanda.OperatieOperatieId + "; ImagineId: " + ((detaliuComanda.Imagine != null) ? detaliuComanda.Imagine.ImagineId.ToString() : "nicio imagine")
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        case "SasiuId":
                            associationsW = (Window)Activator.CreateInstance(Type.GetType("ClientWPF.AsocieriWindow"));
                            tree = (TreeView)associationsW.FindName("associationsTreeView");
                            foreach (var item in selectedItems)
                            {
                                var sasiu = (CarService.Sasiu)item;
                                var node = new TreeViewItem
                                {
                                    Header = sasiu.SasiuId.ToString()
                                };
                                tree.Items.Add(node);
                                var node1 = new TreeViewItem
                                {
                                    Header = "Autoturisme"
                                };
                                node.Items.Add(node1);
                                foreach (CarService.Auto auto in sasiu.Autoturisme)
                                {
                                    var node2 = new TreeViewItem
                                    {
                                        Header = "AutoId: " + auto.AutoId + "; ClientId: " + auto.ClientClientId + "; Numar auto: " + auto.NumarAuto + "; Serie sasiu: " + auto.SerieSasiu
                                    };
                                    node1.Items.Add(node2);
                                }
                            }
                            associationsW.Show();
                            break;
                        default:
                            MessageBox.Show("Tip nevalid", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Selectati entitatile", "Problema", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
