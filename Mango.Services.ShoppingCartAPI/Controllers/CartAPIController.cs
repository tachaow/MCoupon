using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public CartAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {

            try
            {
                var cartHeaderFromDb = await _db.CartHeaders
                    .FirstOrDefaultAsync(u => u.CartHeaderId == cartDto.CartHeader.CartHeadId);

                if (cartHeaderFromDb == null) 
                {
                    // create header , detail
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _db.CartHeaders.Add(cartHeader);
                    await _db.SaveChangesAsync();

                    cartDto.CartDetails.First().CartHeaderId = cartHeader.CartHeaderId;
                    _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _db.SaveChangesAsync();

                   

                }
                else
                {
                    //if header not null
                    //check detail has same product


                }
                _response.Result = cartDto;
            }
            catch (Exception ex)
            {

                _response.Message = ex.ToString();
                _response.IsSuccess = false;
            }

            return _response;

            //try
            //{
            //    var cartHeaderFromDb = await _db.CartHeaders
            //        .FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader.UserId);
            //    if (cartHeaderFromDb == null)
            //    {
            //       //create header and details

            //       //Header
            //        CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
            //        _db.CartHeaders.Add(cartHeader);
            //        await _db.SaveChangesAsync();

            //        //Details
            //        cartDto.CartDetails.First().CartHeaderId = cartHeader.CartHeadId;
            //        _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
            //        await _db.SaveChangesAsync();
            //    }
            //    else
            //    {
            //        //if header is not null
            //        //check if detail has same product
            //        var cartDetailFromDb = await _db.CartDetails
            //            .FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails.First().ProductId &&
            //            u.CartHeaderId == cartHeaderFromDb.CartHeadId);

            //        if (cartDetailFromDb == null)
            //        {
            //            //create cartdetails
            //            cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.CartHeadId;
            //            _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
            //            await _db.SaveChangesAsync();
            //        }
            //        else
            //        {
            //            //update count in cart details
            //            cartDto.CartDetails.First().Count += cartDetailFromDb.Count;
            //            cartDto.CartDetails.First().CartHeaderId += cartDetailFromDb.CartHeaderId;
            //            cartDto.CartDetails.First().CartDetailId += cartDetailFromDb.CartDetailId;

            //            _db.CartDetails.Update(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
            //            await _db.SaveChangesAsync();

            //        }
            //    }
            //    _response.Result = cartDto;
            
            //}
            //catch (Exception ex)
            //{
            //    _response.Message = ex.Message.ToString();
            //    _response.IsSuccess = false;
            //}

            //return _response;
        }
    }
}
