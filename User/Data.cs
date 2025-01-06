using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data {
    public struct TicketData {
        public string ClientName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string AssignedOperatorName { get; set; }
        public string OperatorResponse { get; set; }
    }

    public struct ClientData {
        public string ClientName { get; set; }
        public string ConsentGiven { get; set; }
        public string FirstLogin { get; set; }
    }
}