using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PartsList.Server.Data;
using PartsList.Shared.Data;
using PartsList.Shared.Models;

namespace PartsList.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        Repository<Vendor, PartsListContext> _vendorsManager;

        public VendorsController(Repository<Vendor, PartsListContext> vendorsManager)
        {
            _vendorsManager = vendorsManager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<Vendor>>> GetAllVendors()
        {
            try
            {
                var result = await _vendorsManager.GetAll();
                return Ok(new APIListOfEntityResponse<Vendor>()
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                /// TODO: log an exception
                /// 

                return StatusCode(500);
            }
        }

        [HttpGet("{VendorId}")]
        public async Task<ActionResult<APIEntityResponse<Vendor>>> GetByVendorId(int VendorId)
        {
            try
            {
                var result = (await _vendorsManager.Get(x => x.Id == VendorId)).FirstOrDefault();
                if (result != null)
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = false,
                        ErrorMessages = new List<string> { $"Vendor with Id = {VendorId} not found" },
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                /// TODO log the exception
                /// 

                return StatusCode(500);
            }

        }

        [HttpGet("searchbyname/{VendorName}")]
        public async Task<ActionResult<APIListOfEntityResponse<Vendor>>> GetByContactName(string VendorName)
        {
            try
            {
                var result = await _vendorsManager.Get(x => x.Name.ToLower().Contains(
                    VendorName.ToLower()));
                if (result != null && result.Any())
                {
                    return Ok(new APIListOfEntityResponse<Vendor>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIListOfEntityResponse<Vendor>()
                    {
                        Success = false,
                        ErrorMEssage = new List<string> { $"{VendorName} not found" },
                        Data = null
                    }); ;
                }
            }
            catch (Exception ex)
            {
                /// TODO: log exception
                /// 

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIEntityResponse<Vendor>>> Post([FromBody] Vendor Vendor)
        {
            try
            {
                var result = await _vendorsManager.Insert(Vendor);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = false,
                        ErrorMessages = new List<string> { $"Vendor with name = {Vendor.Name} not created" },
                        Data = null
                    });
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<APIEntityResponse<Vendor>>> Put([FromBody] Vendor Vendor)
        {
            try
            {
                var result = await _vendorsManager.Update(Vendor);
                if (result != null )
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Vendor>()
                    {
                        Success = false,
                        ErrorMessages = new List<string> { $"Vendor with name = {Vendor.Name} not updated" },
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                /// TODO: log the exception
                /// 

                return StatusCode(500);
            }
        }

        [HttpDelete("{VendorId}")]
        public async Task<ActionResult> Delete(int VendorId)
        {
            try
            {
                var result = await _vendorsManager.Delete(VendorId);
                if (result)
                    return NoContent();
                else
                    return StatusCode(500);
            }
            catch 
            { 
                /// TODO: log the exception
                /// 

                return StatusCode(500); 
            }
        }
    }
}
