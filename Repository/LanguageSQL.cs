using System;
using System.Linq;
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

        public async Task CreateLanguage(Language dataInput)
        {
            _databaseContext.languages.Add(dataInput);
          await  _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteALanguage(Language dataInput)
        {
            _databaseContext.languages.Remove(dataInput);
           await _databaseContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Language>> GetListOfLanguages()
        {
            var LanguageList = await _databaseContext.languages.ToListAsync();
            return LanguageList;
        }


        public async Task<Language> GetSingleLanguage(int? id)
        {
            var language = await _databaseContext.languages.FirstOrDefaultAsync(e => e.Id == id);
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


        public async Task<bool> SaveChanges()
        {
            return (await _databaseContext.SaveChangesAsync() >= 1);
        }


        public async Task UpdateLanguage(Language dataInput)
        {
            _databaseContext.Entry(dataInput).State = EntityState.Modified;
           await _databaseContext.SaveChangesAsync();
        }
    }
}