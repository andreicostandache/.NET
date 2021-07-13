using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;
using CarService;

namespace CarServiceApp
{
    public partial class MainForm : Form
    {
        IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="MainForm"/>
        /// </summary>
        /// <param name="_unitOfWork">Unit Of Work, utilizat la operatiile pe entitati.</param>
        public MainForm(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            InitializeComponent();
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Adaugare, creeaza un nou formular.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (entitiesComboBox.SelectedIndex > -1)
            {
                var selected = entitiesComboBox.SelectedItem.ToString();
                var form = (Form)Activator.CreateInstance(Type.GetType("CarServiceApp." + selected + "Form"));
                Button a = (Button)form.Controls["button1"];
                a.Click += Add_Click;
                form.Controls[Char.ToLower(selected[0]) + selected.Substring(1, selected.Length - 1) + "IdTextBox"].Enabled = false;
                if (selected == "Comanda")
                {
                    form.Controls["dataSystemTextBox"].Enabled = false;
                    form.Controls["valoarePieseTextBox"].Enabled = false;
                }
                form.ShowDialog();
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din formularul suplimentar pentru adaugare, se ocupa de adaugarea propriu-zisa in baza de date.
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {
            var selected = entitiesComboBox.SelectedItem.ToString();
            Type type = Type.GetType("CarService." + selected + ",CarService");
            Entitate item = (Entitate)Activator.CreateInstance(type);
            Form form = (Form)((Button)sender).Parent;
            try
            { 
                foreach (var ctrl in form.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        TextBox ctrl1 = textBox;
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
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ((Imagine)item).DetaliuComanda = unitOfWork.DetaliuComandaRepository.GetById(value);
                                continue;
                            }
                            PropertyInfo prop = type.GetProperty(propertyName);
                            if (prop.PropertyType == typeof(int))
                            {
                                if (!int.TryParse(ctrl1.Text, out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(int?))
                            {
                                if (!int.TryParse(ctrl1.Text, out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(decimal))
                            {
                                if (!decimal.TryParse(ctrl1.Text, out decimal value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(DateTime))
                            {
                                if(!DateTime.TryParse(ctrl1.Text,out DateTime value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if(prop.PropertyType==typeof(byte[]))
                            {
                                try
                                {
                                    var value = File.ReadAllBytes(ctrl1.Text);
                                    prop.SetValue(item, value, null);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imaginea nu poate fi citita", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                if(ctrl1.Name=="telefonTextBox" && ctrl1.Text.Any(c => c < '0' || c > '9'))
                                {
                                    MessageBox.Show("Nr de telefon nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        MessageBox.Show("email nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                if (ctrl1.Name == "numarAutoTextBox")
                                {
                                    if(ctrl1.Text.Count()!=10|| 
                                    !(
                                    (ctrl1.Text[0]>='A' && ctrl1.Text[0]<='Z' && ctrl1.Text[1]>='A' && ctrl1.Text[1]<='Z'&& 
                                    ctrl1.Text[2] ==' ' && ctrl1.Text[3] >= '0' && ctrl1.Text[3] <= '9'&&
                                    ctrl1.Text[4] >= '0' && ctrl1.Text[4] <= '9' && ctrl1.Text[5] >= '0' && ctrl1.Text[5] <= '9'&&
                                    ctrl1.Text[6] == ' ' && ctrl1.Text[7] >= 'A' && ctrl1.Text[7] <= 'Z' && ctrl1.Text[8] >= 'A'&&
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
                                        MessageBox.Show("Numar auto nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                if (ctrl1.Name == "codSasiuTextBox" && (ctrl1.Text.Count()!=2||!char.IsLetterOrDigit(ctrl1.Text[0])||!char.IsLetterOrDigit(ctrl1.Text[1])))
                                {
                                    MessageBox.Show("Cod sasiu nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, ctrl1.Text, null);
                            }
                                
                        }
                        else if(!(selected=="DetaliuComanda"&&ctrl1.Name=="imagineIdTextBox") && !ctrl1.Name.StartsWith(selected, StringComparison.OrdinalIgnoreCase) && ctrl1.Name!="valoarePieseTextBox" && ctrl1.Name!="dataSystemTextBox")
                        {
                            MessageBox.Show("Proprietate obligatorie", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                switch (entitiesComboBox.SelectedItem.ToString())
                {
                    case "Auto":
                        var auto = (Auto)item;
                        unitOfWork.AutoRepository.Add(auto);
                        unitOfWork.Save();
                        AutoView(unitOfWork.AutoRepository.Get());
                        break;
                    case "Client":
                        var cl = (Client)item;
                        unitOfWork.ClientRepository.Add(cl);
                        unitOfWork.Save(); 
                        ClientView(unitOfWork.ClientRepository.Get());
                        break;
                    case "Comanda":
                        var comanda = (Comanda)item;
                        comanda.DataSystem = DateTime.Now;
                        unitOfWork.ComandaRepository.Add(comanda);
                        unitOfWork.Save();
                        ComandaView(unitOfWork.ComandaRepository.Get());
                        break;
                    case "DetaliuComanda":
                        var detaliuComanda = (DetaliuComanda)item;
                        unitOfWork.DetaliuComandaRepository.Add(detaliuComanda);
                        unitOfWork.Save();
                        DetaliuComandaView(unitOfWork.DetaliuComandaRepository.Get());
                        break;
                    case "Mecanic":
                        var mecanic = (Mecanic)item;
                        unitOfWork.MecanicRepository.Add(mecanic);
                        unitOfWork.Save();
                        MecanicView(unitOfWork.MecanicRepository.Get());
                        break;
                    case "Material":
                        var material = (Material)item;
                        unitOfWork.MaterialRepository.Add(material);
                        unitOfWork.Save();
                        MaterialView(unitOfWork.MaterialRepository.Get());
                        break;
                    case "Operatie":
                        var operatie = (Operatie)item;
                        unitOfWork.OperatieRepository.Add(operatie);
                        unitOfWork.Save();
                        OperatieView(unitOfWork.OperatieRepository.Get());
                        break;
                    case "Sasiu":
                        var sasiu = (Sasiu)item;
                        unitOfWork.SasiuRepository.Add(sasiu);
                        unitOfWork.Save();
                        SasiuView(unitOfWork.SasiuRepository.Get());
                        break;
                    case "Imagine":
                        var imagine = (Imagine)item;
                        unitOfWork.ImagineRepository.Add(imagine);
                        unitOfWork.Save();
                        ImagineView(unitOfWork.ImagineRepository.Get());
                        break;
                }
                form.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Entitate nevalida", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Close();
                this.Close();
            }
        }
        
        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Cautare, creeaza un nou formular.
        /// </summary>
        private void SearchingBtn_Click(object sender, EventArgs e)
        {
            if (entitiesComboBox.SelectedIndex != -1)
            {
                var selected = entitiesComboBox.SelectedItem.ToString();
                var form = (Form)Activator.CreateInstance(Type.GetType("CarServiceApp." + selected + "Form"));
                Button a = (Button)form.Controls["button1"];
                a.Click += Searching_Click;
                if (selected == "Imagine")
                    form.Controls["fotoTextBox"].Enabled = false;
                form.ShowDialog();
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);           
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din formularul suplimentar pentru cautare, se ocupa de cautarea propriu-zisa in baza de date.
        /// </summary>
        private void Searching_Click(object sender, EventArgs e)
        {
            var form = (Form)((Button)sender).Parent;
            var controls = form.Controls;
            try
            {
                switch (entitiesComboBox.SelectedItem.ToString())
                {
                    case "Auto":
                        var autoId = controls["autoIdTextBox"].Text;
                        var autoId1 = -1;
                        if (autoId != "" && !int.TryParse(autoId, out autoId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var numarAuto = controls["numarAutoTextBox"].Text;
                        var sasiuId = controls["sasiuIdTextBox"].Text;
                        var sasiuId1 = -1;
                        if (sasiuId != "" && !int.TryParse(sasiuId, out sasiuId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var serieSasiu = controls["serieSasiuTextBox"].Text;
                        var clientId = controls["clientIdTextBox"].Text;
                        var clientId1 = -1;
                        if (clientId != "" && !int.TryParse(clientId, out clientId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        AutoView(unitOfWork.AutoRepository.Get(a =>
                        (autoId == "" || a.AutoId == autoId1)
                        && (numarAuto == "" || a.NumarAuto == numarAuto)
                        && (sasiuId == "" || a.SasiuSasiuId == sasiuId1)
                        && (serieSasiu == "" || a.SerieSasiu == serieSasiu)
                        && (clientId == "" || a.ClientClientId == clientId1)
                        ));
                        form.Close();
                        break;
                    case "Client":
                        clientId = controls["clientIdTextBox"].Text;
                        clientId1 = -1;
                        if (clientId != "" && !int.TryParse(clientId, out clientId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var nume = controls["numeTextBox"].Text;
                        var prenume = controls["prenumeTextBox"].Text;
                        var localitate = controls["localitateTextBox"].Text;
                        var adresa = controls["adresaTextBox"].Text;
                        var judet = controls["telefonTextBox"].Text;
                        var telefon = controls["telefonTextBox"].Text;
                        var email = controls["emailTextBox"].Text;
                        ClientView(unitOfWork.ClientRepository.Get(a =>
                        (clientId == "" || a.ClientId == clientId1)
                        && (nume == "" || a.Nume == nume)
                        && (prenume == "" || a.Prenume == prenume)
                        && (localitate == "" || a.Localitate == localitate)
                        && (adresa == "" || a.Adresa == adresa)
                        && (judet == "" || a.Judet == judet)
                        && (telefon == "" || a.Telefon == telefon)
                        && (email == "" || a.Email == email)
                        ));
                        form.Close();
                        break;
                    case "Comanda":
                        var comandaId = controls["comandaIdTextBox"].Text;
                        var comandaId1 = -1;
                        if (comandaId != "" && !int.TryParse(comandaId, out comandaId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        clientId = controls["clientIdTextBox"].Text;
                        clientId1 = -1;
                        if (clientId != "" && !int.TryParse(clientId, out clientId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        autoId = controls["autoIdTextBox"].Text;
                        autoId1 = -1;
                        if (autoId != "" && !int.TryParse(autoId, out autoId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var stareComanda = controls["stareComandaTextBox"].Text;
                        var kmBord = controls["kmBordTextBox"].Text;
                        var kmBord1 = -1;
                        if (kmBord != "" && !int.TryParse(kmBord, out kmBord1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var descriere = controls["descriereTextBox"].Text;
                        ComandaView(unitOfWork.ComandaRepository.Get(a =>
                        (comandaId == "" || a.ComandaId == comandaId1)
                        && (clientId == "" || a.ClientClientId == clientId1)
                        && (autoId == "" || a.AutoAutoId == autoId1)
                        && (stareComanda == "" || a.StareComanda == stareComanda)
                        && (kmBord == "" || a.KmBord == kmBord1)
                        && (descriere == "" || a.Descriere == descriere)
                        ));
                        form.Close();
                        break;
                    case "DetaliuComanda":
                        var detaliuComandaId = controls["detaliuComandaIdTextBox"].Text;
                        var detaliuComandaId1 = -1;
                        if (detaliuComandaId != "" && !int.TryParse(detaliuComandaId, out detaliuComandaId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        comandaId = controls["comandaIdTextBox"].Text;
                        comandaId1 = -1;
                        if (comandaId != "" && !int.TryParse(comandaId, out comandaId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var mecanicId = controls["mecanicIdTextBox"].Text;
                        var mecanicId1 = -1;
                        if (mecanicId != "" && !int.TryParse(mecanicId, out mecanicId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var materialId = controls["materialIdTextBox"].Text;
                        var materialId1 = -1;
                        if (materialId != "" && !int.TryParse(materialId, out materialId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var operatieId = controls["operatieIdTextBox"].Text;
                        var operatieId1 = -1;
                        if (operatieId != "" && !int.TryParse(operatieId, out operatieId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        DetaliuComandaView(unitOfWork.DetaliuComandaRepository.Get(a =>
                        (detaliuComandaId == "" || a.DetaliuComandaId == detaliuComandaId1)
                        && (comandaId == "" || a.ComandaComandaId == comandaId1)
                        && (mecanicId == "" || a.MecanicMecanicId == mecanicId1)
                        && (materialId == "" || a.MaterialMaterialId == materialId1)
                        && (operatieId == "" || a.OperatieOperatieId == operatieId1)
                        ));
                        form.Close();
                        break;
                    case "Mecanic":
                        mecanicId = controls["mecanicIdTextBox"].Text;
                        mecanicId1 = -1;
                        if (mecanicId != "" && !int.TryParse(mecanicId, out mecanicId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        nume = controls["numeTextBox"].Text;
                        prenume = controls["prenumeTextBox"].Text;
                        MecanicView(unitOfWork.MecanicRepository.Get(a =>
                        (mecanicId == "" || a.MecanicId == mecanicId1)
                        && (nume == "" || a.Nume == nume)
                        && (prenume == "" || a.Prenume == prenume)
                        ));
                        form.Close();
                        break;
                    case "Material":
                        materialId = controls["materialIdTextBox"].Text;
                        materialId1 = -1;
                        if (materialId != "" && !int.TryParse(materialId, out materialId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var denumire = controls["denumireTextBox"].Text;
                        var cantitate = controls["cantitateTextBox"].Text;
                        var cantitate1 = -1m;
                        if (cantitate != "" && !decimal.TryParse(cantitate, out cantitate1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var pret = controls["pretTextBox"].Text;
                        var pret1 = -1m;
                        if (pret != "" && !decimal.TryParse(pret, out pret1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        MaterialView(unitOfWork.MaterialRepository.Get(a =>
                        (materialId == "" || a.MaterialId == materialId1)
                        && (denumire == "" || a.Denumire == denumire)
                        && (cantitate == "" || a.Cantitate == cantitate1)
                        && (pret == "" || a.Pret == pret1)
                        ));
                        form.Close();
                        break;
                    case "Operatie":
                        operatieId = controls["operatieIdTextBox"].Text;
                        operatieId1 = -1;
                        if (operatieId != "" && !int.TryParse(operatieId, out operatieId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        denumire = controls["denumireTextBox"].Text;
                        var timpExecutie = controls["timpExecutieTextBox"].Text;
                        var timpExecutie1 = -1m;
                        if (timpExecutie != "" && !decimal.TryParse(timpExecutie, out timpExecutie1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        OperatieView(unitOfWork.OperatieRepository.Get(a =>
                        (operatieId == "" || a.OperatieId == operatieId1)
                        && (denumire == "" || a.Denumire == denumire)
                        && (timpExecutie == "" || a.TimpExecutie == timpExecutie1)
                        ));
                        form.Close();
                        break;
                    case "Sasiu":
                        sasiuId = controls["sasiuIdTextBox"].Text;
                        sasiuId1 = -1;
                        if (sasiuId != "" && !int.TryParse(sasiuId, out sasiuId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var codSasiu = controls["codSasiuTextBox"].Text;
                        denumire = controls["denumireTextBox"].Text;
                        SasiuView(unitOfWork.SasiuRepository.Get(a =>
                        (sasiuId == "" || a.SasiuId == sasiuId1)
                        && (codSasiu == "" || a.CodSasiu == codSasiu)
                        && (denumire == "" || a.Denumire == denumire)
                        ));
                        form.Close();
                        break;
                    case "Imagine":
                        var imagineId = controls["imagineIdTextBox"].Text;
                        var imagineId1 = -1;
                        if (imagineId != "" && !int.TryParse(imagineId, out imagineId1))
                        {
                            MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        var titlu = controls["titluTextBox"].Text;
                        descriere = controls["descriereTextBox"].Text;
                        ImagineView(unitOfWork.ImagineRepository.Get(a =>
                        (imagineId == "" || a.ImagineId == imagineId1)
                        && (titlu == "" || a.Titlu == titlu)
                        && (descriere == "" || a.Descriere == descriere)
                        ));
                        form.Close();
                        break;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Entitate nevalida", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Close();
            }
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor autoturisme.
        /// </summary>
        private void AutoColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("autoId", "AutoId");
            entitiesDataGridView.Columns.Add("numarAuto", "NumarAuto");
            entitiesDataGridView.Columns.Add("sasiuId", "SasiuId");
            entitiesDataGridView.Columns.Add("serieSasiu", "SerieSasiu");
            entitiesDataGridView.Columns.Add("clientId", "ClientId");
        }

        /// <summary>
        /// Afiseaza autoturismele dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="autoCollection">Colectie de autoturisme.</param>
        private void AutoView(IEnumerable<Auto> autoCollection)
        {
            AutoColumns();
            foreach (var item in autoCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.AutoId.ToString(), item.NumarAuto, item.SasiuSasiuId.ToString(), item.SerieSasiu, item.ClientClientId.ToString() });
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor clienti.
        /// </summary>
        private void ClientColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("clientId", "ClientId");
            entitiesDataGridView.Columns.Add("nume", "Nume");
            entitiesDataGridView.Columns.Add("prenume", "Prenume");
            entitiesDataGridView.Columns.Add("adresa", "Adresa");
            entitiesDataGridView.Columns.Add("localitate", "Localitate");
            entitiesDataGridView.Columns.Add("judet", "Judet");
            entitiesDataGridView.Columns.Add("telefon", "Telefon");
            entitiesDataGridView.Columns.Add("email", "Email");
        }

        /// <summary>
        /// Afiseaza clientii dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="clientCollection">Colectie de clienti.</param>
        private void ClientView(IEnumerable<Client> clientCollection)
        {
            ClientColumns();
            foreach (var item in clientCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.ClientId.ToString(), item.Nume, item.Prenume, item.Adresa, item.Localitate, item.Judet, item.Telefon, item.Email });
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor sasiuri.
        /// </summary>
        private void SasiuColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("sasiuId", "SasiuId");
            entitiesDataGridView.Columns.Add("codSasiu", "CodSasiu");
            entitiesDataGridView.Columns.Add("denumire", "Denumire");
        }

        /// <summary>
        /// Afiseaza sasiurile dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="sasiuCollection">Colectie de sasiuri.</param>
        private void SasiuView(IEnumerable<Sasiu> sasiuCollection)
        {
            SasiuColumns();
            foreach (var item in sasiuCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.SasiuId.ToString(), item.CodSasiu, item.Denumire});
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor mecanici.
        /// </summary>
        private void MecanicColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("mecanicId", "MecanicId");
            entitiesDataGridView.Columns.Add("nume", "Nume");
            entitiesDataGridView.Columns.Add("prenume", "Prenume");
        }

        /// <summary>
        /// Afiseaza mecanicii dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="mecanicCollection">Colectie de mecanici.</param>
        private void MecanicView(IEnumerable<Mecanic> mecanicCollection)
        {
            MecanicColumns();
            foreach (var item in mecanicCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.MecanicId.ToString(), item.Nume, item.Prenume});
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor materiale.
        /// </summary>
        private void MaterialColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("materialId", "MaterialId");
            entitiesDataGridView.Columns.Add("denumire", "Denumire");
            entitiesDataGridView.Columns.Add("cantitate", "Cantitate");
            entitiesDataGridView.Columns.Add("pret", "Pret");
            entitiesDataGridView.Columns.Add("dataAprovizionare", "DataAprovizionare");
        }

        /// <summary>
        /// Afiseaza materialele dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="materialCollection">Colectie de materiale.</param>
        private void MaterialView(IEnumerable<Material> materialCollection)
        {
            MaterialColumns();
            foreach (var item in materialCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.MaterialId.ToString(), item.Denumire, item.Cantitate.ToString(), item.Pret.ToString(), item.DataAprovizionare.ToString() });
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor operatii.
        /// </summary>
        private void OperatieColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("operatieId", "OperatieId");
            entitiesDataGridView.Columns.Add("denumire", "Denumire");
            entitiesDataGridView.Columns.Add("timpExecutie", "TimpExecutie");
        }

        /// <summary>
        /// Afiseaza operatiile dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="operatieCollection">Colectie de operatii.</param>
        private void OperatieView(IEnumerable<Operatie> operatieCollection)
        {
            OperatieColumns();
            foreach (var item in operatieCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.OperatieId.ToString(), item.Denumire, item.TimpExecutie.ToString() });
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor imagini.
        /// </summary>
        private void ImagineColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("imagineId", "ImagineId");
            entitiesDataGridView.Columns.Add("detaliuComandaId", "DetaliuComandaId");
            entitiesDataGridView.Columns.Add("titlu", "Titlu");
            entitiesDataGridView.Columns.Add("descriere", "Descriere");
            entitiesDataGridView.Columns.Add("data", "Data");
            var a = new DataGridViewImageColumn();
            a.Name = "foto";
            a.HeaderText = "Foto";
            a.ImageLayout = DataGridViewImageCellLayout.Zoom;
            entitiesDataGridView.Columns.Add(a);
        }

        /// <summary>
        /// Afiseaza imaginile dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="imagineCollection">Colectie de imagini.</param>
        private void ImagineView(IEnumerable<Imagine> imagineCollection)
        {
            ImagineColumns();
            int nr = 0;
            foreach (var item in imagineCollection)
            {
                MemoryStream ms = new MemoryStream(item.Foto);
                Image image = Image.FromStream(ms);
                entitiesDataGridView.Rows.Add(new string[] { item.ImagineId.ToString(), item.DetaliuComanda.DetaliuComandaId.ToString(), item.Titlu, item.Descriere, item.Data.ToString()});
                entitiesDataGridView[5, nr].Value = image;
                nr++;
            }
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor comenzi.
        /// </summary>
        private void ComandaColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("comandaId", "ComandaId");
            entitiesDataGridView.Columns.Add("clientId", "ClientId");
            entitiesDataGridView.Columns.Add("autoId", "AutoId");
            entitiesDataGridView.Columns.Add("stareComanda", "StareComanda");
            entitiesDataGridView.Columns.Add("dataSystem", "DataSystem");
            entitiesDataGridView.Columns.Add("dataProgramare", "DataProgramare");
            entitiesDataGridView.Columns.Add("dataFinalizare", "DataFinalizare");
            entitiesDataGridView.Columns.Add("kmBord", "KmBord");
            entitiesDataGridView.Columns.Add("descriere", "Descriere");
            entitiesDataGridView.Columns.Add("valoarePiese", "ValoarePiese");
        }

        /// <summary>
        /// Afiseaza comenzile dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="comandaCollection">Colectie de comenzi.</param>
        private void ComandaView(IEnumerable<Comanda> comandaCollection)
        {
            ComandaColumns();
            foreach (var item in comandaCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.ComandaId.ToString(), item.ClientClientId.ToString(), item.AutoAutoId.ToString(), item.StareComanda,item.DataSystem.ToString(),item.DataProgramare.ToString(),item.DataFinalizare.ToString(),item.KmBord.ToString(),item.Descriere,item.ValoarePiese.ToString() });
        }

        /// <summary>
        /// Pregateste obiectul de tip DataGridView pentru afisarea unor detalii ale unor comenzi.
        /// </summary>
        private void DetaliuComandaColumns()
        {
            entitiesDataGridView.Columns.Clear();
            entitiesDataGridView.Columns.Add("detaliuComandaId", "DetaliuComandaId");
            entitiesDataGridView.Columns.Add("comandaId", "ComandaId");
            entitiesDataGridView.Columns.Add("mecanicId", "MecanicId");
            entitiesDataGridView.Columns.Add("materialId", "MaterialId");
            entitiesDataGridView.Columns.Add("operatieId", "OperatieId");
            entitiesDataGridView.Columns.Add("imagineId", "ImagineId");
        }

        /// <summary>
        /// Afiseaza detaliile unor comenzi dintr-o colectie in obiectul de tip DataGridView.
        /// </summary>
        /// <param name="detaliuComandaCollection">Colectie de detalii comenzi.</param>
        private void DetaliuComandaView(IEnumerable<DetaliuComanda> detaliuComandaCollection)
        {
            DetaliuComandaColumns();
            foreach (var item in detaliuComandaCollection)
                entitiesDataGridView.Rows.Add(new string[] { item.DetaliuComandaId.ToString(), item.ComandaComandaId.ToString(), item.MecanicMecanicId.ToString(), item.MaterialMaterialId.ToString(), item.OperatieOperatieId.ToString(), (item.Imagine!=null)?item.Imagine.ImagineId.ToString():"" });
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Vizualizare colectie, duce la afisarea tuturor elementelor din colectia de tipul selectat.
        /// </summary>
        private void ViewingBtn_Click(object sender, EventArgs e)
        {
            if (entitiesComboBox.SelectedIndex != -1)
            {
                switch (entitiesComboBox.SelectedItem.ToString())
                {
                    case "Auto":
                        AutoView(unitOfWork.AutoRepository.Get()); break;
                    case "Client":
                        ClientView(unitOfWork.ClientRepository.Get()); break;
                    case "Comanda":
                        ComandaView(unitOfWork.ComandaRepository.Get()); break;
                    case "DetaliuComanda":
                        DetaliuComandaView(unitOfWork.DetaliuComandaRepository.Get()); break;
                    case "Mecanic":
                        MecanicView(unitOfWork.MecanicRepository.Get()); break;
                    case "Material":
                        MaterialView(unitOfWork.MaterialRepository.Get()); break;
                    case "Operatie":
                        OperatieView(unitOfWork.OperatieRepository.Get()); break;
                    case "Sasiu":
                        SasiuView(unitOfWork.SasiuRepository.Get()); break;
                    case "Imagine":
                        ImagineView(unitOfWork.ImagineRepository.Get()); break;
                }
            }
            else
                MessageBox.Show("Selectati un tip", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Editare, creeaza un nou formular.
        /// </summary>
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (entitiesDataGridView.SelectedRows.Count > 0)
            {
                var name = entitiesDataGridView.Columns[0].HeaderText.Substring(0, entitiesDataGridView.Columns[0].Name.Length - 2);
                var form = (Form)Activator.CreateInstance(Type.GetType("CarServiceApp." + name + "Form"));
                Button a = (Button)form.Controls["button1"];
                a.Click += Edit_Click;
                form.Controls[char.ToLower(name[0]) + name.Substring(1, name.Length - 1) + "IdTextBox"].Enabled = false;
                if (name == "Comanda")
                {
                    form.Controls["dataSystemTextBox"].Enabled = false;
                    form.Controls["valoarePieseTextBox"].Enabled = false;
                }
                int i = entitiesDataGridView.ColumnCount-1;
                foreach(var item in form.Controls)
                {
                    if (item is TextBox textBox)
                    {
                        var item1 = textBox;
                        if(item1.Name!="fotoTextBox")
                            item1.Text = entitiesDataGridView.SelectedRows[0].Cells[i].Value.ToString();
                        i--;
                    }
                }
                form.ShowDialog();
            }
            else
                MessageBox.Show("Selectati entitatea", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului din formularul suplimentar, se ocupa de editarea propriu-zisa.
        /// </summary>
        private void Edit_Click(object sender, EventArgs e)
        {
            Entitate item = null;
            Type type = null;
            var line = entitiesDataGridView.SelectedRows[0];
            var form = (Form)((Button)sender).Parent;
            try
            {
                switch (entitiesDataGridView.Columns[0].Name)
                {
                    case "autoId":
                        item = unitOfWork.AutoRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Auto,CarService");
                        break;
                    case "clientId":
                        item = unitOfWork.ClientRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Client,CarService");
                        break;
                    case "comandaId":
                        item = unitOfWork.ComandaRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Comanda,CarService");
                        break;
                    case "detaliuComandaId":
                        item = unitOfWork.DetaliuComandaRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.DetaliuComanda,CarService");
                        break;
                    case "mecanicId":
                        item = unitOfWork.MecanicRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Mecanic,CarService");
                        break;
                    case "materialId":
                        item = unitOfWork.MaterialRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Material,CarService");
                        break;
                    case "operatieId":
                        item = unitOfWork.OperatieRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Operatie,CarService");
                        break;
                    case "sasiuId":
                        item = unitOfWork.SasiuRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Sasiu,CarService");
                        break;
                    case "imagineId":
                        item = unitOfWork.ImagineRepository.GetById(int.Parse(line.Cells[0].Value.ToString()));
                        type = Type.GetType("CarService.Imagine,CarService");
                        break;
                }       
                foreach (var ctrl in form.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        TextBox ctrl1 = textBox;
                        if (ctrl1.Text != "")
                        {
                            string name = ctrl1.Name;
                            string propertyName = char.ToUpper(name[0]) + name.Substring(1, name.Length - 8);
                            if (propertyName.EndsWith("Id") && propertyName != entitiesDataGridView.Columns[0].HeaderText)
                                propertyName = propertyName.Substring(0, propertyName.Length - 2) + propertyName;
                            PropertyInfo prop = type.GetProperty(propertyName);
                            if (propertyName == "DetaliuComandaDetaliuComandaId")
                            {
                                if (!int.TryParse(ctrl1.Text, out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                               ((Imagine)item).DetaliuComanda = unitOfWork.DetaliuComandaRepository.GetById(value);
                                continue;
                            }
                            if (propertyName == "ValoarePiese")
                                continue;
                            if (prop.PropertyType == typeof(int))
                            {
                                if (!int.TryParse(ctrl1.Text, out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(int?))
                            {
                                if (!int.TryParse(ctrl1.Text, out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(decimal))
                            {
                                if (!decimal.TryParse(ctrl1.Text, out decimal value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, value, null);
                            }
                            else if (prop.PropertyType == typeof(DateTime))
                            {
                                if (!DateTime.TryParse(ctrl1.Text, out DateTime value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    MessageBox.Show("Imaginea nu poate fi citita", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                if (ctrl1.Name == "telefonTextBox" && ctrl1.Text.Any(c => c < '0' || c > '9'))
                                {
                                    MessageBox.Show("Nr de telefon nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        MessageBox.Show("email nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        MessageBox.Show("Numar auto nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                if (ctrl1.Name == "codSasiuTextBox" && (ctrl1.Text.Count() != 2 || !char.IsLetterOrDigit(ctrl1.Text[0]) || !char.IsLetterOrDigit(ctrl1.Text[1])))
                                {
                                    MessageBox.Show("Cod sasiu nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                prop.SetValue(item, ctrl1.Text, null);
                            }
                                
                        }
                        else if (!(entitiesDataGridView.Columns[0].Name == "detaliuComandaId" && ctrl1.Name == "imagineIdTextBox"))
                        {
                            MessageBox.Show("Proprietate obligatorie", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                switch (entitiesComboBox.SelectedItem.ToString())
                {
                    case "Auto":
                        var auto = (Auto)item;
                        unitOfWork.AutoRepository.Edit((Auto)item);
                        unitOfWork.Save();
                        line.Cells[1].Value = auto.NumarAuto;
                        line.Cells[2].Value = auto.SasiuSasiuId.ToString();
                        line.Cells[3].Value = auto.SerieSasiu;
                        line.Cells[4].Value = auto.ClientClientId.ToString();
                        break;
                    case "Client":
                        var cl = (Client)item;
                        unitOfWork.ClientRepository.Edit(cl);
                        unitOfWork.Save();
                        line.Cells[1].Value = cl.Nume;
                        line.Cells[2].Value = cl.Prenume;
                        line.Cells[3].Value = cl.Adresa;
                        line.Cells[4].Value = cl.Localitate;
                        line.Cells[5].Value = cl.Judet;
                        line.Cells[6].Value = cl.Telefon;
                        line.Cells[7].Value = cl.Email;
                        break;
                    case "Comanda":
                        var comanda = (Comanda)item;
                        unitOfWork.ComandaRepository.Edit(comanda);
                        unitOfWork.Save();
                        line.Cells[1].Value = comanda.ClientClientId.ToString();
                        line.Cells[2].Value = comanda.AutoAutoId.ToString();
                        line.Cells[3].Value = comanda.StareComanda;
                        line.Cells[4].Value = comanda.DataSystem.ToString();
                        line.Cells[5].Value = comanda.DataProgramare.ToString();
                        line.Cells[6].Value = comanda.DataFinalizare.ToString();
                        line.Cells[7].Value = comanda.KmBord.ToString();
                        line.Cells[8].Value = comanda.Descriere;
                        line.Cells[9].Value = comanda.ValoarePiese.ToString();
                        break;
                    case "DetaliuComanda":
                        var detaliuComanda = (DetaliuComanda)item;
                        unitOfWork.DetaliuComandaRepository.Edit(detaliuComanda);
                        unitOfWork.Save();
                        line.Cells[1].Value = detaliuComanda.ComandaComandaId.ToString();
                        line.Cells[2].Value = detaliuComanda.MecanicMecanicId.ToString();
                        line.Cells[3].Value = detaliuComanda.MaterialMaterialId.ToString();
                        line.Cells[4].Value = detaliuComanda.OperatieOperatieId.ToString();
                        line.Cells[5].Value = detaliuComanda.ImagineImagineId.ToString();
                        break;
                    case "Mecanic":
                        var mecanic = (Mecanic)item;
                        unitOfWork.MecanicRepository.Edit(mecanic);
                        unitOfWork.Save();
                        line.Cells[1].Value = mecanic.Nume;
                        line.Cells[2].Value = mecanic.Prenume;
                        break;
                    case "Material":
                        var material = (Material)item;
                        unitOfWork.MaterialRepository.Edit(material);
                        unitOfWork.Save();
                        line.Cells[1].Value = material.MaterialId.ToString();
                        line.Cells[2].Value = material.Denumire;
                        line.Cells[3].Value = material.Cantitate.ToString();
                        line.Cells[4].Value = material.Pret.ToString();
                        line.Cells[5].Value=material.DataAprovizionare.ToString();
                        break;
                    case "Operatie":
                        var operatie = (Operatie)item;
                        unitOfWork.OperatieRepository.Edit(operatie);
                        unitOfWork.Save();
                        line.Cells[1].Value = operatie.Denumire;
                        line.Cells[2].Value = operatie.TimpExecutie.ToString();
                        break;
                    case "Sasiu":
                        var sasiu = (Sasiu)item;
                        unitOfWork.SasiuRepository.Edit(sasiu);
                        unitOfWork.Save();
                        line.Cells[1].Value = sasiu.CodSasiu;
                        line.Cells[2].Value = sasiu.Denumire;
                        break;
                    case "Imagine":
                        var imagine = (Imagine)item;
                        unitOfWork.ImagineRepository.Edit(imagine);
                        unitOfWork.Save();
                        line.Cells[1].Value = imagine.DetaliuComanda.DetaliuComandaId.ToString();
                        line.Cells[2].Value = imagine.Titlu;
                        line.Cells[3].Value = imagine.Descriere;
                        line.Cells[4].Value = imagine.Data.ToString();
                        line.Cells[5].Value = imagine.Foto.ToString();
                        break;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Entitatea nu poate fi modificata", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            form.Close();
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Stergere, sterge entitatea selectata.
        /// </summary>
        private void RemovingBtn_Click(object sender, EventArgs e)
        {
            if (entitiesDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    switch (entitiesDataGridView.Columns[0].Name)
                    {
                        case "autoId":
                            unitOfWork.AutoRepository.Remove(unitOfWork.AutoRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "clientId":
                            unitOfWork.ClientRepository.Remove(unitOfWork.ClientRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "comandaId":
                            unitOfWork.ComandaRepository.Remove(unitOfWork.ComandaRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "sasiuId":
                            unitOfWork.SasiuRepository.Remove(unitOfWork.SasiuRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "operatieId":
                            unitOfWork.OperatieRepository.Remove(unitOfWork.OperatieRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "mecanicId":
                            unitOfWork.MecanicRepository.Remove(unitOfWork.MecanicRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "materialId":
                            unitOfWork.MaterialRepository.Remove(unitOfWork.MaterialRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "detaliuComandaId":
                            unitOfWork.DetaliuComandaRepository.Remove(unitOfWork.DetaliuComandaRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                        case "imagineId":
                            unitOfWork.ImagineRepository.Remove(unitOfWork.ImagineRepository.GetById(int.Parse(entitiesDataGridView.SelectedRows[0].Cells[0].Value.ToString())));
                            break;
                    }
                    unitOfWork.Save();
                    entitiesDataGridView.Rows.RemoveAt(entitiesDataGridView.SelectedRows[0].Index);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Entitatea nu poate fi stearsa: "+exception.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var form = (Form)((Button)sender).Parent;
                    form.Close();
                    Close();
                }
            }
            else
                MessageBox.Show("Selectati entitatea", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handler pentru evenimentul de apasare a butonului Asocieri, creeaza un formular <see cref="AssociationsForm"/>
        /// </summary>
        private void getAssociationsBtn_Click(object sender, EventArgs e)
        {
            if (entitiesDataGridView.SelectedRows.Count > 0)
            {
                var name = entitiesDataGridView.Columns[0].Name;
                try
                {
                    switch (name)
                    {
                        case "autoId":
                            var form = new AssociationsForm();
                            var tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var auto = unitOfWork.AutoRepository.GetById(value);
                                var node = tree.Nodes.Add(auto.AutoId.ToString());
                                var node1 = node.Nodes.Add("Comenzi");
                                foreach (Comanda comanda in auto.Comenzi)
                                    node1.Nodes.Add(comanda.ComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "clientId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if(!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var cl=unitOfWork.ClientRepository.GetById(value);
                                var node=tree.Nodes.Add(cl.ClientId.ToString());
                                var node1=node.Nodes.Add("Autoturisme");
                                foreach (Auto auto in cl.Autoturisme)
                                    node1.Nodes.Add(auto.AutoId.ToString());
                                var node2 = node.Nodes.Add("Comenzi");
                                foreach (Comanda comanda in cl.Comenzi)
                                    node2.Nodes.Add(comanda.ComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "comandaId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var comanda = unitOfWork.ComandaRepository.GetById(value);
                                var node = tree.Nodes.Add(comanda.ComandaId.ToString());
                                var node1 = node.Nodes.Add("DetaliiComenzi");
                                foreach (DetaliuComanda detaliuComanda in comanda.DetaliiComenzi)
                                    node1.Nodes.Add(detaliuComanda.DetaliuComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "operatieId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var operatie = unitOfWork.OperatieRepository.GetById(value);
                                var node = tree.Nodes.Add(operatie.OperatieId.ToString());
                                var node1 = node.Nodes.Add("DetaliiComenzi");
                                foreach (DetaliuComanda detaliuComanda in operatie.DetaliiComenzi)
                                    node1.Nodes.Add(detaliuComanda.DetaliuComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "materialId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var material = unitOfWork.MaterialRepository.GetById(value);
                                var node = tree.Nodes.Add(material.MaterialId.ToString());
                                var node1 = node.Nodes.Add("DetaliiComenzi");
                                foreach (DetaliuComanda detaliuComanda in material.DetaliiComenzi)
                                    node1.Nodes.Add(detaliuComanda.DetaliuComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "mecanicId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var mecanic = unitOfWork.MecanicRepository.GetById(value);
                                var node = tree.Nodes.Add(mecanic.MecanicId.ToString());
                                var node1 = node.Nodes.Add("DetaliiComenzi");
                                foreach (DetaliuComanda detaliuComanda in mecanic.DetaliiComenzi)
                                    node1.Nodes.Add(detaliuComanda.DetaliuComandaId.ToString());
                            }
                            form.Show();
                            break;
                        case "sasiuId":
                            form = new AssociationsForm();
                            tree = (TreeView)form.Controls["entitiesTreeView"];
                            foreach (DataGridViewRow item in entitiesDataGridView.SelectedRows)
                            {
                                if (!int.TryParse(item.Cells[0].Value.ToString(), out int value))
                                {
                                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                var sasiu = unitOfWork.SasiuRepository.GetById(value);
                                var node = tree.Nodes.Add(sasiu.SasiuId.ToString());
                                var node1 = node.Nodes.Add("Autoturisme");
                                foreach (Auto auto in sasiu.Autoturisme)
                                    node1.Nodes.Add(auto.AutoId.ToString());
                            }
                            form.Show();
                            break;
                        default:
                            MessageBox.Show("Tip nevalid", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Date nevalide", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Selectati entitatile","Problema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }             
        }
    }
}
