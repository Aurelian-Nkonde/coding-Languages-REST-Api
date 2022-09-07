using System;
using System.Collections.Generic;
using codingLanguages.Models;


namespace codingLanguages.Repos 
{
    public interface ILanguageRepo
    {
        public Task<bool> SaveChanges();
        public string health();
        public Task<IEnumerable<Language>> GetListOfLanguages();
        public Task<Language> GetSingleLanguage(int? id);
        public Task DeleteALanguage(Language dataInput);
        public Task UpdateLanguage(Language dataInput);
        public Task CreateLanguage(Language dataInput);
    }
}