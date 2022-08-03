using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using codingLanguages.Data;
using codingLanguages.Models;
using codingLanguages.Repos;


namespace codingLanguages.Controllers
{
    [ApiController]
    [Route("api/v1/{controller}")]
    public class CodingLanguagesController: ControllerBase
    {
        private readonly ILanguageRepo _repoInterface;

        public CodingLanguagesController(ILanguageRepo repoInterface)
        {
            _repoInterface = repoInterface;
        }

        [Route("status")]
        [HttpGet]
        public string ApiStatus ()
        {
            return _repoInterface.health();
        }


        [HttpGet]
        public ActionResult<IEnumerable<Language>> CodingLanguagesList()
        {
            var dataList = _repoInterface.GetListOfLanguages();
            return Ok(dataList);
        }


        [HttpGet("{id}")]
        public ActionResult<Language> GetLanguage(int? id)
        {
            if(id == 0 && id == null)
            {
                return BadRequest();
            }
            return _repoInterface.GetSingleLanguage(id);

        }


        [HttpPost]
        public ActionResult CreateLanguage(Language languageInput)
        {
            var totalLanguagesStored = _repoInterface.GetListOfLanguages().Count();
            if(totalLanguagesStored <= 15)
            {
                _repoInterface.CreateLanguage(languageInput);
                return CreatedAtAction(nameof(GetLanguage), new{id = languageInput.Id}, languageInput);
            }
            return BadRequest();
           
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteLanguage (int? id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var language = _repoInterface.GetSingleLanguage(id);
            if(language == null){ return NotFound(); }
             _repoInterface.DeleteALanguage(language);
             return NoContent();
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateLanguage(int? id, Language languageInput)
        {
            if(id == 0){ return NotFound(); }
            if(id != languageInput.Id)
            {
                return NotFound();
            }
            _repoInterface.UpdateLanguage(languageInput);
            return NoContent();
        }

    }

}

