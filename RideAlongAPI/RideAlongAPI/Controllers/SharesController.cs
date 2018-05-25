using RideAlongAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Persistence;

namespace RideAlongAPI.Controllers
{
    [Authorize]
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

        [Route("api/Shares-ByDate-Descending")]
        public IHttpActionResult GetDateDescending()
        {
            var shares = _unitOfWork.Shares.GetDateDescending();
            return Ok(shares);
        }

        [Route("api/Shares-Seats-Descending")]
        public IHttpActionResult GetSeatsDescending()
        {
            var shares = _unitOfWork.Shares.GetSeatsDescending();
            return Ok(shares);
        }
        
        [Route("api/Shares-Most-Departing-City")]
        public IHttpActionResult GetMostDepartedCity()
        {
            var shares = _unitOfWork.Shares.GetDepartureCityWithMostShares();
            return Ok(shares);
        }

        [Route("api/Shares-Most-Destination-City")]
        public IHttpActionResult GetMostDestinationCity()
        {
            var shares = _unitOfWork.Shares.GetDestinationCityWithMostShares();
            return Ok(shares);
        }

        [Route("api/Shares-Search-Conditions-City/{desired}")]
        public IHttpActionResult GetSearchDesired(string desired)
        {
            var shares = _unitOfWork.Shares.GetSearchConditions(desired);
            return Ok(shares);
        }

        [Route("api/Shares-Setup-Ride/{startPoint}/{endPoint}")]
        public IHttpActionResult GetRideSetup(string startPoint = "empty", string endPoint = "empty")
        {
            var shares = _unitOfWork.Shares.GetDesiredShare(startPoint, endPoint);
            return Ok(shares);
        }
    }
}
