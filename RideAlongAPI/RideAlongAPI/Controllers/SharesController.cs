using RideAlongAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Persistence;

namespace RideAlongAPI.Controllers
{
    public class SharesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        //public SharesController()
        //    : this(new UnitOfWork(new ApplicationDbContext()))
        //{
        //}

        public SharesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Shares
        public IHttpActionResult Get()
        {
            var shares = _unitOfWork.Shares.GetAll();

            return Ok(shares);
        }

        // GET: api/Shares/5
        public IHttpActionResult Get(int id)
        {
            var share = _unitOfWork.Shares.Get(id);

            if (share == null)
                return NotFound();

            return Ok(share);
        }

        // POST: api/Shares
        public IHttpActionResult Post(Share share)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _unitOfWork.Shares.Add(share);
            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + share.Id), share);
        }

        // PUT: api/Shares/5
        public IHttpActionResult Put(int id, Share share)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var shareInDb = _unitOfWork.Shares.Get(id);

            if (shareInDb == null)
                return NotFound();

            _unitOfWork.Shares.Update(share);

            return Ok();
        }

        // DELETE: api/Shares/5
        public IHttpActionResult Delete(int id)
        {
            var share = _unitOfWork.Shares.Get(id);

            if (share == null)
                return NotFound();

            _unitOfWork.Shares.Remove(share);

            return Ok();
        }
    }
}
