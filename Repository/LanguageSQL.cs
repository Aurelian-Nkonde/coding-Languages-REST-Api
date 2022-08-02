using System;
using System.Collections.Generic;
using codingLanguages.Data;
using codingLanguages.Models;
using Microsoft.EntityFrameworkCore;


namespace codingLanguages.Repos
{
    public class LanguageSQL : ILanguageRepo
    {
        private readonly AppDbContext _databaseContext;

        public LanguageSQL(AppDbContext databaseCcontext)
        {
            _databaseContext = databaseCcontext;
        }

        public void CreateLanguage(Language dataInput)
        {
            _databaseContext.languages.Add(dataInput);
            _databaseContext.SaveChanges();
        }

        public void DeleteALanguage(Language dataInput)
        {
            _databaseContext.languages.Remove(dataInput);
            _databaseContext.SaveChanges();
        }


        public IEnumerable<Language> GetListOfLanguages()
        {
            var LanguageList = _databaseContext.languages.ToList();
            return LanguageList;
        }


        public Language GetSingleLanguage(int? id)
        {
            var language = _databaseContext.languages.FirstOrDefault(e => e.Id == id);
            if(language != null)
            {
                return language;
            }
            throw new ArgumentNullException();
        }


        public string health()
        {
            return $"api is working fine";
        }


        public bool SaveChanges()
        {
            return (_databaseContext.SaveChanges() >= 1);
        }


        public void UpdateLanguage(Language dataInput)
        {
            _databaseContext.Entry(dataInput).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}