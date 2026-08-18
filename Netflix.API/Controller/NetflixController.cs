using Microsoft.AspNetCore.Mvc;
using Netflix.DAL;
using Netflix.DTO;

namespace Netflix.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NetflixController : ControllerBase
{
    private readonly NetflixDAL netflixDAL;

    public NetflixController(NetflixDAL dal)
    {
        netflixDAL = dal;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        var movies = netflixDAL.GetData();

        return Ok(movies);
    }

 [HttpPost]
    public IActionResult CreateMovie(NetflixDTO movie)
    {
        var movies = netflixDAL.GetData();

        var existingMovie = movies.FirstOrDefault(x => x.Show_Id == movie.Show_Id);

        if (existingMovie != null)
        {
            return Ok("Movie already exists");
        }

        netflixDAL.CreateData(movie);

        return Ok("Successfully created");
    }
      [HttpPut]
    public IActionResult UpdateMovie(NetflixDTO movie)
    {
        netflixDAL.UpdateData(movie);
        return Ok(movie);
    }
    [HttpDelete]
    public IActionResult DeleteMovie(NetflixDTO movie)
    {
        netflixDAL.DeleteData(movie);
        return Ok(movie);
    }
   

}