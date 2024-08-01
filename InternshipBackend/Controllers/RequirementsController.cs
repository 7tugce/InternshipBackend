using InternshipBackend.Data;
using InternshipBackend.Models;
using InternshipBackend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public RequirementsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET METODU YAPMAK İÇİN GEREKLİ OLAN
        [HttpGet]
        public IActionResult GetAllRequests() {

         
            return Ok(dbContext.Requests.ToList());
        }
        // IDYE GÖRE GETİR
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRequestById(Guid id) 
        {
          var request =  dbContext.Requests.Find(id);
            if(request == null)
            {
                return NotFound();
            }
            return Ok(request);

        }
        //POST METODU
        [HttpPost]

        public IActionResult AddRequest(AddRequestDto addRequestDto)
        {

            var requestEntity = new Request()
            {
                Date = DateTime.Now,
                SubmittedBy= addRequestDto.SubmittedBy,
                Role= addRequestDto.Role,
                Approach = addRequestDto.Approach,
                Gains = addRequestDto.Gains,
                History = addRequestDto.History,
                Limitations = addRequestDto.Limitations,
                Requirement = addRequestDto.Requirement,
                Sketch = addRequestDto.Sketch,
            };



            dbContext.Requests.Add(requestEntity);
            dbContext.SaveChanges();
            return Ok(requestEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public  IActionResult UpdateRequest(Guid id,UpdateRequestDto updateRequestDto ) 
        { 
        var request = dbContext.Requests.Find(id);
            if(request == null)
            {
                return NotFound();

            }
            request.Date = DateTime.Now;
            request.Limitations = updateRequestDto.Limitations; 
            request.Requirement = updateRequestDto.Requirement; 
            request.Sketch = updateRequestDto.Sketch;   
            request.History = updateRequestDto.History; 
            request.Approach = updateRequestDto.Approach;   
            request.Gains = updateRequestDto.Gains;
            request.Role = updateRequestDto.Role;   
            request.Sketch= updateRequestDto.Sketch;

            dbContext.SaveChanges();

            return Ok(request);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteRequest(Guid id)
        {
            var request = dbContext.Requests.Find(id);

            if (request == null)
            {
                return NotFound();
            }
            
                dbContext.Requests.Remove(request);
                dbContext.SaveChanges();
            return Ok();
        
        }
    }
}
