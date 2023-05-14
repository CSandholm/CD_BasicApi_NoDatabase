using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		public static List<CD> cds = new List<CD>()
		{
			new CD(1,"Leva låta Dö", "Mcartney"),
			new CD(2,"Sjung sjung", "Arne Wise"),
			new CD(3, "Tinas bästa", "Tina Törner")
		};
		// GET: api/<ValuesController>
		[HttpGet]
		public List<CD> Get()
		{
			return cds;
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public CD Get(int id)
		{
			try
			{
				return cds.Find(x => x.Id == id);
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		// POST api/<ValuesController>
		[HttpPost]
		public ActionResult Post([FromBody] CD cd)
		{
			foreach(CD existingCd in cds)
			{
				if(existingCd.Title == cd.Title)
				{
					return StatusCode(400);
				}
			}
			try
			{
				cds.Add(new CD(cd.Id, cd.Title, cd.Artist));
				return StatusCode(200);
			}
			catch
			{
				return StatusCode(404);
			}
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] CD cd)
		{
			try
			{
				CD ccd = cds.Find(x => x.Id == id);
				ccd.Title = cd.Title;
				ccd.Artist = cd.Artist;
				return StatusCode(200);
			}
			catch(Exception ex)
			{
				return StatusCode(404);
			}
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				cds.Remove(cds.Find(x => x.Id == id));
				return StatusCode(200);
			}
			catch
			{
				return StatusCode(404);
			}
		}
	}
}
