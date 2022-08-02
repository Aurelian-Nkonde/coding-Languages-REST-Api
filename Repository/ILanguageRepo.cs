using System;
using System.Collections.Generic;
using codingLanguages.Models;


namespace codingLanguages.Repos 
{
    public interface ILanguageRepo
    {
        public bool SaveChanges();
        public string health();
        public IEnumerable<Language> GetListOfLanguages();
        public Language GetSingleLanguage(int? id);
        public void DeleteALanguage(Language dataInput);
        public void UpdateLanguage(Language dataInput);
        public void CreateLanguage(Language dataInput);
    }
}