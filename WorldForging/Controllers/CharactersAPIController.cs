using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WorldForging.Models;
using WorldForging.Models.Characters;

namespace WorldForging.Controllers
{
    public class CharactersAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CharactersAPI
        public IQueryable<Character> GetCharacters()
        {
            return db.Characters;
        }

        // GET: api/CharactersAPI/5
        [ResponseType(typeof(Character))]
        public async Task<IHttpActionResult> GetCharacter(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/CharactersAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCharacter(int id, Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            db.Entry(character).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CharactersAPI
        [ResponseType(typeof(CreateCharacterModel))]
        public async Task<IHttpActionResult> PostCharacter(CreateCharacterModel createCharacterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Characters.Add(character);
            //await db.SaveChangesAsync();

            createCharacterModel.VMEntity.WorldId = createCharacterModel.WorldId;
            db.Entities.Add(createCharacterModel.VMEntity);
            createCharacterModel.VMCharacter.Entity = createCharacterModel.VMEntity;
            db.Characters.Add(createCharacterModel.VMCharacter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = createCharacterModel.VMCharacter.CharacterId }, createCharacterModel.VMCharacter);
        }

        // DELETE: api/CharactersAPI/5
        [ResponseType(typeof(Character))]
        public async Task<IHttpActionResult> DeleteCharacter(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            db.Characters.Remove(character);
            await db.SaveChangesAsync();

            return Ok(character);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacterExists(int id)
        {
            return db.Characters.Count(e => e.CharacterId == id) > 0;
        }
    }
}