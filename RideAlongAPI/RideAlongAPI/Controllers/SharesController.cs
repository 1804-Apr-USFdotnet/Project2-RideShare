using RideAlongAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RideAlongAPI.Core.Domain;
using RideAlongAPI.Persistence;

namespace RideAlongAPI.Controllers
{
    [Authorize]
    public class SharesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SharesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Shares
        [HttpGet]
        [AllowAnonymous]
        [Route("api/shares")]
        public IHttpActionResult Get()
        {
            var shares = _unitOfWork.Shares.GetAll();

            return Ok(shares);
        }

        // GET: api/Shares/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var share = _unitOfWork.Shares.Get(id);

            if (share == null)
                return NotFound();

            return Ok(share);
        }

        // POST: api/Shares
        [HttpPost]
        [Route("api/shares")]
        public IHttpActionResult Post(Share share)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = GetEmail();

            share.Email = member;

            _unitOfWork.Shares.Add(share);
            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + share.Id), share);
        }

        // PUT: api/Shares/5
        [HttpPut]
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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var share = _unitOfWork.Shares.Get(id);

            if (share == null)
                return NotFound();

            _unitOfWork.Shares.Remove(share);

            return Ok();
        }

        [Route("api/Shares-ByDate-Descending")]
        [HttpGet]
        public IHttpActionResult GetDateDescending()
        {
            var shares = _unitOfWork.Shares.GetDateDescending();
            return Ok(shares);
        }

        [Route("api/Shares-Seats-Descending")]
        [HttpGet]
        public IHttpActionResult GetSeatsDescending()
        {
            var shares = _unitOfWork.Shares.GetSeatsDescending();
            return Ok(shares);
        }
        
        [Route("api/Shares-Most-Departing-City")]
        [HttpGet]
        public IHttpActionResult GetMostDepartedCity()
        {
            var shares = _unitOfWork.Shares.GetDepartureCityWithMostShares();
            return Ok(shares);
        }

        [Route("api/Shares-Most-Destination-City")]
        [HttpGet]
        public IHttpActionResult GetMostDestinationCity()
        {
            var shares = _unitOfWork.Shares.GetDestinationCityWithMostShares();
            return Ok(shares);
        }

        [Route("api/Shares-Search-Conditions-City/{desired}")]
        [HttpGet]
        public IHttpActionResult GetSearchDesired(string desired)
        {
            var shares = _unitOfWork.Shares.GetSearchConditions(desired);
            return Ok(shares);
        }

        [Route("api/Shares-Setup-Ride/{startPoint}/{endPoint}")]
        [HttpGet]
        public IHttpActionResult GetRideSetup(string startPoint = "empty", string endPoint = "empty")
        {
            var shares = _unitOfWork.Shares.GetDesiredShare(startPoint, endPoint);
            return Ok(shares);
        }

        [HttpGet]
        [Route("api/my-shares")]
        public IHttpActionResult GetMyShares()
        {
            var email = GetEmail();
            var shares = _unitOfWork.Shares.Find(s => s.Email == email);
            return Ok(shares);
        }

        public string GetEmail()
        {
            ClaimsIdentity ci = (ClaimsIdentity) User.Identity;
            return ci.Claims.ToList()[1].Value;
        }
    }
}
