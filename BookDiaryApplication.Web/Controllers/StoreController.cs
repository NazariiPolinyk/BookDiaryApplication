using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IRepository<Store> _storeRepository;
    private readonly IMapper _mapper;

    public StoreController(IRepository<Store> storeRepository, IMapper mapper)
    {
      _storeRepository = storeRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Store>>> GetAllStoresAsync()
    {
      var stores = await _storeRepository.GetAllAsync();

      if (stores == null)
      {
        return NotFound();
      }

      return Ok(stores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Store>> GetStoreByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var store = await _storeRepository.GetByIdAsync(id);

      if (store == null)
      {
        return NotFound(id);
      }

      return Ok(store);
    }

    [HttpPost]
    public async Task<ActionResult<Store>> CreateStore(StoreDTO storeInputModel)
    {
      if (storeInputModel == null)
      {
        return BadRequest();
      }

      var store = _mapper.Map<Store>(storeInputModel);

      await _storeRepository.InsertAsync(store);

      return Ok(store);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Store>> UpdateStore(int id, StoreDTO storeInputModel)
    {
      if (!_storeRepository.Exists(id))
      {
        return NotFound();
      }

      var store = _mapper.Map<Store>(storeInputModel);
      store.Id = id;

      await _storeRepository.UpdateAsync(store);

      return Ok(store);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Store>> DeleteStore(int id)
    {
      var store = await _storeRepository.GetByIdAsync(id);

      if (store == null)
      {
        return NotFound();
      }

      await _storeRepository.DeleteAsync(store);

      return Ok(store);
    }
  }
}
