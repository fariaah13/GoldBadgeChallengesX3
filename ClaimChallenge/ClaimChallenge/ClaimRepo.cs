using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimChallenge
{
    public class ClaimRepo
    {
        private Queue<Claim> _claim = new Queue<Claim>();
        //Add claim
        public void AddClaim(Claim newClaim)
        {
            _claim.Enqueue(newClaim);
        }

        //View All
        public Queue<Claim> GetAllClaims()
        {
            return _claim;
        }
    }
}
