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
        public async Task<ActionResult<IEnumerable<Language>>> CodingLanguagesList()
        {
            var dataList = await _repoInterface.GetListOfLanguages();
            return Ok(dataList);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Language>> Language(int? id)
        {
            if(id == 0 && id == null)
            {
                return BadRequest();
            }
            return await _repoInterface.GetSingleLanguage(id);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateLanguage(Language languageInput)
        {
            var totalLanguagesStored = await _repoInterface.GetListOfLanguages();
            var totalLength = totalLanguagesStored.Count();
            if(totalLength <= 15)
            {
                await _repoInterface.CreateLanguage(languageInput);
                return CreatedAtAction(nameof(Language), new{id = languageInput.Id}, languageInput);
            }
            return BadRequest();
           
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteLanguage (int? id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var language = await _repoInterface.GetSingleLanguage(id);
            if(language == null){ return NotFound(); }
             await _repoInterface.DeleteALanguage(language);
             return NoContent();
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateLanguage(int? id, Language languageInput)
        {
            if(id == 0){ return NotFound(); }
            if(id != languageInput.Id)
            {
                return NotFound();
            }
            await _repoInterface.UpdateLanguage(languageInput);
            return NoContent();
        }

    }

}

