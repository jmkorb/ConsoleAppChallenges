using Claims_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>() { };
        //CreateClaim
        public bool Create(Claim claim)
        {
            if(claim == default)
            {
                return false;
            }

            this._claims.Enqueue(claim);
            return true;
        }
        //Read list of claims
        public Queue<Claim> ReadClaims()
        {
            return _claims;
        }
        //Update and Delete are the same. Handling a claim
        public bool Delete()
        {
            if(_claims.Dequeue() == null)
            {
                return false;
            }
            _claims.Dequeue();
            return true;
        }
    }
}
