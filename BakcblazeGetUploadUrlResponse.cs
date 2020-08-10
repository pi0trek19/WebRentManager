using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager
{
    public class BakcblazeGetUploadUrlResponse
    {
        public string BucketId { get; set; }
        public string UploadUrl { get; set; }
        public string AuthorizationToken { get; set; }
    }
}
