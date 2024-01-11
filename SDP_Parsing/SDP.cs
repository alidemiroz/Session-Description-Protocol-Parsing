using System;

namespace SDP_Parsing
{
	public class SDP
	{
        public List<string> sdpLines = new List<string>();
        public string ProtocolVersion { get; set; }
        public Owner Owner { get; set; } = new Owner();
        public string SessionName { get; set; }
        public string SessionInfo { get; set; }
        public string UriDescp { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Connection Connection { get; set; } = new Connection();
        public Bandwith Bandwidth { get; set; } = new Bandwith();
        public TimeZone TimeZone { get; set; } = new TimeZone();
        public Media Media { get; set; } = new Media();
        public List<string> Attribute { get; set; } = new List<string>();
    }
}

