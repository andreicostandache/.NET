using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using CarService;
namespace ObjectWCF
{
    [ServiceContract]
    interface IAuto
    {
        /// <summary>
        /// Returneaza o entitate pe baza unui id.
        /// </summary>
        /// <param name="id">Id-ul entitatii cautate.</param>
        /// <returns>Entitatea cautata dupa id.</returns>
        [OperationContract]
        Auto GetAutoById(int id);

        /// <summary>
        /// Returneaza prima entitate sau o valoare default, eventual pe baza unei conditii, cu posibilitatea de a face eager loading pe anumite proprietati asociate.
        /// </summary>
        /// <param name="criteria">Conditia care trebuie indeplinita (optional).</param>
        /// <param name="propertiesToInclude">Proprietati utilizate in eager loading (optional).</param>
        /// <returns>Prima entitate sau o valoare default.</returns>
        [OperationContract]
        Auto FirstOrDefaultAuto(IDictionary<string,object>criteria=null, string propertiesToInclude = "");

        /// <summary>
        /// Returneaza toate entitatile sau doar pe cele care indeplinesc o anumita conditie, in caz ca o conditie este specificata, ordonate dupa un anumit criteriu, de asemenea optional, cu posibilitatea de a face Eager Loading pe anumite proprietati asociate.
        /// </summary>
        /// <param name="criteria">Conditia care trebuie indeplinita (optional).</param>
        /// <param name="ordering">Criteriu de ordonare (optional).</param>
        /// <param name="propertiesToInclude">Proprietati utilizate in eager loading (optional).</param>
        /// <returns>Lista de entitati</returns>
        [OperationContract]
        IEnumerable<Auto> GetAutoturisme(IDictionary<string,object>criteria=null, Func<IQueryable<Auto>, IOrderedQueryable<Auto>> ordering = null,
            string propertiesToInclude = "");
        /// <summary>
        /// Returneaza numarul de entitati, care verifica eventual o conditie.
        /// </summary>
        /// <param name="criteria">Conditia care trebuie indeplinita (optional).</param>
        /// <returns>Numarul de entitati.</returns>
        [OperationContract]
        int CountAutoturisme(IDictionary<string,object>criteria = null);

        /// <summary>
        /// Cauta o entitate pe baza unui comparator. 
        /// </summary>
        /// <param name="entity">Entitate.</param>
        /// <param name="comparer">Comparator.</param>
        /// <returns>True sau False in functie de existenta entitatii.</returns>
        [OperationContract]
        bool ContainsAuto(Auto entity, IEqualityComparer<Auto> comparer);

        /// <summary>
        /// Adauga o entitate in repository.
        /// </summary>
        /// <param name="entity">Entitatea de adaugat.</param>
        [OperationContract]
        void AddAuto(Auto entity);

        /// <summary>
        /// Adauga mai multe entitati.
        /// </summary>
        /// <param name="entities">Entitatile de adaugat.</param>
        [OperationContract]
        void AddRangeOfAutoturisme(IEnumerable<Auto> entities);

        /// <summary>
        /// Sterge o entitate.
        /// </summary>
        /// <param name="entity">Entitatea de sters.</param>
        [OperationContract]
        void RemoveAuto(Auto entity);

        /// <summary>
        /// Sterge mai multe entitati.
        /// </summary>
        /// <param name="entities">Entitatile de sters.</param>
        [OperationContract]
        void RemoveRangeOfAutoturisme(IEnumerable<Auto> entities);

        /// <summary>
        /// Editeaza o entitate.
        /// </summary>
        /// <param name="entity">Entitatea modificata.</param>
        [OperationContract]
        void EditAuto(Auto entity);

        /// <summary>
        /// Sterge entitatile din repository.
        /// </summary>
        [OperationContract]
        void ClearAutoturisme();
    }
}