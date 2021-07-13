using System;
using System.Collections.Generic;
using System.Linq;
using CarService;

namespace ObjectWCF
{
    public class Service : IService
    {
        void IAuto.AddAuto(Auto entity)
        {
            using(IUnitOfWork unit=new UnitOfWork())
            {
                unit.AutoRepository.Add(entity);
                unit.Save();
            }
        }

        void IClient.AddClient(Client entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.Add(entity);
                unit.Save();
            }
        }

        void IComanda.AddComanda(Comanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.Add(entity);
                unit.Save();
            }
        }

        void IDetaliuComanda.AddDetaliuComanda(DetaliuComanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.Add(entity);
                unit.Save();
            }
        }

        void IImagine.AddImagine(Imagine entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.Add(entity);
                unit.DetaliuComandaRepository.Edit(entity.DetaliuComanda);
                unit.Save();
            }
        }

        void IMaterial.AddMaterial(Material entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.Add(entity);
                unit.Save();
            }
        }

        void IMecanic.AddMecanic(Mecanic entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.Add(entity);
                unit.Save();
            }
        }

        void IOperatie.AddOperatie(Operatie entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.Add(entity);
                unit.Save();
            }
        }

        void ISasiu.AddSasiu(Sasiu entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.Add(entity);
                unit.Save();
            }
        }

        void IAuto.AddRangeOfAutoturisme(IEnumerable<Auto> entities)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                unit.AutoRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IClient.AddRangeOfClienti(IEnumerable<Client> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IComanda.AddRangeOfComenzi(IEnumerable<Comanda> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IDetaliuComanda.AddRangeOfDetaliiComenzi(IEnumerable<DetaliuComanda> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IImagine.AddRangeOfImagini(IEnumerable<Imagine> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IMaterial.AddRangeOfMateriale(IEnumerable<Material> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IMecanic.AddRangeOfMecanici(IEnumerable<Mecanic> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IOperatie.AddRangeOfOperatii(IEnumerable<Operatie> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.AddRange(entities);
                unit.Save();
            }
        }

        void ISasiu.AddRangeOfSasiuri(IEnumerable<Sasiu> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.AddRange(entities);
                unit.Save();
            }
        }

        void IAuto.ClearAutoturisme()
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                unit.AutoRepository.Clear();
                unit.Save();
            }
        }

        void IClient.ClearClienti()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.Clear();
                unit.Save();
            }
        }

        void IComanda.ClearComenzi()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.Clear();
                unit.Save();
            }
        }

        void IDetaliuComanda.ClearDetaliiComenzi()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.Clear();
                unit.Save();
            }
        }

        void IImagine.ClearImagini()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.Clear();
                unit.Save();
            }
        }

        void IMaterial.ClearMateriale()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.Clear();
                unit.Save();
            }
        }

        void IMecanic.ClearMecanici()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.Clear();
                unit.Save();
            }
        }

        void IOperatie.ClearOperatii()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.Clear();
                unit.Save();
            }
        }

        void ISasiu.ClearSasiuri()
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.Clear();
                unit.Save();
            }
        }

        bool IAuto.ContainsAuto(Auto entity, IEqualityComparer<Auto> comparer)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                return unit.AutoRepository.Contains(entity, comparer);
            }
        }

        bool IClient.ContainsClient(Client entity, IEqualityComparer<Client> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ClientRepository.Contains(entity, comparer);
            }
        }

        bool IComanda.ContainsComanda(Comanda entity, IEqualityComparer<Comanda> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ComandaRepository.Contains(entity, comparer);
            }
        }

        bool IDetaliuComanda.ContainsDetaliuComanda(DetaliuComanda entity, IEqualityComparer<DetaliuComanda> comparer)
        { 
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.DetaliuComandaRepository.Contains(entity, comparer);
            }
        }

        bool IImagine.ContainsImagine(Imagine entity, IEqualityComparer<Imagine> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ImagineRepository.Contains(entity, comparer);
            }
        }

        bool IMaterial.ContainsMaterial(Material entity, IEqualityComparer<Material> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.MaterialRepository.Contains(entity, comparer);
            }
        }

        bool IMecanic.ContainsMecanic(Mecanic entity, IEqualityComparer<Mecanic> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.MecanicRepository.Contains(entity, comparer);
            }
        }

        bool IOperatie.ContainsOperatie(Operatie entity, IEqualityComparer<Operatie> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.OperatieRepository.Contains(entity, comparer);
            }
        }

        bool ISasiu.ContainsSasiu(Sasiu entity, IEqualityComparer<Sasiu> comparer)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.SasiuRepository.Contains(entity, comparer);
            }
        }

        int IAuto.CountAutoturisme(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                if (criteria == null)
                    return unit.AutoRepository.Count();
                var autoId = (int)criteria["autoId"];
                var numarAuto = criteria["numarAuto"].ToString();
                var sasiuId = (int)criteria["sasiuId"];
                var serieSasiu = criteria["serieSasiu"].ToString();
                var clientId = (int)criteria["clientId"];
                return unit.AutoRepository.Count(a =>
                      (autoId == -1 || autoId == a.AutoId)
                      && (numarAuto == "" || numarAuto == a.NumarAuto)
                      && (sasiuId == -1 || sasiuId == a.SasiuSasiuId)
                      && (serieSasiu == "" || serieSasiu == a.SerieSasiu)
                      && (clientId == -1 || clientId == a.ClientClientId));
            }
        }

        int IClient.CountClienti(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ClientRepository.Count();
                var clientId = (int)criteria["clientId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                var localitate = criteria["localitate"].ToString();
                var adresa = criteria["adresa"].ToString();
                var judet = criteria["judet"].ToString();
                var telefon = criteria["telefon"].ToString();
                var email = criteria["email"].ToString();
                return unit.ClientRepository.Count(a => (clientId == -1 || clientId == a.ClientId)
                        && (nume == "" || nume == a.Nume)
                        && (prenume == "" || prenume == a.Prenume)
                        && (localitate == "" || localitate == a.Localitate)
                        && (adresa == "" || adresa == a.Adresa)
                        && (judet == "" || judet == a.Judet)
                        && (telefon == "" || telefon == a.Telefon)
                        && (email == "" || email == a.Email));
            }
        }

        int IComanda.CountComenzi(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ComandaRepository.Count();
                var comandaId = (int)criteria["comandaId"];
                var clientId = (int)criteria["clientId"];
                var autoId = (int)criteria["autoId"];
                var stareComanda = criteria["stareComanda"].ToString();
                var kmBord = (int)criteria["kmBord"];
                var descriere = criteria["descriere"].ToString();
                var dataSystem = (DateTime)criteria["dataSystem"];
                var dataProgramare = (DateTime)criteria["dataProgramare"];
                var dataFinalizare = (DateTime)criteria["dataFinalizare"];
                var testDateTime = new DateTime(2000, 01, 01);
                return unit.ComandaRepository.Count(a => (comandaId==-1 || comandaId==a.ComandaId)
                         && (clientId==-1 || clientId==a.ClientClientId)
                         && (autoId==-1 || autoId==a.AutoAutoId)
                         && (stareComanda=="" || stareComanda==a.StareComanda)
                         && (kmBord==-1 || kmBord==a.KmBord)
                         && (descriere=="" || descriere==a.Descriere)
                         && (dataSystem==testDateTime || dataSystem==a.DataSystem)
                         && (dataProgramare==testDateTime || dataProgramare==a.DataProgramare)
                         && (dataFinalizare==testDateTime || dataFinalizare==a.DataFinalizare));
            }
        }

        int IDetaliuComanda.CountDetaliiComenzi(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.DetaliuComandaRepository.Count();
                var detaliuComandaId = (int)criteria["detaliuComandaId"];
                var comandaId = (int)criteria["comandaId"];
                var materialId = (int)criteria["materialId"];
                var mecanicId = (int)criteria["mecanicId"];
                var operatieId = (int)criteria["operatieId"];
                return unit.DetaliuComandaRepository.Count(a => (detaliuComandaId == -1 || detaliuComandaId == a.DetaliuComandaId)
                        && (comandaId == -1 || comandaId == a.ComandaComandaId)
                        && (materialId == -1 || materialId == a.MaterialMaterialId)
                        && (mecanicId == -1 || mecanicId == a.MecanicMecanicId)
                        && (operatieId == -1 || operatieId == a.OperatieOperatieId));
            }
        }

        int IImagine.CountImagini(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ImagineRepository.Count();
                var imagineId = (int)criteria["imagineId"];
                var titlu = criteria["titlu"].ToString();
                var descriere = criteria["descriere"].ToString();
                return unit.ImagineRepository.Count(a => (imagineId==-1 || imagineId==a.ImagineId)
                        && (titlu=="" || titlu==a.Titlu)
                        && (descriere=="" || descriere==a.Descriere));  
            }
        }

        int IMaterial.CountMateriale(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MaterialRepository.Count();
                var materialId = (int)criteria["materialId"];
                var denumire = criteria["denumire"].ToString();
                var cantitate = (decimal)criteria["cantitate"];
                var pret = (decimal)criteria["pret"];
                return unit.MaterialRepository.Count(a => (materialId == -1 || materialId == a.MaterialId)
                        && (denumire == "" || denumire == a.Denumire)
                        && (cantitate == -1m || cantitate == a.Cantitate)
                        && (pret == -1m || pret == a.Pret));
            }
        }

        int IMecanic.CountMecanici(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MecanicRepository.Count();
                var mecanicId = (int)criteria["mecanicId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                return unit.MecanicRepository.Count(a => (mecanicId==-1 || mecanicId==a.MecanicId)
                        && (nume=="" || nume==a.Nume)
                        && (prenume=="" || prenume==a.Prenume));
            }
        }

        int IOperatie.CountOperatii(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.OperatieRepository.Count();
                var operatieId = (int)criteria["operatieId"];
                var denumire = criteria["denumire"].ToString();
                var timpExecutie = (decimal)criteria["timpExecutie"];
                return unit.OperatieRepository.Count(a => (operatieId==-1 || operatieId==a.OperatieId)
                        && (denumire=="" || denumire==a.Denumire)
                        && (timpExecutie==-1m || timpExecutie==a.TimpExecutie));
            }
        }

        int ISasiu.CountSasiuri(IDictionary<string, object> criteria)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.SasiuRepository.Count();
                var sasiuId = (int)criteria["sasiuId"];
                var codSasiu = criteria["codSasiu"].ToString();
                var denumire = criteria["denumire"].ToString();
                return unit.SasiuRepository.Count(a => (sasiuId==-1 || sasiuId==a.SasiuId)
                         && (codSasiu=="" || codSasiu==a.CodSasiu)
                         && (denumire=="" || denumire==a.Denumire));
            }
        }

        void IAuto.EditAuto(Auto entity)
        {
           using (IUnitOfWork unit = new UnitOfWork())
           {
                unit.AutoRepository.Edit(entity);
                unit.Save();
           }
        }

        void IClient.EditClient(Client entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.Edit(entity);
                unit.Save();
            }
        }

        void IComanda.EditComanda(Comanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.Edit(entity);
                unit.Save();
            }
        }

        void IDetaliuComanda.EditDetaliuComanda(DetaliuComanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.Edit(entity);
                unit.Save();
            }
        }

        void IImagine.EditImagine(Imagine entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.Edit(entity);
                unit.Save();
            }
        }

        void IMaterial.EditMaterial(Material entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.Edit(entity);
                unit.Save();
            }
        }

        void IMecanic.EditMecanic(Mecanic entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.Edit(entity);
                unit.Save();
            }
        }

        void IOperatie.EditOperatie(Operatie entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.Edit(entity);
                unit.Save();
            }
        }

        void ISasiu.EditSasiu(Sasiu entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.Edit(entity);
                unit.Save();
            }
        }
        
        Auto IAuto.FirstOrDefaultAuto(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                if (criteria == null)
                    return unit.AutoRepository.FirstOrDefault(propertiesToInclude:propertiesToInclude);
                var autoId = (int)criteria["autoId"];
                var numarAuto = criteria["numarAuto"].ToString();
                var sasiuId = (int)criteria["sasiuId"];
                var serieSasiu = criteria["serieSasiu"].ToString();
                var clientId = (int)criteria["clientId"];
                return unit.AutoRepository.FirstOrDefault(a =>
                      (autoId == -1 || autoId == a.AutoId)
                      && (numarAuto == "" || numarAuto == a.NumarAuto)
                      && (sasiuId == -1 || sasiuId == a.SasiuSasiuId)
                      && (serieSasiu == "" || serieSasiu == a.SerieSasiu)
                      && (clientId == -1 || clientId == a.ClientClientId),propertiesToInclude);
            }
        }

        Client IClient.FirstOrDefaultClient(IDictionary <string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ClientRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var clientId = (int)criteria["clientId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                var localitate = criteria["localitate"].ToString();
                var adresa = criteria["adresa"].ToString();
                var judet = criteria["judet"].ToString();
                var telefon = criteria["telefon"].ToString();
                var email = criteria["email"].ToString();
                return unit.ClientRepository.FirstOrDefault(a => (clientId == -1 || clientId == a.ClientId)
                        && (nume == "" || nume == a.Nume)
                        && (prenume == "" || prenume == a.Prenume)
                        && (localitate == "" || localitate == a.Localitate)
                        && (adresa == "" || adresa == a.Adresa)
                        && (judet == "" || judet == a.Judet)
                        && (telefon == "" || telefon == a.Telefon)
                        && (email == "" || email == a.Email),propertiesToInclude);
            }
        }

        Comanda IComanda.FirstOrDefaultComanda(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ComandaRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var comandaId = (int)criteria["comandaId"];
                var clientId = (int)criteria["clientId"];
                var autoId = (int)criteria["autoId"];
                var stareComanda = criteria["stareComanda"].ToString();
                var kmBord = (int)criteria["kmBord"];
                var descriere = criteria["descriere"].ToString();
                var dataSystem = (DateTime)criteria["dataSystem"];
                var dataProgramare = (DateTime)criteria["dataProgramare"];
                var dataFinalizare = (DateTime)criteria["dataFinalizare"];
                var testDateTime = new DateTime(2000, 01, 01);
                return unit.ComandaRepository.FirstOrDefault(a => (comandaId == -1 || comandaId == a.ComandaId)
                         && (clientId == -1 || clientId == a.ClientClientId)
                         && (autoId == -1 || autoId == a.AutoAutoId)
                         && (stareComanda == "" || stareComanda == a.StareComanda)
                         && (kmBord == -1 || kmBord == a.KmBord)
                         && (descriere == "" || descriere == a.Descriere)
                         && (dataSystem == testDateTime || dataSystem == a.DataSystem)
                         && (dataProgramare == testDateTime || dataProgramare == a.DataProgramare)
                         && (dataFinalizare == testDateTime || dataFinalizare == a.DataFinalizare),propertiesToInclude);
            }
        }

        DetaliuComanda IDetaliuComanda.FirstOrDefaultDetaliuComanda(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.DetaliuComandaRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var detaliuComandaId = (int)criteria["detaliuComandaId"];
                var comandaId = (int)criteria["comandaId"];
                var materialId = (int)criteria["materialId"];
                var mecanicId = (int)criteria["mecanicId"];
                var operatieId = (int)criteria["operatieId"];
                return unit.DetaliuComandaRepository.FirstOrDefault(a => (detaliuComandaId==-1 || detaliuComandaId==a.DetaliuComandaId)
                        && (comandaId==-1 || comandaId==a.ComandaComandaId)
                        && (materialId==-1 || materialId==a.MaterialMaterialId)
                        && (mecanicId==-1 || mecanicId==a.MecanicMecanicId)
                        && (operatieId==-1 || operatieId==a.OperatieOperatieId), propertiesToInclude);
            }
        }

        Imagine IImagine.FirstOrDefaultImagine(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ImagineRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var imagineId = (int)criteria["imagineId"];
                var titlu = criteria["titlu"].ToString();
                var descriere = criteria["descriere"].ToString();
                return unit.ImagineRepository.FirstOrDefault(a => (imagineId == -1 || imagineId == a.ImagineId)
                        && (titlu == "" || titlu == a.Titlu)
                        && (descriere == "" || descriere == a.Descriere),propertiesToInclude);
            }
        }

        Material IMaterial.FirstOrDefaultMaterial(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MaterialRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var materialId = (int)criteria["materialId"];
                var denumire = criteria["denumire"].ToString();
                var cantitate = (decimal)criteria["cantitate"];
                var pret = (decimal)criteria["pret"];
                return unit.MaterialRepository.FirstOrDefault(a => (materialId==-1 || materialId==a.MaterialId)
                        && (denumire=="" || denumire==a.Denumire)
                        && (cantitate==-1m || cantitate==a.Cantitate)
                        && (pret==-1m || pret==a.Pret), propertiesToInclude);
            }
        }

        Mecanic IMecanic.FirstOrDefaultMecanic(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MecanicRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var mecanicId = (int)criteria["mecanicId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                return unit.MecanicRepository.FirstOrDefault(a => (mecanicId == -1 || mecanicId == a.MecanicId)
                        && (nume == "" || nume == a.Nume)
                        && (prenume == "" || prenume == a.Prenume),propertiesToInclude);
            }
        }

        Operatie IOperatie.FirstOrDefaultOperatie(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.OperatieRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var operatieId = (int)criteria["operatieId"];
                var denumire = criteria["denumire"].ToString();
                var timpExecutie = (decimal)criteria["timpExecutie"];
                return unit.OperatieRepository.FirstOrDefault(a => (operatieId == -1 || operatieId == a.OperatieId)
                        && (denumire == "" || denumire == a.Denumire)
                        && (timpExecutie == -1m || timpExecutie == a.TimpExecutie),propertiesToInclude);
            }
        }

        Sasiu ISasiu.FirstOrDefaultSasiu(IDictionary<string, object> criteria, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.SasiuRepository.FirstOrDefault(propertiesToInclude: propertiesToInclude);
                var sasiuId = (int)criteria["sasiuId"];
                var codSasiu = criteria["codSasiu"].ToString();
                var denumire = criteria["denumire"].ToString();
                return unit.SasiuRepository.FirstOrDefault(a => (sasiuId == -1 || sasiuId == a.SasiuId)
                         && (codSasiu == "" || codSasiu == a.CodSasiu)
                         && (denumire == "" || denumire == a.Denumire),propertiesToInclude);
            }
        }

        IEnumerable<Auto> IAuto.GetAutoturisme(IDictionary<string, object> criteria, Func<IQueryable<Auto>, IOrderedQueryable<Auto>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                if (criteria == null)
                    return unit.AutoRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var autoId = (int)criteria["autoId"];
                var numarAuto = criteria["numarAuto"].ToString();
                var sasiuId = (int)criteria["sasiuId"];
                var serieSasiu = criteria["serieSasiu"].ToString();
                var clientId = (int)criteria["clientId"];
                return unit.AutoRepository.Get(a =>
                      (autoId == -1 || autoId == a.AutoId)
                      && (numarAuto == "" || numarAuto == a.NumarAuto)
                      && (sasiuId == -1 || sasiuId == a.SasiuSasiuId)
                      && (serieSasiu == "" || serieSasiu == a.SerieSasiu)
                      && (clientId == -1 || clientId == a.ClientClientId),ordering,propertiesToInclude);
            }
        }

        IEnumerable<Client> IClient.GetClienti(IDictionary <string, object> criteria, Func<IQueryable<Client>, IOrderedQueryable<Client>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ClientRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var clientId = (int)criteria["clientId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                var localitate = criteria["localitate"].ToString();
                var adresa = criteria["adresa"].ToString();
                var judet = criteria["judet"].ToString();
                var telefon = criteria["telefon"].ToString();
                var email = criteria["email"].ToString();
                return unit.ClientRepository.Get(a => (clientId == -1 || clientId == a.ClientId)
                        && (nume == "" || nume == a.Nume)
                        && (prenume == "" || prenume == a.Prenume)
                        && (localitate == "" || localitate == a.Localitate)
                        && (adresa == "" || adresa == a.Adresa)
                        && (judet == "" || judet == a.Judet)
                        && (telefon == "" || telefon == a.Telefon)
                        && (email == "" || email == a.Email),ordering,propertiesToInclude);
            }
        }

        IEnumerable<Comanda> IComanda.GetComenzi(IDictionary<string, object> criteria, Func<IQueryable<Comanda>, IOrderedQueryable<Comanda>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ComandaRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var comandaId = (int)criteria["comandaId"];
                var clientId = (int)criteria["clientId"];
                var autoId = (int)criteria["autoId"];
                var stareComanda = criteria["stareComanda"].ToString();
                var kmBord = (int)criteria["kmBord"];
                var descriere = criteria["descriere"].ToString();
                var dataSystem = (DateTime)criteria["dataSystem"];
                var dataProgramare = (DateTime)criteria["dataProgramare"];
                var dataFinalizare = (DateTime)criteria["dataFinalizare"];
                var testDateTime = new DateTime(2000, 01, 01);
                return unit.ComandaRepository.Get(a => (comandaId == -1 || comandaId == a.ComandaId)
                         && (clientId == -1 || clientId == a.ClientClientId)
                         && (autoId == -1 || autoId == a.AutoAutoId)
                         && (stareComanda == "" || stareComanda == a.StareComanda)
                         && (kmBord == -1 || kmBord == a.KmBord)
                         && (descriere == "" || descriere == a.Descriere)
                         && (dataSystem == testDateTime || dataSystem == a.DataSystem)
                         && (dataProgramare == testDateTime || dataProgramare == a.DataProgramare)
                         && (dataFinalizare == testDateTime || dataFinalizare == a.DataFinalizare),ordering,propertiesToInclude);
            }
        }

        IEnumerable<DetaliuComanda> IDetaliuComanda.GetDetaliiComenzi(IDictionary<string, object> criteria, Func<IQueryable<DetaliuComanda>, IOrderedQueryable<DetaliuComanda>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.DetaliuComandaRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var detaliuComandaId = (int)criteria["detaliuComandaId"];
                var comandaId = (int)criteria["comandaId"];
                var materialId = (int)criteria["materialId"];
                var mecanicId = (int)criteria["mecanicId"];
                var operatieId = (int)criteria["operatieId"];
                return unit.DetaliuComandaRepository.Get(a => (detaliuComandaId == -1 || detaliuComandaId == a.DetaliuComandaId)
                        && (comandaId == -1 || comandaId == a.ComandaComandaId)
                        && (materialId == -1 || materialId == a.MaterialMaterialId)
                        && (mecanicId == -1 || mecanicId == a.MecanicMecanicId)
                        && (operatieId == -1 || operatieId == a.OperatieOperatieId), ordering,propertiesToInclude);
            }
        }

        IEnumerable<Imagine> IImagine.GetImagini(IDictionary<string, object> criteria, Func<IQueryable<Imagine>, IOrderedQueryable<Imagine>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.ImagineRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var imagineId = (int)criteria["imagineId"];
                var titlu = criteria["titlu"].ToString();
                var descriere = criteria["descriere"].ToString();
                return unit.ImagineRepository.Get(a => (imagineId == -1 || imagineId == a.ImagineId)
                        && (titlu == "" || titlu == a.Titlu)
                        && (descriere == "" || descriere == a.Descriere),ordering,propertiesToInclude);
            }
        }

        IEnumerable<Material> IMaterial.GetMateriale(IDictionary<string, object> criteria, Func<IQueryable<Material>, IOrderedQueryable<Material>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MaterialRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var materialId = (int)criteria["materialId"];
                var denumire = criteria["denumire"].ToString();
                var cantitate = (decimal)criteria["cantitate"];
                var pret = (decimal)criteria["pret"];
                return unit.MaterialRepository.Get(a => (materialId == -1 || materialId == a.MaterialId)
                        && (denumire == "" || denumire == a.Denumire)
                        && (cantitate == -1m || cantitate == a.Cantitate)
                        && (pret == -1m || pret == a.Pret),ordering, propertiesToInclude);
            }
        }

        IEnumerable<Mecanic> IMecanic.GetMecanici(IDictionary<string, object> criteria, Func<IQueryable<Mecanic>, IOrderedQueryable<Mecanic>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.MecanicRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var mecanicId = (int)criteria["mecanicId"];
                var nume = criteria["nume"].ToString();
                var prenume = criteria["prenume"].ToString();
                return unit.MecanicRepository.Get(a => (mecanicId == -1 || mecanicId == a.MecanicId)
                        && (nume == "" || nume == a.Nume)
                        && (prenume == "" || prenume == a.Prenume),ordering,propertiesToInclude);
            }
        }

        IEnumerable<Operatie> IOperatie.GetOperatii(IDictionary<string, object> criteria, Func<IQueryable<Operatie>, IOrderedQueryable<Operatie>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.OperatieRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var operatieId = (int)criteria["operatieId"];
                var denumire = criteria["denumire"].ToString();
                var timpExecutie = (decimal)criteria["timpExecutie"];
                return unit.OperatieRepository.Get(a => (operatieId == -1 || operatieId == a.OperatieId)
                        && (denumire == "" || denumire == a.Denumire)
                        && (timpExecutie == -1m || timpExecutie == a.TimpExecutie),ordering,propertiesToInclude);
            }
        }

        IEnumerable<Sasiu> ISasiu.GetSasiuri(IDictionary<string, object> criteria, Func<IQueryable<Sasiu>, IOrderedQueryable<Sasiu>> ordering, string propertiesToInclude)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                if (criteria == null)
                    return unit.SasiuRepository.Get(ordering: ordering, propertiesToInclude: propertiesToInclude);
                var sasiuId = (int)criteria["sasiuId"];
                var codSasiu = criteria["codSasiu"].ToString();
                var denumire = criteria["denumire"].ToString();
                return unit.SasiuRepository.Get(a => (sasiuId == -1 || sasiuId == a.SasiuId)
                         && (codSasiu == "" || codSasiu == a.CodSasiu)
                         && (denumire == "" || denumire == a.Denumire),ordering,propertiesToInclude);
            }
        }
        
        Auto IAuto.GetAutoById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.AutoRepository.GetById(id);
            }
        }

        Client IClient.GetClientById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ClientRepository.GetById(id);
            }
        }

        Comanda IComanda.GetComandaById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ComandaRepository.GetById(id);
            }
        }

        DetaliuComanda IDetaliuComanda.GetDetaliuComandaById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.DetaliuComandaRepository.GetById(id);
            }
        }

        Imagine IImagine.GetImagineById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.ImagineRepository.GetById(id);
            }
        }

        Material IMaterial.GetMaterialById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.MaterialRepository.GetById(id);
            }
        }

        Mecanic IMecanic.GetMecanicById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.MecanicRepository.GetById(id);
            }
        }

        Operatie IOperatie.GetOperatieById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.OperatieRepository.GetById(id);
            }
        }

        Sasiu ISasiu.GetSasiuById(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                return unit.SasiuRepository.GetById(id);
            }
        }

        void IAuto.RemoveAuto(Auto entity)
        {
            using (IUnitOfWork unit=new UnitOfWork())
            {
                unit.AutoRepository.Remove(entity);
                unit.Save();
            }
        }

        void IClient.RemoveClient(Client entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.Remove(entity);
                unit.Save();
            }
        }

        void IComanda.RemoveComanda(Comanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.Remove(entity);
                unit.Save();
            }
        }

        void IDetaliuComanda.RemoveDetaliuComanda(DetaliuComanda entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.Remove(entity);
                unit.Save();
            }
        }

        void IImagine.RemoveImagine(Imagine entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.Remove(entity);
                unit.Save();
            }
        }

        void IMaterial.RemoveMaterial(Material entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.Remove(entity);
                unit.Save();
            }
        }

        void IMecanic.RemoveMecanic(Mecanic entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.Remove(entity);
                unit.Save();
            }
        }

        void IOperatie.RemoveOperatie(Operatie entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.Remove(entity);
                unit.Save();
            }
        }

        void ISasiu.RemoveSasiu(Sasiu entity)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.Remove(entity);
                unit.Save();
            }
        }

        void IAuto.RemoveRangeOfAutoturisme(IEnumerable<Auto> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.AutoRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IClient.RemoveRangeOfClienti(IEnumerable<Client> entities)
        { 
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ClientRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IComanda.RemoveRangeOfComenzi(IEnumerable<Comanda> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ComandaRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IDetaliuComanda.RemoveRangeOfDetaliiComenzi(IEnumerable<DetaliuComanda> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.DetaliuComandaRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IImagine.RemoveRangeOfImagini(IEnumerable<Imagine> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.ImagineRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IMaterial.RemoveRangeOfMateriale(IEnumerable<Material> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MaterialRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IMecanic.RemoveRangeOfMecanici(IEnumerable<Mecanic> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.MecanicRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void IOperatie.RemoveRangeOfOperatii(IEnumerable<Operatie> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.OperatieRepository.RemoveRange(entities);
                unit.Save();
            }
        }

        void ISasiu.RemoveRangeOfSasiuri(IEnumerable<Sasiu> entities)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                unit.SasiuRepository.RemoveRange(entities);
                unit.Save();
            }
        }
    }
}
