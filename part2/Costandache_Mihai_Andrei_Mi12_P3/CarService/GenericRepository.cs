using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace CarService
{
    /// <summary>
    /// Prezinta operatii specifice CRUD.
    /// </summary>
    /// <typeparam name="T">O clasa derivata din clasa <see cref="Entitate"/>, reprezentand o entitate din context.</typeparam>
    public class GenericRepository<T> : IRepository<T> where T:Entitate
    {
        /// <summary>
        /// Context.
        /// </summary>
        protected readonly ModelServiceContainer context;

        /// <summary>
        /// Entitatile din context.
        /// </summary>
        protected DbSet<T> entities;

        /// <summary>
        /// Initializeaza o noua instanta a clasei <see cref="GenericRepository{T}"/>.
        /// </summary>
        /// <param name="_context">Context.</param>
        public GenericRepository(ModelServiceContainer _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        /// <summary>
        /// Returneaza o entitate pe baza unui id.
        /// </summary>
        /// <param name="id">Id-ul entitatii cautate.</param>
        /// <returns>Entitatea cautata dupa id.</returns>
        public virtual T GetById(int id) => entities.Find(id);

        /// <summary>
        /// Returneaza prima entitate sau o valoare default, eventual pe baza unei conditii, cu posibilitatea de a face eager loading pe anumite proprietati asociate.
        /// </summary>
        /// <param name="predicate">Conditia care trebuie indeplinita (optional).</param>
        /// <param name="propertiesToInclude">Proprietati utilizate in eager loading (optional).</param>
        /// <returns>Prima entitate sau o valoare default.</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate=null, string propertiesToInclude = "")
        {
            IQueryable<T> entitiesQuery = entities;
            foreach (var prop in propertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                entitiesQuery = entitiesQuery.Include(prop);
            return (predicate != null) ? entitiesQuery.FirstOrDefault(predicate) : entitiesQuery.FirstOrDefault();
        }
           
        /// <summary>
        /// Returneaza toate entitatile sau doar pe cele care indeplinesc o anumita conditie, in caz ca o conditie este specificata, ordonate dupa un anumit criteriu, de asemenea optional, cu posibilitatea de a face Eager Loading pe anumite proprietati asociate.
        /// </summary>
        /// <param name="predicate">Conditia care trebuie indeplinita (optional).</param>
        /// <param name="ordering">Criteriu de ordonare (optional).</param>
        /// <param name="propertiesToInclude">Proprietati utilizate in eager loading (optional).</param>
        /// <returns>Lista de entitati</returns>
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> ordering = null,
            string propertiesToInclude = "")
        {
            IQueryable<T> entitiesQuery = (predicate != null) ? entities.Where(predicate) : entities;
            foreach (var prop in propertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                entitiesQuery = entitiesQuery.Include(prop);
            return (ordering != null) ? ordering(entitiesQuery).ToList() : entitiesQuery.ToList();
        }

        /// <summary>
        /// Returneaza numarul de entitati, care verifica eventual o conditie.
        /// </summary>
        /// <param name="predicate">Conditia care trebuie indeplinita (optional).</param>
        /// <returns>Numarul de entitati.</returns>
        public virtual int Count(Expression<Func<T, bool>> predicate = null) => (predicate != null) ? entities.Count(predicate) : entities.Count();

        /// <summary>
        /// Cauta o entitate pe baza unui comparator. 
        /// </summary>
        /// <param name="entity">Entitate.</param>
        /// <param name="comparer">Comparator.</param>
        /// <returns>True sau False in functie de existenta entitatii.</returns>
        public virtual bool Contains(T entity, IEqualityComparer<T> comparer) => entities.Contains(entity, comparer);

        /// <summary>
        /// Adauga o entitate in repository.
        /// </summary>
        /// <param name="entity">Entitatea de adaugat.</param>
        public virtual void Add(T entity) => entities.Add(entity);

        /// <summary>
        /// Adauga mai multe entitati.
        /// </summary>
        /// <param name="entities">Entitatile de adaugat.</param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
                Add(item);
        }

        /// <summary>
        /// Sterge o entitate.
        /// </summary>
        /// <param name="entity">Entitatea de sters.</param>
        public virtual void Remove(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                entities.Attach(entity);
            entities.Remove(entity);
        }
        /// <summary>
        /// Sterge mai multe entitati.
        /// </summary>
        /// <param name="entities">Entitatile de sters.</param>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            foreach(var item in entities)
                Remove(item);
        }

        /// <summary>
        /// Editeaza o entitate.
        /// </summary>
        /// <param name="entity">Entitatea modificata.</param>
        public virtual void Edit(T entity)
        {
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Sterge entitatile din repository.
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in entities)
                entities.Remove(item);
        }
    }
}
