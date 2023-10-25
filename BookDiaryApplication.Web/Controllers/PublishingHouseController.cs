using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PublishingHouseController : ControllerBase
  {
    private readonly IRepository<PublishingHouse> _publishingHouseRepository;
    private readonly IMapper _mapper;

    public PublishingHouseController(IRepository<PublishingHouse> publishingHouseRepository, IMapper mapper)
    {
      _publishingHouseRepository = publishingHouseRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PublishingHouse>>> GetAllPublishingHousesAsync()
    {
      var publishingHouses = await _publishingHouseRepository.GetAllAsync();

      if (publishingHouses == null)
      {
        return NotFound();
      }

      return Ok(publishingHouses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublishingHouse>> GetPublishingHouseByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var publishingHouse = await _publishingHouseRepository.GetByIdAsync(id);

      if (publishingHouse == null)
      {
        return NotFound(id);
      }

      return Ok(publishingHouse);
    }

    [HttpPost]
    public async Task<ActionResult<PublishingHouse>> CreatePublishingHouse(PublishingHouseDTO publishingHouseInputModel)
    {
      if (publishingHouseInputModel == null)
      {
        return BadRequest();
      }

      var publishingHouse = _mapper.Map<PublishingHouse>(publishingHouseInputModel);

      await _publishingHouseRepository.InsertAsync(publishingHouse);

      return Ok(publishingHouse);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<PublishingHouse>> UpdatePublishingHouse(int id, PublishingHouseDTO publishingHouseInputModel)
    {
      if (!_publishingHouseRepository.Exists(id))
      {
        return NotFound();
      }

      var publishingHouse = _mapper.Map<PublishingHouse>(publishingHouseInputModel);
      publishingHouse.Id = id;

      await _publishingHouseRepository.UpdateAsync(publishingHouse);

      return Ok(publishingHouse);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<PublishingHouse>> DeletePublishingHouse(int id)
    {
      var publishingHouse = await _publishingHouseRepository.GetByIdAsync(id);

      if (publishingHouse == null)
      {
        return NotFound();
      }

      await _publishingHouseRepository.DeleteAsync(publishingHouse);

      return Ok(publishingHouse);
    }
  }
}
